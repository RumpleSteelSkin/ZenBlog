using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Commands.Create;

public class CreateMessageCommandHandler(IMapper mapper, IRepository<Message> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateMessageCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var requested = mapper.Map<Message>(request);
        await repository.CreateAsync(requested);
        var response = await unitOfWork.SaveChangesAsync();
        return response ? BaseResult<object>.Success(response) : BaseResult<object>.Fail("Failed to create message");
    }
}