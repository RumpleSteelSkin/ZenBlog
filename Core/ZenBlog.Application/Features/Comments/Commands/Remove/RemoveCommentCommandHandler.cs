using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Commands.Remove;

public class RemoveCommentCommandHandler(IRepository<Comment> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await repository.GetByIdAsync(request.Id);
        if (comment is null) return BaseResult<object>.Fail("Comment not found");
        repository.Delete(comment);
        var response = await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(response);
    }
}