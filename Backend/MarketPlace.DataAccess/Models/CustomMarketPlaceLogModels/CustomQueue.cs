using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Common.Enums;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels
{
    public class CustomQueue
    {
        public CustomQueue()
        {
            QueueHistories = new HashSet<QueueHistory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public IntegrationType IntegrationType { get; set; }
        public QueueActionType QueueActionType { get; set; }
        public QueueProcessType QueueProcessType { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<QueueHistory> QueueHistories { get; set; }

    }
}
