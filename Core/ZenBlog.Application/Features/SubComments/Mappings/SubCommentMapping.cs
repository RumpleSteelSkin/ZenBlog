using AutoMapper;
using ZenBlog.Application.Features.SubComments.Commands.Create;
using ZenBlog.Application.Features.SubComments.Queries.GetAllSubComments;
using ZenBlog.Application.Features.SubComments.Queries.GetSubCommentById;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Mappings;

public class SubCommentMapping : Profile
{
    public SubCommentMapping()
    {
        CreateMap<CreateSubCommentCommand, SubComment>();
        CreateMap<SubComment, GetAllSubCommentsQueryResponseDto>();
        CreateMap<SubComment, GetSubCommentByIdQueryResponseDto>();
    }
}