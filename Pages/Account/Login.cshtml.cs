using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Portfolio.Data;
using System.Linq;
using System;
using System.Threading.Tasks;
using Portfolio.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace Portfolio.Pages
{
    // Déclarer la classe :
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }

        private readonly ILogger<LoginModel> logger;
        private readonly PortfolioContext context;

        // Constructeur :
        // var newLogger = new ILogger<AdminModel>();
        // var newContext = new PortfolioContext();
        // var newPage =  new AdminModel(newLogger, newContext); 
        public LoginModel(ILogger<LoginModel> logger, PortfolioContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            // vérifier si username / password est null ou vide
            // vérifier si username est contenu dans la base de données 
            // si username contenu dans la bdd, faire une vérif du password associé
            // si password est bon, Authenticate(user)
            // rediriger vers /Admin

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                Msg = "Le nom d'utilisateur et le mot de passe ne peuvent pas être vides.";
                return Page();
            }

            var user = this.context.Users.FirstOrDefault(user => user.Login.ToLower().Equals(Username.ToLower()));

            if (user != null)
            {
                if (user.Password.Equals(Password))
                {
                    await AuthenticateUser(user);
                    //return RedirectToPage("Admin");
                }
            }

            Msg = "Le nom d'utilisateur ou le mot de passe est incorrect.";
            return Page();
        }

        private async Task AuthenticateUser(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, "Administrator")
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProps = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.AddDays(1).ToUniversalTime()
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProps);
        }
    }
}
