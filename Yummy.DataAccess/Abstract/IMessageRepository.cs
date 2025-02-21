using Yummy.Entity.Entities;

namespace Yummy.DataAccess.Abstract
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task MarkMessageAsRead(int id);
        Task MarkMessageAsUnread(int id);
    }
}