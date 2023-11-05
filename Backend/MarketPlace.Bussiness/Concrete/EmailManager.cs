using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.ServiceResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    var htmlContent = $@"<!DOCTYPE html><html><body style=""font-family: Arial, sans-serif; text-align: center;""><div style=""background-color: #f9f9f9; padding: 20px; border-radius: 5px; width: 50%; margin: 0 auto; margin-top: 50px;""><h2>ŞİFRE SIFIRLAMA</h2><p>Merhaba,</p><p>Şifrenizi sıfırlamak için aşağıdaki bağlantıyı tıklayın:</p><a href=""{fullPath}"" style=""display: inline-block; padding: 10px 20px; background-color: #4CAF50; color: white; text-decoration: none; border-radius: 5px; margin-top: 20px;"">Şifre Sıfırlama</a><p style=""margin-top: 20px;"">Eğer şifreyi sıfırlamak istemediyseniz, bu e-postayı dikkate almayınız.</p><p style='margin-top: 20px;'>İletişim için websitemiz <a href='http://www.example.com' target='_blank'>www.example.com</a> adresini ziyaret edebilir veya bize ulaşmak için 123 456 78 90 numaralı telefonu arayabilirsiniz.</p></div></body></html>";
                    mail.Body = HttpUtility.HtmlDecode(htmlContent);

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
