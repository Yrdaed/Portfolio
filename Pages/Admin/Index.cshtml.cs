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
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Pages.Admin
{
    // Déclarer la classe :
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly PortfolioContext context;
        public IList<Parameter> Parameters;
        [BindProperty]
        public Parameter SiteTitle { get; set; }


        // Constructeur :
        // var newLogger = new ILogger<AdminModel>();
        // var newContext = new PortfolioContext();
        // var newPage =  new AdminModel(newLogger, newContext); 
        public IndexModel(ILogger<IndexModel> logger, PortfolioContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task OnGetAsync()
        {
            this.logger.LogInformation("OnGet Called");
            this.Parameters = await this.context.Parameters.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("../Index");
        }
    }
}
