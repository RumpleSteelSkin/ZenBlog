using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Commands.Update;

public class UpdateSubCommentCommandHandler(IMapper mapper, IRepository<SubComment> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateSubCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateSubCommentCommand request, CancellationToken cancellationToken)
    {
        var existing = await repository.GetByIdAsync(request.Id);
        var requested = mapper.Map(request, existing);
        if (requested != null) repository.Update(requested);
        var response = await unitOfWork.SaveChangesAsync();
        return response ? BaseResult<object>.Success(response) : BaseResult<object>.Fail("Failed to update comment");
    }
}