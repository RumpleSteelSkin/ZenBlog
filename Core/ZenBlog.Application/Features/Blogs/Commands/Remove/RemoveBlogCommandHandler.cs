using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Commands.Remove;

public class RemoveBlogCommandHandler(IRepository<Blog> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveBlogCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await repository.GetByIdAsync(request.Id);
        if (blog == null) return BaseResult<bool>.NotFound("Blog not found");
        repository.Delete(blog);
        var result = await unitOfWork.SaveChangesAsync();
        return result ? BaseResult<bool>.Success(true) : BaseResult<bool>.Fail("Blog not deleted");
    }
}