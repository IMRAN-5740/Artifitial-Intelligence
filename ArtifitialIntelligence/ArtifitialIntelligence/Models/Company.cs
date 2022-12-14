using System.ComponentModel.DataAnnotations;

namespace ArtifitialIntelligence.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Display(Name ="Company Name")] [Required] public string CompanyName { get; set; }
        [Required] public string Summary { get; set; }
        [Display(Name = "Image File Name")] [Required] public string ImageFileName { get; set; }
        [Display(Name = "Anchor Link")][Required] public string AnchorLink { get; set; }
        [Display(Name ="Vote")] public int Like { get; set; }
        public bool canIncreaseLike { get; set; }
    }
}
