using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message, Guid id);
        Task SendEmailAsync(Message message , Guid id);

        Task SendEmailAsyncToCustomerWithBookingDetails(Message message, Guid id);
        Task SendEmailAsyncToCustomer(Message message);

        Task SendEmailAsyncToCustomerNotConfirmedBooking(Message message , string Comment, string CustomerEmail);
    }
}
