using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.DataAccess;
using System.Data;

namespace MiniAccountManagementSystem.Pages.Admin
{
    public class VoucharListModel : PageModel
    {
        private readonly DatabaseHelper _dbHelper;

        public VoucharListModel(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<VoucherListDto> Vouchers { get; set; }

        public void OnGet()
        {
            Vouchers = new List<VoucherListDto>();

            var table = _dbHelper.ExecuteStoredProcedure("sp_GetVoucherList");

            foreach (DataRow row in table.Rows)
            {
                Vouchers.Add(new VoucherListDto
                {
                    VoucherId = Convert.ToInt32(row["VoucherId"]),
                    VoucherDate = Convert.ToDateTime(row["VoucherDate"]),
                    ReferenceNo = row["ReferenceNo"].ToString(),
                    VoucherType = row["VoucherType"].ToString()
                });
            }
        }
        public IActionResult OnPostDelete(int id)
        {
            var param = new SqlParameter("@VoucherId", id);
            _dbHelper.ExecuteNonQuery("sp_DeleteVoucher", new[] { param });

            TempData["Success"] = "Voucher deleted successfully!";
            return RedirectToPage(); // refresh list
        }
        public class VoucherListDto
        {
            public int VoucherId { get; set; }
            public DateTime VoucherDate { get; set; }
            public string ReferenceNo { get; set; }
            public string VoucherType { get; set; }
        }
    }
}
