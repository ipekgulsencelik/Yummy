using Yummy.Business.Abstract;
using Yummy.DataAccess.Abstract;
using Yummy.Entity.Entities;

namespace Yummy.Business.Concrete
{
    public class MessageManager : GenericManager<Message>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageManager(IRepository<Message> _repository, IMessageRepository messageRepository) : base(_repository)
        {
            _messageRepository = messageRepository;
        }

        public async Task TMarkMessageAsRead(int id)
        {
            await _messageRepository.MarkMessageAsRead(id);
        }

        public async Task TMarkMessageAsUnread(int id)
        {
            await _messageRepository.MarkMessageAsUnread(id);
        }
    }
}