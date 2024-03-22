namespace HD_Support_API.Repositorios.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email,string subject,string menssagem);
    }
}
