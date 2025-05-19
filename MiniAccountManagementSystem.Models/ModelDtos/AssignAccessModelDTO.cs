using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace MiniAccountManagementSystem.Models.ModelDtos
{
    public class AssignAccessModelDTO
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public int ModuleId { get; set; }

        public bool CanView { get; set; }  

        public bool CanEdit { get; set; }
        [ValidateNever]
        public List<SelectListItem>? Roles { get; set; }
        [ValidateNever]
        public List<SelectListItem>? Modules { get; set; }


    }
}
