using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Portfolio.Data;
using System.Threading.Tasks;
using Portfolio.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Pages
{
    // Déclarer la classe :
    public class AdminModel : PageModel
    {
        private readonly ILogger<AdminModel> logger;
        private readonly PortfolioContext context;

        // Constructeur :
        // var newLogger = new ILogger<AdminModel>();
        // var newContext = new PortfolioContext();
        // var newPage =  new AdminModel(newLogger, newContext); 
        public AdminModel(ILogger<AdminModel> logger, PortfolioContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("Index");
        }
    }
}
