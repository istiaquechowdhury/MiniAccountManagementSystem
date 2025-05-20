using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Models.ModelDtos
{
    public class ChartOfAccountsModelDTO
    {
       
        public int? AccountId { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public string AccountCode { get; set; }

       
        public int? ParentAccountId { get; set; }
    }
}
