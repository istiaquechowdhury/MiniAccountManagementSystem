
using System.ComponentModel.DataAnnotations;


namespace MiniAccountManagementSystem.Models.ModelDtos
{
    public class AddUserModelDTO
    {
        [Required]
        public string UserName { get; set; }


        [Required]
        public string Password { get; set; }    
    }
}
