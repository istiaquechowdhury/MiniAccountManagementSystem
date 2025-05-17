using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;

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
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                return Page();

            var parameters = new[]
            {
            new SqlParameter("@Username", Username),
            new SqlParameter("@PasswordHash", Password) 
        };

            _db.ExecuteNonQuery("AddUser", parameters);

            TempData["Success"] = "User added successfully.";
            return RedirectToPage("/Admin/AddUser");
        }
    }
}
