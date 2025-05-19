using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;
using MiniAccountManagementSystem.Models.ModelDtos;

namespace MiniAccountManagementSystem.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AddUserModel : PageModel
    {
        private readonly DatabaseHelper _db;

        public AddUserModel(DatabaseHelper db)
        {
            _db = db;
        }


        [BindProperty]
        public AddUserModelDTO model { get; set; }  

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Password))
                return Page();

            var parameters = new[]
            {
            new SqlParameter("@Username", model.UserName),
            new SqlParameter("@PasswordHash", model.Password) 
        };

            _db.ExecuteNonQuery("AddUser", parameters);

            TempData["Success"] = "User added successfully.";
            return RedirectToPage("/Admin/AddUser");
        }
    }
}
