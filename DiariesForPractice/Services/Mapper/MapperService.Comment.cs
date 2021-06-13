using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Services.Mapper
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateCommentMappings()
        {
            AddMapping<CommentReadModel, Comment>(cfg =>
            {
                cfg.CreateMap<CommentReadModel, Comment>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                    .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            });
            
            AddMapping<Comment, CommentViewModel>(cfg =>
            {
                cfg.CreateMap<Comment, CommentViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                    .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            });

            AddMapping<CommentGroupReadModel, CommentGroup>(cfg =>
            {
                cfg.CreateMap<CommentGroupReadModel, CommentGroup>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CommentedEntityType, opt => opt.MapFrom(src => src.CommentedEntityType))
                    .ForMember(dest => dest.CommentedEntityId, opt => opt.MapFrom(src => src.CommentedEntityId))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.Comments, opt => opt.Ignore()); //TODO: в специальном хелпере надо прописать заполнение этого поля ИЛИ ДОПИСАТЬ ЗДЕСЬ
            });
            
            AddMapping<CommentGroup, CommentGroupViewModel>(cfg =>
            {
                cfg.CreateMap<CommentGroup, CommentGroupViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CommentedEntityType, opt => opt.MapFrom(src => src.CommentedEntityType))
                    .ForMember(dest => dest.CommentedEntityId, opt => opt.MapFrom(src => src.CommentedEntityId))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.Comments, opt => opt.Ignore()); //TODO: в специальном хелпере надо прописать заполнение этого поля ИЛИ ДОПИСАТЬ ЗДЕСЬ
            });
        }
    }
}