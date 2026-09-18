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
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Nuværende adgangskode skal udfyldes.")]
            [DataType(DataType.Password)]
            [Display(Name = "Nuværende adgangskode")]
            public string OldPassword { get; set; }

            [Required(ErrorMessage = "Ny adgangskode skal udfyldes.")]
            [StringLength(
                100,
                ErrorMessage = "Adgangskoden skal være mellem {2} og {1} tegn.",
                MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Ny adgangskode")]
            public string NewPassword { get; set; }

            [Required(ErrorMessage = "Bekræft den nye adgangskode.")]
            [DataType(DataType.Password)]
            [Display(Name = "Bekræft ny adgangskode")]
            [Compare(
                "NewPassword",
                ErrorMessage = "De to adgangskoder matcher ikke.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound(
                    $"Kunne ikke finde brugeren med ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);

            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound(
                    $"Kunne ikke finde brugeren med ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(
                user,
                Input.OldPassword,
                Input.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        error.Description);
                }

                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);

            _logger.LogInformation(
                "Brugeren ændrede sin adgangskode.");

            StatusMessage = "Din adgangskode er blevet ændret.";

            return RedirectToPage();
        }
    }
}