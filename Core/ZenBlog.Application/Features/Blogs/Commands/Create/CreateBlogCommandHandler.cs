using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Commands.Create;

public class CreateBlogCommandHandler(IRepository<Blog> repository, IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateBlogCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = mapper.Map<Blog>(request);
        await repository.CreateAsync(blog);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(blog);
    }
}