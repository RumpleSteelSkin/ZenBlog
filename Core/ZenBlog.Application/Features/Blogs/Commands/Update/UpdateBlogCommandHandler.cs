using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Commands.Update;

public class UpdateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = mapper.Map<Blog>(request);
        repository.Update(blog);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Blog updated successfully");
    }
}