using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Commands.Remove;

public class RemoveContactInfoCommandHandler(IRepository<ContactInfo> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveContactInfoCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
    {
        var contactInfo = await repository.GetByIdAsync(request.Id);
        if (contactInfo is null) return BaseResult<object>.NotFound("Contact info not found");
        repository.Delete(contactInfo);
        var response = await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(response);
    }
}