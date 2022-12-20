using System.ComponentModel.DataAnnotations;

namespace ArtifitialIntelligence.Areas.Admin.Models
{
    public class RoleUserVm
    {
        [Required(ErrorMessage = "Please Enter User ")]
        [Display(Name ="User ")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please Enter Role ")]
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}
