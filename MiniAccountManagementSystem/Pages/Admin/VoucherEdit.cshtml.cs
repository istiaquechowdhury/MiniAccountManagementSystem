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
    public class VoucherEditModel : PageModel
    {
        private readonly DatabaseHelper _db;
        public VoucherEditModel(DatabaseHelper db) => _db = db;

        [BindProperty(SupportsGet = true)]
        public int VoucherId { get; set; }

        //[BindProperty]
        //public string VoucherType { get; set; }

        //[BindProperty]
        //public DateTime VoucherDate { get; set; }

        //[BindProperty]
        //public string ReferenceNo { get; set; }

        [BindProperty(SupportsGet = true)]
        public VoucharEditModelDTO model { get; set; }


        [BindProperty]
        public List<VoucharEntryInputModelDTO> Entries { get; set; }

        
        public List<ChartOfAccountsModelDTO> Accounts { get; set; }

        public void OnGet()
        {
            // Load accounts dropdown
            Accounts = _db.GetChartOfAccounts();

            // Load existing voucher header
            var vt = _db.ExecuteStoredProcedure("sp_GetVoucherById",
                new[] { new SqlParameter("@VoucherId", VoucherId) });
            if (vt.Rows.Count == 0) RedirectToPage("/Admin/VoucherList");
            var row = vt.Rows[0];
            model.VoucherDate = (DateTime)row["VoucherDate"];
            model.ReferenceNo = row["ReferenceNo"].ToString();
            model.VoucherType = row["VoucherType"].ToString();

            // Load existing entries
            var et = _db.ExecuteStoredProcedure("sp_GetVoucherEntriesByVoucherId",
                new[] { new SqlParameter("@VoucherId", VoucherId) });
            Entries = et.Rows.Cast<DataRow>().Select(r => new VoucharEntryInputModelDTO
            {
                AccountId = (int)r["AccountId"],
                DebitAmount = (decimal)r["DebitAmount"],
                CreditAmount = (decimal)r["CreditAmount"]
            }).ToList();
        }

        public IActionResult OnPost()
        {
            // prepare TVP
            var table = new DataTable();
            table.Columns.Add("AccountId", typeof(int));
            table.Columns.Add("DebitAmount", typeof(decimal));
            table.Columns.Add("CreditAmount", typeof(decimal));
            foreach (var e in Entries)
                table.Rows.Add(e.AccountId, e.DebitAmount, e.CreditAmount);

            // build parameters
            var ps = new[]
            {
                new SqlParameter("@VoucherId", VoucherId),
                new SqlParameter("@VoucherDate", model.VoucherDate),
                new SqlParameter("@ReferenceNo", model.ReferenceNo ?? ""),
                new SqlParameter("@VoucherType", model.VoucherType ?? ""),
                new SqlParameter("@Entries", SqlDbType.Structured)
                {
                    TypeName = "dbo.VoucherEntryType",
                    Value = table
                }
            };

            _db.ExecuteNonQuery("sp_UpdateVoucher", ps);
            TempData["Success"] = "Voucher updated!";
            return RedirectToPage("/Admin/VoucharList");
        }
    }
   
}
