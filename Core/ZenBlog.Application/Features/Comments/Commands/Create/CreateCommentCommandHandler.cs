using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Commands.Create;

public class CreateCommentCommandHandler(IMapper mapper, IRepository<Comment> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var requested = mapper.Map<Comment>(request);
        await repository.CreateAsync(requested);
        var response = await unitOfWork.SaveChangesAsync();
        return response ? BaseResult<object>.Success(response) : BaseResult<object>.Fail("Failed to create comment");
    }
}