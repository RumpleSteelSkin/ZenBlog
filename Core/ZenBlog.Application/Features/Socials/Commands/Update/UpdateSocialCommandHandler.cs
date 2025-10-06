using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Commands.Update;

public class UpdateSocialCommandHandler(IRepository<Social> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateSocialCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
    {
        var exist = await repository.GetByIdAsync(request.Id);
        if (exist == null) return BaseResult<object>.NotFound("Social not found");
        var response = mapper.Map(request, exist);
        repository.Update(response);
        var result = await unitOfWork.SaveChangesAsync();
        return result ? BaseResult<object>.Success(response) : BaseResult<object>.Fail("Update social failed");
    }
}