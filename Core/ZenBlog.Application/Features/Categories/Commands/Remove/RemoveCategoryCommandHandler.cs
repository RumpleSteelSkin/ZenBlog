using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Commands.Remove;

public class RemoveCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id);
        if (category is null) return BaseResult<bool>.NotFound("Category not found");
        repository.Delete(category);
        var result = await unitOfWork.SaveChangesAsync();
        return result ? BaseResult<bool>.Success(result) : BaseResult<bool>.Fail("Category is not deleted");
    }
}