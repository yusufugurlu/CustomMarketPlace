using MarketPlace.DataTransfer.Dtos.Enum;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IEnumService
    {
        Task<List<EnumBaseDto>> GetRoles();
    }
}
