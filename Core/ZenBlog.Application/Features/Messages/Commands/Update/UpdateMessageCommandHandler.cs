using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Commands.Update;

public class UpdateMessageCommandHandler(IRepository<Message> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateMessageCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var exist = await repository.GetByIdAsync(request.Id);
        if (exist == null) return BaseResult<object>.NotFound("Message not found");
        var response = mapper.Map(request, exist);
        repository.Update(response);
        var result = await unitOfWork.SaveChangesAsync();
        return result ? BaseResult<object>.Success(response) : BaseResult<object>.Fail("Update message failed");
    }
}