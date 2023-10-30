using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Email;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MarketPlace.Bussiness.Concrete
{
    public class EmailManager : IEmailService
    {

        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IConfiguration _config;

        public EmailManager(IUnitOfWorks unitOfWorks, IConfiguration config)
        {

            _unitOfWorks = unitOfWorks;
            _config = config;
            _userRepository = _unitOfWorks.GetGenericRepository<User>();
        }

        public async Task<ServiceResult> SendEmailForPasswordRecovery(int userId, string guidKey)
        {
            var user = await _userRepository.Get(userId);
            var path = _config["FrontEndUrl:DebugConnection"]?.ToString() ?? "";
            string fullPath = path + "/reset-password?Guid=" + guidKey;
            try
            {
                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    var mail = new MailMessage
                    {
                        From = new MailAddress(user.Email, "Notification"),
                        Subject = "Şifre Yenileme",
                    };

                    mail.To.Add(user.Email);

                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;

                    mail.Body = HttpUtility.HtmlDecode("<html><body><h3>URL: <a href='" + fullPath + "'> Şifre yenile</a> <H3></body></html>");

                    //Şifreyi ikili doğrulamaya açıp mail seçilip oradan application password alınmalıdır.
                    client.Credentials = new System.Net.NetworkCredential("yussuf.ugurluu@gmail.com", "iaujhttedztiipwc");
                    client.EnableSsl = true;
                    client.Port = 587;
                    client.Send(mail);

                }
            }
            catch (Exception ex)
            {
            }

            return Result.Fail();
        }
    }
}
