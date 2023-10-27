using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.SelectedUser
{
    public class SelectedWorkplaceDto
    {
        public int CompanyId { get; set; }
        public int WorkplaceId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string WorkplaceName { get; set; }
    }
}
