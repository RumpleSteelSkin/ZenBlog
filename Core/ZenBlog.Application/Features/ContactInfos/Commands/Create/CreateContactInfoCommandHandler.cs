using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Commands.Create;

public class CreateContactInfoCommandHandler(
    IMapper mapper,
    IRepository<ContactInfo> repository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateContactInfoCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
    {
        var requested = mapper.Map<ContactInfo>(request);
        await repository.CreateAsync(requested);
        var response = await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(response);
    }
}