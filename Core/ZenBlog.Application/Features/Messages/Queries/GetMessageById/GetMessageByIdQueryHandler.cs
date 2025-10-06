using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Queries.GetMessageById;

public class GetMessageByIdQueryHandler(IRepository<Message> repository, IMapper mapper)
    : IRequestHandler<GetMessageByIdQuery, BaseResult<GetMessageByIdQueryResponseDto>>
{
    public async Task<BaseResult<GetMessageByIdQueryResponseDto>> Handle(GetMessageByIdQuery request,
        CancellationToken cancellationToken)
    {
        var message = await repository.GetByIdAsync(request.Id);
        var dto = mapper.Map<GetMessageByIdQueryResponseDto>(message);
        return BaseResult<GetMessageByIdQueryResponseDto>.Success(dto);
    }
}