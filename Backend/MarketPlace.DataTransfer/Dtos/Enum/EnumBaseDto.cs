using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DataTransfer.Dtos.Enum
{
    public class EnumBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EnumBaseDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
