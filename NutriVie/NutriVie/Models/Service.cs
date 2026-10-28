using System.ComponentModel.DataAnnotations;

namespace NutriVie.Models
{
    public class Service
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Nom du service")]
        [StringLength(50, MinimumLength = 0)]
        public string Nom { get; set; }
        [StringLength(300, MinimumLength = 0)]
        public  string Description { get; set; }

    }
}
