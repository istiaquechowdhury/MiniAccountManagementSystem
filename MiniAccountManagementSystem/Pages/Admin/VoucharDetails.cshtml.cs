using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;
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

        public VoucherDetailDto Voucher { get; set; }
        public List<VoucherEntryDto> Entries { get; set; }

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
            Voucher = new VoucherDetailDto
            {
                VoucherId = Id,
                VoucherDate = Convert.ToDateTime(row["VoucherDate"]),
                VoucherType = row["VoucherType"].ToString(),
                ReferenceNo = row["ReferenceNo"].ToString()
            };

            // Get voucher entries
            Entries = new List<VoucherEntryDto>();
                var entryTable = _dbHelper.ExecuteStoredProcedure(
                        "sp_GetVoucherEntriesByVoucherId",
                        new[] { new SqlParameter("@VoucherId", Id) }
                );

            foreach (DataRow entryRow in entryTable.Rows)
            {
                Entries.Add(new VoucherEntryDto
                {
                    AccountName = entryRow["AccountName"].ToString(),
                    DebitAmount = Convert.ToDecimal(entryRow["DebitAmount"]),
                    CreditAmount = Convert.ToDecimal(entryRow["CreditAmount"])
                });
            }

            return Page();
        }
    }
    public class VoucherDetailDto
    {
        public int VoucherId { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherType { get; set; }
        public string ReferenceNo { get; set; }
    }

    public class VoucherEntryDto
    {
        public string AccountName { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
    }
}
