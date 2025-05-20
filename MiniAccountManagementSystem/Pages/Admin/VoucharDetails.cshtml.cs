using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;
using MiniAccountManagementSystem.Models.ModelDtos;
using System.Data;

namespace MiniAccountManagementSystem.Pages.Admin
{
    [Authorize(Roles = "Accountant,Viewer")]
    public class VoucharDetailsModel : PageModel
    {
        private readonly DatabaseHelper _dbHelper;

        public VoucharDetailsModel(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty(SupportsGet = true)]  
        public VoucharDetailsModelDTO modelDTO { get; set; }    

        public VoucharDetailsModelDTO Voucher { get; set; }
        public List<VoucharDetailsModelDTO> Entries { get; set; }

        public IActionResult OnGet()
        {
            // Get voucher header
            var voucherTable = _dbHelper.ExecuteStoredProcedure(
                "sp_GetVoucherById",
                new[] { new SqlParameter("@VoucherId", Id) }
            );

            if (voucherTable.Rows.Count == 0)
            {
                return NotFound();
            }

            var row = voucherTable.Rows[0];
            Voucher = new VoucharDetailsModelDTO()
            {
                VoucherId = Id,
                VoucherDate = Convert.ToDateTime(row["VoucherDate"]),
                VoucherType = row["VoucherType"].ToString(),
                ReferenceNo = row["ReferenceNo"].ToString()
            };

            // Get voucher entries
            Entries = new List<VoucharDetailsModelDTO>();
                var entryTable = _dbHelper.ExecuteStoredProcedure(
                        "sp_GetVoucherEntriesByVoucherId",
                        new[] { new SqlParameter("@VoucherId", Id) }
                );

            foreach (DataRow entryRow in entryTable.Rows)
            {
                Entries.Add(new VoucharDetailsModelDTO
                {
                    AccountName = entryRow["AccountName"].ToString(),
                    DebitAmount = Convert.ToDecimal(entryRow["DebitAmount"]),
                    CreditAmount = Convert.ToDecimal(entryRow["CreditAmount"])
                });
            }

            return Page();
        }
    }
   

    
}
