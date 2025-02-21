using Yummy.Entity.Entities;

namespace Yummy.Business.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        Task TMarkMessageAsRead(int id);
        Task TMarkMessageAsUnread(int id);
    }
}