using SpecialTask.Persistance.Dtos.Notifactions;

namespace SpecialTask.Service.Interfaces.Notifactions
{
    public interface ISmsSender
    {
        public Task<bool> SendAsync(SmsMessage smsMessage);
    }
}
