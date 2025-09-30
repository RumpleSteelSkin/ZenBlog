using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(IMapper mapper, IRepository<Category> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request);
        repository.Update(category);
        var response = await unitOfWork.SaveChangesAsync();
        return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Could not update category");
    }
}