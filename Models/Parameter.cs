using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Parameter
    {
        public int ID { get; set; }
        public string ParameterKey { get; set; }
        [Display(Name = "Paramètre")]
        public string ParameterName { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 2)]
        [Display(Name = "Libellé")]
        public string ParameterValue { get; set; }
    }
}