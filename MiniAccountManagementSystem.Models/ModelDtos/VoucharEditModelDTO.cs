using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Models.ModelDtos
{
    public class VoucharEditModelDTO
    {

        [Required]
        public int VoucherId { get; set; }

        [Required]
        public string VoucherType { get; set; }

        [Required(ErrorMessage = "Voucher date is required")]
        public DateTime VoucherDate { get; set; }

        public string ReferenceNo { get; set; }

        [MinLength(1, ErrorMessage = "At least one voucher entry is required")]
        public List<VoucharEntryInputModelDTO> Entries { get; set; } = new();
    }
}
