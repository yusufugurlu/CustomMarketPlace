using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.UserPasswordRecovery
{
    public class UserPasswordRecoveryDto
    {
        public int UserId { get; set; }
        public bool IsUsed { get; set; }
        public string? GuidKey { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
