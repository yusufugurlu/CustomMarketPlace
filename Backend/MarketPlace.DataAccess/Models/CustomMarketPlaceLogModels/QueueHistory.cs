using MarketPlace.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataAccess.Models.CustomMarketPlaceLogModels
{
    public class QueueHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int QueueId { get; set; }
        public QueueProcessType QueueProcessType { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Queue Queue { get; set; }
    }
}
