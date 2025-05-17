using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;
using System.Data;

namespace MiniAccountManagementSystem.Pages.Admin
{
    [Authorize(Roles = "Accountant")]
    public class ChartOfAccountsModel : PageModel
    {
        private readonly DatabaseHelper _db;

        public ChartOfAccountsModel(DatabaseHelper db)
        {
            _db = db;
        }

        [BindProperty]
        public int? AccountId { get; set; }

        [BindProperty]
        public string AccountName { get; set; }

        [BindProperty]
        public string AccountCode { get; set; }

        [BindProperty]
        public int? ParentAccountId { get; set; }

        public List<SelectListItem> ParentAccounts { get; set; }

        public DataTable AccountsTable { get; set; }

        public void OnGet()
        {
            LoadParentAccounts();
            LoadAccounts();
        }

        public IActionResult OnPostInsert()
        {
            if (!ModelState.IsValid)
            {
                LoadParentAccounts();
                LoadAccounts();
                return Page();
            }

            var sqlParams = new[]
            {
                new SqlParameter("@Mode", "Insert"),
                new SqlParameter("@AccountName", AccountName),
                new SqlParameter("@ParentAccountId", (object?)ParentAccountId ?? DBNull.Value),
                new SqlParameter("@AccountCode", AccountCode)
            };

            _db.ExecuteStoredProcedure("sp_ManageChartOfAccounts", sqlParams);

            TempData["Success"] = "Account inserted successfully!";
            return RedirectToPage("/Admin/ChartOfAccounts");
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid || AccountId == null)
            {
                LoadParentAccounts();
                LoadAccounts();
                return Page();
            }

            var sqlParams = new[]
            {
                new SqlParameter("@Mode", "Update"),
                new SqlParameter("@AccountId", AccountId),
                new SqlParameter("@AccountName", AccountName),
                new SqlParameter("@ParentAccountId", (object?)ParentAccountId ?? DBNull.Value),
                new SqlParameter("@AccountCode", AccountCode)
            };

            _db.ExecuteStoredProcedure("sp_ManageChartOfAccounts", sqlParams);

            TempData["Success"] = "Account updated successfully!";
            return RedirectToPage("/Admin/ChartOfAccounts");
        }

        public IActionResult OnPostDelete(int id)
        {
            var sqlParams = new[]
            {
                new SqlParameter("@Mode", "Delete"),
                new SqlParameter("@AccountId", id)
            };

            _db.ExecuteStoredProcedure("sp_ManageChartOfAccounts", sqlParams);

            TempData["Success"] = "Account deleted successfully!";
            return RedirectToPage("/Admin/ChartOfAccounts");
        }

        private void LoadParentAccounts()
        {
            ParentAccounts = new List<SelectListItem>();
            var table = _db.ExecuteStoredProcedure("sp_GetChartOfAccounts");

            foreach (DataRow row in table.Rows)
            {
                ParentAccounts.Add(new SelectListItem
                {
                    Value = row["AccountId"].ToString(),
                    Text = row["AccountName"].ToString()
                });
            }
        }

        private void LoadAccounts()
        {
            AccountsTable = _db.ExecuteStoredProcedure("sp_GetChartOfAccounts");
        }

        

       

    }
}
