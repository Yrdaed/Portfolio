using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Portfolio.Data;

namespace Portfolio.Pages
{
    // Déclarer la classe IndexModel qui hérite de PageModel :
    public class IndexModel : PageModel
    {
        // Déclarer les paramètres stockés dans la BDD modifiables affichés dans Index
        public string SiteTitle { get; set; }
        public string SubTitle { get; set; }
        public string PrimButton { get; set; }
        public string CvButton { get; set; }
        public string AboutTitle { get; set; }
        public string AboutText { get; set; }
        public string Project1Title { get; set; }
        public string Project2Title { get; set; }
        public string Project3Title { get; set; }
        public string Project1Text { get; set; }
        public string Project2Text { get; set; }
        public string Project3Text { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Déclarer les paramètres stockés dans la BDD partagés entre _layout et Index :
        [ViewData]
        public string NavTitle { get; set; }
        [ViewData]
        public string Section1 { get; set; }
        [ViewData]
        public string Section2 { get; set; }
        [ViewData]
        public string Section3 { get; set; }

        private readonly ILogger<IndexModel> logger;
        private readonly PortfolioContext context;

        // Le constructeur instancie le contexte et le stocke dans une variable :
        // var newLogger = new ILogger<IndexModel>();
        // var newContext = new PortfolioContext();
        // var newPage =  new IndexModel(newLogger, newContext); 
        public IndexModel(ILogger<IndexModel> logger, PortfolioContext context)
        {
            this.logger = logger;
            this.context = context;

            this.logger.LogInformation("Classe IndexModel instanciée");
        }

        // Aller chercher les paramètres dans la BDD avec la méthode OnGet() :
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

            var navTitleParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("NavTitle"));
            if (navTitleParameter != null)
            {
                this.NavTitle = navTitleParameter.ParameterValue;
            }

            var primbuttonParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("PrimButton"));
            if (primbuttonParameter != null)
            {
                this.PrimButton = primbuttonParameter.ParameterValue;
            }

            var cvbuttonParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("CvButton"));
            if (cvbuttonParameter != null)
            {
                this.CvButton = cvbuttonParameter.ParameterValue;
            }

            var abouttitleParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("AboutTitle"));
            if (abouttitleParameter != null)
            {
                this.AboutTitle = abouttitleParameter.ParameterValue;
            }

            var abouttextParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("AboutText"));
            if (abouttextParameter != null)
            {
                this.AboutText = abouttextParameter.ParameterValue;
            }

            var Project1TitleParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Project1Title"));
            if (Project1TitleParameter != null)
            {
                this.Project1Title = Project1TitleParameter.ParameterValue;
            }

            var Project2TitleParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Project2Title"));
            if (Project2TitleParameter != null)
            {
                this.Project2Title = Project2TitleParameter.ParameterValue;
            }

            var Project3TitleParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Project3Title"));
            if (Project3TitleParameter != null)
            {
                this.Project3Title = Project3TitleParameter.ParameterValue;
            }

            var Project1TextParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Project1Text"));
            if (Project1TextParameter != null)
            {
                this.Project1Text = Project1TextParameter.ParameterValue;
            }

            var Project2TextParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Project2Text"));
            if (Project2TextParameter != null)
            {
                this.Project2Text = Project2TextParameter.ParameterValue;
            }

            var Project3TextParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Project3Text"));
            if (Project3TextParameter != null)
            {
                this.Project3Text = Project3TextParameter.ParameterValue;
            }

            var AddressParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Address"));
            if (AddressParameter != null)
            {
                this.Address = AddressParameter.ParameterValue;
            }

            var EmailParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Email"));
            if (EmailParameter != null)
            {
                this.Email = EmailParameter.ParameterValue;
            }

            var PhoneParameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Phone"));
            if (PhoneParameter != null)
            {
                this.Phone = PhoneParameter.ParameterValue;
            }

            var section1Parameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Section1"));
            if (section1Parameter != null)
            {
                this.Section1 = section1Parameter.ParameterValue;
            }

            var section2Parameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Section2"));
            if (section2Parameter != null)
            {
                this.Section2 = section2Parameter.ParameterValue;
            }

            var section3Parameter = this.context.Parameters.FirstOrDefault(e => e.ParameterKey.Equals("Section3"));
            if (section3Parameter != null)
            {
                this.Section3 = section3Parameter.ParameterValue;
            }
        }
    }
}
