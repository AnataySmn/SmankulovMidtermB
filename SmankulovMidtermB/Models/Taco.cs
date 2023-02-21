using System.ComponentModel.DataAnnotations;

namespace SmankulovMidtermB.Models
{
    public class Taco
    {
       public int Id { get; set; }
        [Display(Name = "make your taco bigger)")]
        public string? Size { get; set; }
        [Display(Name = "make your taco tastier)")]
        public string? Filling { get; set; }

        [MinLength(3)]
       public string? FirstName { get; set; }
        [Required]
       public string? LastName { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Display(Name = "day month year")]
        public DateTime DateRequested { get; set; }
        public double Total { get; set; }

     
    }
}
