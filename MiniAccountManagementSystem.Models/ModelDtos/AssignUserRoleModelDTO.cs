using System.ComponentModel.DataAnnotations;


namespace MiniAccountManagementSystem.Models.ModelDtos
{
    public class AssignUserRoleModelDTO
    {
        [Required]
        public int SelectedUserId { get; set; }

        [Required]
        public int SelectedRoleId { get; set; }
    }
}
