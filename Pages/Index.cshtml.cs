using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Portfolio.Data;

namespace Portfolio.Pages
{
    // Déclarer la classe :
    public class IndexModel : PageModel
    {
        public string SiteTitle { get; set; }
        public string SubTitle { get; set; }
        private readonly ILogger<IndexModel> logger;
        private readonly PortfolioContext context;

        // Constructeur :
        // var newLogger = new ILogger<IndexModel>();
        // var newContext = new PortfolioContext();
        // var newPage =  new IndexModel(newLogger, newContext); 
        public IndexModel(ILogger<IndexModel> logger, PortfolioContext context)
        {
            this.logger = logger;
            this.context = context;

            this.logger.LogInformation("Classe IndexModel instanciée");
        }

        public void OnGet()
        {
            this.logger.LogInformation("OnGet Called");
            var siteTitleParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("SiteTitle"));
            if (siteTitleParameter != null)
            {
                this.SiteTitle = siteTitleParameter.ParameterValue;
            }

            var subTitleParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("SubTitle"));
            if (subTitleParameter != null)
            {
                this.SubTitle = subTitleParameter.ParameterValue;
            }
        }
    }
}
