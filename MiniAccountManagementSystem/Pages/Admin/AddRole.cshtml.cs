using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;

namespace MiniAccountManagementSystem.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AddRoleModel : PageModel
    {
        private readonly DatabaseHelper _db;

        public AddRoleModel(DatabaseHelper db)
        {
            _db = db;
        }

        [BindProperty]
        public string RoleName { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(RoleName))
                return Page();

            var parameters = new[]
            {
            new SqlParameter("@RoleName", RoleName)
        };

            _db.ExecuteNonQuery("AddRole", parameters);

            TempData["Success"] = "Role added successfully.";
            return RedirectToPage("/Admin/AddRole");
        }
    }
}
