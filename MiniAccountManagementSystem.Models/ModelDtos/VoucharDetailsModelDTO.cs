namespace MiniAccountManagementSystem.Models.ModelDtos
{
    public class VoucharDetailsModelDTO
    {
       
        public int VoucherId { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherType { get; set; }
        public string ReferenceNo { get; set; }
        public string AccountName { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
    }
}
