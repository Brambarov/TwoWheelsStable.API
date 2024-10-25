using api.DTOs.Comment;
using api.Repositories.Contracts;
using api.Services.Contracts;

namespace api.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public Task<IEnumerable<CommentGetDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
