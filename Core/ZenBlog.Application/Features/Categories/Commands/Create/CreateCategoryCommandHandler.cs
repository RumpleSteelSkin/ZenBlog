using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request);
        await repository.CreateAsync(category);
        var result = await unitOfWork.SaveChangesAsync();
        return result ? BaseResult<bool>.Success(result) : BaseResult<bool>.Fail();
    }
}