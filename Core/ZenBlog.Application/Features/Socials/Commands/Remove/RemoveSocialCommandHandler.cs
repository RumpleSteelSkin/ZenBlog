using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Commands.Remove;

public class RemoveSocialCommandHandler(IRepository<Social> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveSocialCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveSocialCommand request, CancellationToken cancellationToken)
    {
        var social = await repository.GetByIdAsync(request.Id);
        if (social == null) return BaseResult<object>.NotFound("Social not found");
        repository.Delete(social);
        var response = await unitOfWork.SaveChangesAsync();
        return response ? BaseResult<object>.Success(response) : BaseResult<object>.Fail("Remove social failed");
    }
}