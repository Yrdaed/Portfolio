using System.Data;
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
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> logger;
        private readonly PortfolioContext context;
        [BindProperty]
        public Parameter ParameterToDelete { get; set; }

        // Constructeur :
        // var newLogger = new ILogger<AdminModel>();
        // var newContext = new PortfolioContext();
        // var newPage =  new AdminModel(newLogger, newContext); 
        public DeleteModel(ILogger<DeleteModel> logger, PortfolioContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            this.logger.LogInformation("OnGet Called");

            if (id == null)
            {
                return NotFound();
            }

            ParameterToDelete = await this.context.Parameters.FindAsync(id);

            if (ParameterToDelete != null)
            {
                this.context.Remove(ParameterToDelete);
                await this.context.SaveChangesAsync();
            }

            return RedirectToPage(".Index");
        }
    }
}
