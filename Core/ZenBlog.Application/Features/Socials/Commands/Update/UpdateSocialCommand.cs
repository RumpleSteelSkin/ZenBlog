using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands.Update;

public record UpdateSocialCommand : IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
    public string? Icon { get; set; }
}