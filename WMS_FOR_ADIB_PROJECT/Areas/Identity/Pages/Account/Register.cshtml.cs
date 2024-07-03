using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WMS_FOR_ADIB.DataAccess.Data;
using WMS_FOR_ADIB.Models;
using WMS_FOR_ADIB.Utility;

namespace WMS_FOR_ADIB_PROJECT.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _logger = logger;

            Input = new InputModel();
            ReturnUrl = "/";
            ExternalLogins = new List<AuthenticationScheme>(); // Initialize ExternalLogins to an empty list
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DisplayName("Employee ID")]
            public string? EmployeeId { get; set; }

            [Required]
            [DisplayName("Full Name")]
            public string? FullName { get; set; }
            [Required]
            public bool? RequiresPasswordChange { get; set; } = true;

            [Required]
            [Display(Name = "Username")]
            
            public string? UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string? Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Branch")]
            public int BranchId { get; set; }

            [Display(Name = "Branch Name")]
            public string? BranchName { get; set; }

            public IEnumerable<SelectListItem>? BranchList { get; set; }

            [ValidateNever]
            public List<string> Roles { get; set; } = new List<string>();

            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; } = new List<SelectListItem>();
        }


        public async Task OnGetAsync()
        {
            if (!_roleManager.RoleExistsAsync(SD.Role_IT).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Facility)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_IT)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Manager)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Store)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Inspector)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Checker)).GetAwaiter().GetResult();
            }

            Input.RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            }).ToList();

            Input.BranchList = _context.Branches.Select(b => new SelectListItem
            {
                Text = b.BranchName,
                Value = b.BranchID.ToString()
            }).ToList();

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null!)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.EmployeeId = Input.EmployeeId;
                user.FullName=Input.FullName;
                user.BranchId = Input.BranchId;
                user.UserName = Input.UserName;
               

             var result = await _userManager.CreateAsync(user, Input.Password!);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (Input.Roles != null && Input.Roles.Any())
                    {
                        foreach (var role in Input.Roles)
                        {
                            await _userManager.AddToRoleAsync(user, role);
                        }
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, SD.Role_Employee);
                    }

                    // No email confirmation and no auto sign-in

                    return RedirectToPage("Login", new { returnUrl = returnUrl });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }


        }
    }

}
