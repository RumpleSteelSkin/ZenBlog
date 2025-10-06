using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Commands.Create;

public class CreateSocialCommandHandler(IMapper mapper, IRepository<Social> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateSocialCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
    {
        var requested = mapper.Map<Social>(request);
        await repository.CreateAsync(requested);
        var response = await unitOfWork.SaveChangesAsync();
        return response ? BaseResult<object>.Success(response) : BaseResult<object>.Fail("Failed to create social");
    }
}