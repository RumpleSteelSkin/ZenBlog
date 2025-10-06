using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands.Create;

public class CreateContactInfoCommand : IRequest<BaseResult<object>>
{
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? MapUrl { get; set; }
}