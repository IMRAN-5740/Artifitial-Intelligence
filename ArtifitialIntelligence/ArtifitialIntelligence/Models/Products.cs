using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtifitialIntelligence.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Display(Name="Product Picture")]
        public string Image { get; set; }
        [Required]
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name = "Status")]
        public bool IsAvailable { get; set; }




        [Required]
        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductTypes ProductTypes { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public int SpecialTagId { get; set; }

        [ForeignKey("SpecialTagId")]
        public SpecialTag SpecialTag { get; set; }
        [Display(Name ="Company Name")]

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Companies  { get; set; }

    }
}
