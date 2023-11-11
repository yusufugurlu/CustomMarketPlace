using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IHubService
    {
        Task SendAll(string message);
        Task sendToList(List<string> userList, string message);
    }
}
