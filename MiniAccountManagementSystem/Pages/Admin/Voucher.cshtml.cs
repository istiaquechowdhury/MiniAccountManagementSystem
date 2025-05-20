using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;
using MiniAccountManagementSystem.Models.ModelDtos;
using System.Data;

namespace MiniAccountManagementSystem.Pages.Admin
{
    [Authorize(Roles = "Accountant")]
    public class VoucherModel : PageModel
    {
        private readonly DatabaseHelper _dbHelper;

        public VoucherModel(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

    

        [BindProperty]
        public VoucharCreateModelDTO model { get; set; }        





        [BindProperty]
        public List<VoucharEntryInputModelDTO> Entries { get; set; }

        public List<ChartOfAccountsModelDTO> Accounts { get; set; }

        public void OnGet()
        {
            // Simulate loading from database
            Accounts = _dbHelper.GetChartOfAccounts(); // You need to implement this method
        }





        public IActionResult OnPost()
        {
           

            // Build DataTable for VoucherEntryType
            var table = new DataTable();
            table.Columns.Add("AccountId", typeof(int));
            table.Columns.Add("DebitAmount", typeof(decimal));
            table.Columns.Add("CreditAmount", typeof(decimal));

            foreach (var entry in Entries)
            {
                table.Rows.Add(entry.AccountId, entry.DebitAmount, entry.CreditAmount);
            }

            // Build SqlParameter array
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@VoucherDate", SqlDbType.DateTime) { Value = model.VoucherDate },
                new SqlParameter("@ReferenceNo", SqlDbType.NVarChar, 100) { Value = model.ReferenceNo ?? "" },
                new SqlParameter("@VoucherType", SqlDbType.NVarChar, 50) { Value = model.VoucherType },
                new SqlParameter("@Entries", SqlDbType.Structured)
                {
                    TypeName = "dbo.VoucherEntryType",
                    Value = table
                }
            };

            // Execute the stored procedure
            _dbHelper.ExecuteNonQuery("sp_SaveVoucher", parameters);

            TempData["Success"] = "Voucher saved successfully!";
            return RedirectToPage("/Admin/VoucharList");
        }






    }
}



