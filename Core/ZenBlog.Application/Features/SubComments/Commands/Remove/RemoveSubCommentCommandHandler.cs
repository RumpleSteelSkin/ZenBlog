using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Commands.Remove;

public class RemoveSubCommentCommandHandler(IRepository<SubComment> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveSubCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveSubCommentCommand request, CancellationToken cancellationToken)
    {
        var subComment = await repository.GetByIdAsync(request.Id);
        if (subComment is null) return BaseResult<object>.NotFound("SubComment not found");
        repository.Delete(subComment);
        var response = await unitOfWork.SaveChangesAsync();
        return response
            ? BaseResult<object>.Success("SubComment deleted")
            : BaseResult<object>.Fail("SubComment not deleted");
    }
}