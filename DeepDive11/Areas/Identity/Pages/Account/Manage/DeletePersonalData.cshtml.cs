// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DeepDive11.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DeepDive11.Areas.Identity.Pages.Account.Manage
{
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;

        public DeletePersonalDataModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<DeletePersonalDataModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Adgangskode skal udfyldes.")]
            [DataType(DataType.Password)]
            [Display(Name = "Adgangskode")]
            public string Password { get; set; }
        }

        public bool RequirePassword { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound(
                    $"Kunne ikke finde brugeren med ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound(
                    $"Kunne ikke finde brugeren med ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);

            if (RequirePassword)
            {
                var passwordIsCorrect = await _userManager.CheckPasswordAsync(
                    user,
                    Input.Password);

                if (!passwordIsCorrect)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "Adgangskoden er forkert.");

                    return Page();
                }
            }

            var userId = await _userManager.GetUserIdAsync(user);

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(
                    "Der opstod en fejl under sletning af brugeren.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation(
                "Brugeren med ID '{UserId}' slettede sin egen konto.",
                userId);

            return Redirect("~/");
        }
    }
}