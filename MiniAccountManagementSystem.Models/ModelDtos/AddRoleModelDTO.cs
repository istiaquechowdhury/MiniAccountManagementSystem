

using System.ComponentModel.DataAnnotations;

namespace MiniAccountManagementSystem.Models.ModelDtos
{
    public class AddRoleModelDTO
    {
        [Required]
        public string RoleName { get; set; }        
    }
}
