using MarketPlace.DataTransfer.Dtos.Email;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Abstract
{
    public interface IEmailService
    {
        Task<ServiceResult> SendEmailForPasswordRecovery(int userId, string guidKey);
    }
}
