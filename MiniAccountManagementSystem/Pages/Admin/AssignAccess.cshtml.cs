using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;
using MiniAccountManagementSystem.Models.ModelDtos;
using System.Data;

namespace MiniAccountManagementSystem.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AssignAccessModel : PageModel
    {
        private readonly DatabaseHelper _db;

        public AssignAccessModel(DatabaseHelper db)
        {
            _db = db;
        }
        [BindProperty]  
        public AssignAccessModelDTO model { get; set; } 
       
        public List<SelectListItem> Roles { get; set; }
       
        public List<SelectListItem> Modules { get; set; }


        public void OnGet()
        {
            LoadRoles();
            LoadModules();  
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadRoles();
                LoadModules();
                return Page();
            }

            var sqlParams = new[]
            {
                new SqlParameter("@RoleId", model.RoleId),
                new SqlParameter("@ModuleId", model.ModuleId),  
                new SqlParameter("@CanView", model.CanView),
                new SqlParameter("@CanEdit", model.CanEdit)
            };

            _db.ExecuteStoredProcedure("AssignModuleAccessToRole", sqlParams); 

            TempData["Success"] = "Access assigned successfully!";
            return RedirectToPage("/Admin/AssignAccess");
        }

        private void LoadRoles()
        {
            Roles = new List<SelectListItem>();
            DataTable rolesTable = _db.ExecuteStoredProcedure("GetRoles");

            foreach (DataRow row in rolesTable.Rows)
            {
                Roles.Add(new SelectListItem
                {
                    Value = row["RoleId"].ToString(),
                    Text = row["RoleName"].ToString()
                });
            }
        }

        private void LoadModules()
        {
            Modules = new List<SelectListItem>();
            DataTable modulesTable = _db.ExecuteStoredProcedure("GetModules");

            foreach (DataRow row in modulesTable.Rows)
            {
                Modules.Add(new SelectListItem
                {
                    Value = row["ModuleId"].ToString(),
                    Text = row["ModuleName"].ToString()
                });
            }
        }
    }
}
