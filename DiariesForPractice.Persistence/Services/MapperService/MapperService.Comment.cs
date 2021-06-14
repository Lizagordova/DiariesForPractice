using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
     public partial class MapperService : MapperServiceBase
    {
        private void CreateCommentMappings()
        {
            AddMapping<Comment, CommentUdt>(cfg =>
            {
                cfg.CreateMap<Comment, CommentUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                    .ForMember(dest => dest.GroupId, opt => opt.Ignore())
                    .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            });
            
            AddMapping<CommentUdt, Comment>(cfg =>
            {
                cfg.CreateMap<CommentUdt, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                    .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            });
            
            AddMapping<CommentGroup, CommentGroupUdt>(cfg =>
            {
                cfg.CreateMap<CommentGroup, CommentGroupUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CommentedEntityId, opt => opt.MapFrom(src => src.CommentedEntityId))
                    .ForMember(dest => dest.CommentedEntityType, opt => opt.MapFrom(src => src.CommentedEntityType))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            });
            
            AddMapping<CommentGroupUdt, CommentGroup>(cfg =>
            {
                cfg.CreateMap<CommentGroupUdt, CommentGroup>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CommentedEntityId, opt => opt.MapFrom(src => src.CommentedEntityId))
                    .ForMember(dest => dest.CommentedEntityType, opt => opt.MapFrom(src => src.CommentedEntityType))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.Comments, opt => opt.Ignore());
            });
        }
    }
}