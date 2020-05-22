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
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> logger;
        private readonly PortfolioContext context;
        [BindProperty]
        public Parameter ParameterToEdit { get; set; }

        // Constructeur :
        // var newLogger = new ILogger<AdminModel>();
        // var newContext = new PortfolioContext();
        // var newPage =  new AdminModel(newLogger, newContext); 
        public EditModel(ILogger<EditModel> logger, PortfolioContext context)
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

            ParameterToEdit = await this.context.Parameters.FirstOrDefaultAsync(e => e.ID == id);

            if (ParameterToEdit == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this.context.Attach(ParameterToEdit).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                this.logger.LogError(e.Message);

                if (!this.context.Parameters.Any(e => e.ID == ParameterToEdit.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
