using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.Account
{
    public class VerifyPasswordDto
    {
        public string Password { get; set; }
        public string passwordConfirm { get; set; }
        public string GuidKey { get; set; }
    }
}
