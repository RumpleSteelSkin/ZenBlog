using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Commands.Remove;

public class RemoveMessageCommandHandler(IRepository<Message> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveMessageCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await repository.GetByIdAsync(request.Id);
        if (message == null) return BaseResult<object>.NotFound("Message not found");
        repository.Delete(message);
        var response = await unitOfWork.SaveChangesAsync();
        return response ? BaseResult<object>.Success(response) : BaseResult<object>.Fail("Remove message failed");
    }
}