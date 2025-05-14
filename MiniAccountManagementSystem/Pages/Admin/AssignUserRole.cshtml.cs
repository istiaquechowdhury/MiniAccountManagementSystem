using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;
using System.Data;

namespace MiniAccountManagementSystem.Pages.Admin
{
    public class AssignUserRoleModel : PageModel
    {
        private readonly DatabaseHelper _db;

        public AssignUserRoleModel(DatabaseHelper db)
        {
            _db = db;
        }

        [BindProperty]
        public int SelectedUserId { get; set; }

        [BindProperty]
        public int SelectedRoleId { get; set; }

        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> Roles { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            LoadUsers();
            LoadRoles();
        }

        public void OnPost()
        {
            LoadUsers();
            LoadRoles();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", SelectedUserId),
                new SqlParameter("@RoleId", SelectedRoleId)
            };

            _db.ExecuteNonQuery("AssignRoleToUser", parameters);
            Message = "Role assigned successfully!";
        }

        private void LoadUsers()
        {
            Users = new List<SelectListItem>();
            DataTable users = _db.ExecuteStoredProcedure("GetUsers");

            foreach (DataRow row in users.Rows)
            {
                Users.Add(new SelectListItem
                {
                    Value = row["UserId"].ToString(),
                    Text = row["UserName"].ToString()
                });
            }
        }

        private void LoadRoles()
        {
            Roles = new List<SelectListItem>();
            DataTable roles = _db.ExecuteStoredProcedure("GetRoles");

            foreach (DataRow row in roles.Rows)
            {
                Roles.Add(new SelectListItem
                {
                    Value = row["RoleId"].ToString(),
                    Text = row["RoleName"].ToString()
                });
            }
        }
    }
}
