using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Models.ModelDtos
{
    public class VoucharCreateModelDTO
    {
        [Required]
        public string VoucherType { get; set; }

        [Required]
        public DateTime VoucherDate { get; set; }

       
        public string ReferenceNo { get; set; }
    }
}
