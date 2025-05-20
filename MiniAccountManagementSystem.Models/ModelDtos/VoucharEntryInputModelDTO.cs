using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Models.ModelDtos
{
    public class VoucharEntryInputModelDTO
    {
        public int AccountId { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
    }
}
