// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DeepDive11.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeepDive11.Areas.Identity.Pages.Account.Manage
{
    public class EmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public EmailModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Email { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Email skal udfyldes.")]
            [EmailAddress(ErrorMessage = "Indtast en gyldig email.")]
            [Display(Name = "Ny email")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            Email = await _userManager.GetEmailAsync(user);

            Input = new InputModel
            {
                NewEmail = Email
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound(
                    $"Kunne ikke finde brugeren med ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound(
                    $"Kunne ikke finde brugeren med ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var currentEmail = await _userManager.GetEmailAsync(user);

            if (Input.NewEmail == currentEmail)
            {
                StatusMessage = "Emailen er ikke ændret.";
                return RedirectToPage();
            }

            // Opdater email
            var emailResult = await _userManager.SetEmailAsync(
                user,
                Input.NewEmail);

            if (!emailResult.Succeeded)
            {
                foreach (var error in emailResult.Errors)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        error.Description);
                }

                await LoadAsync(user);
                return Page();
            }

            // Vi bruger email som brugernavn, så den skal også opdateres.
            var userNameResult = await _userManager.SetUserNameAsync(
                user,
                Input.NewEmail);

            if (!userNameResult.Succeeded)
            {
                foreach (var error in userNameResult.Errors)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        error.Description);
                }

                await LoadAsync(user);
                return Page();
            }

            // Opdater den nuværende login-session.
            await _signInManager.RefreshSignInAsync(user);

            StatusMessage = "Din email er blevet opdateret.";

            return RedirectToPage();
        }
    }
}