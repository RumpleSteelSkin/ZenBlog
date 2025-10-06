using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Commands.Update;

public class UpdateContactInfoCommandHandler(
    IRepository<ContactInfo> repository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateContactInfoCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
    {
        var requested = mapper.Map<ContactInfo>(request);
        repository.Update(requested);
        var response = await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(response);
    }
}