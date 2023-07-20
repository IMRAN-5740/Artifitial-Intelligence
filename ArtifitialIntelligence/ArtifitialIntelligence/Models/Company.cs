using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtifitialIntelligence.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Display(Name ="Company Name")] 
        [Required] 
        public string CompanyName { get; set; }
        [Required] 
        public string Summary { get; set; }

        [Display(Name = "Company Picture")]
        public string ImageFileName { get; set; }
        [Display(Name = "Anchor Link")]
        
        public string? AnchorLink { get; set; }
        [Display(Name ="Vote")] 
        public int Like { get; set; }
        [Display(Name="Like")]  
        public bool CanIncreaseLike { get; set; }
       
        public List<Products> ListOfProducts { get; set; }
    }
}
