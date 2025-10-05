using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Commands.Create;

public class CreateSubCommentCommandHandler(IMapper mapper, IRepository<SubComment> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateSubCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateSubCommentCommand request, CancellationToken cancellationToken)
    {
        var requested = mapper.Map<SubComment>(request);
        await repository.CreateAsync(requested);
        var response = await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(response);
    }
}