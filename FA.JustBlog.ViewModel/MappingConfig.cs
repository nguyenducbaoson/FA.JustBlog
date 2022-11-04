using AutoMapper;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.ViewModel.CategoryViewModel;
using FA.JustBlog.ViewModel.CommentViewModel;
using FA.JustBlog.ViewModel.PostViewModel;
using FA.JustBlog.ViewModel.TagViewModel;

namespace FA.JustBlog.ViewModel
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<Post, PostVM>().ForMember(c => c.CommentId, p => p.MapFrom(c => c.Comments.Select(c => c.CommentId))).ForMember(c=>c.TagName,p=>p.MapFrom(c=>c.PostTagMaps.Select(c=>c.Tag.Name))).
                ForMember(c => c.CategoryName, p => p.MapFrom(c => c.Category.CategoryName))
                .ReverseMap();
            CreateMap<Post, PostCreateVM>().ReverseMap();
            CreateMap<Post, PostUpdateVM>().ForMember(c => c.CommentId, p => p.MapFrom(c => c.Comments.Select(c => c.CommentId))).ForMember(c => c.TagId, p => p.MapFrom(c => c.PostTagMaps.Select(c => c.TagId))).ReverseMap();

            CreateMap<Category, CategoryVM>().ForMember(c=>c.PostId, p=>p.MapFrom(c=>c.Posts.Select(c=>c.PostId))).ReverseMap();
            CreateMap<Category, CategoryUpdateVM>().ReverseMap();
            CreateMap<Category, CategoryCreateVM>().ReverseMap();

            CreateMap<Tag,TagVM>().ForMember(c => c.PostId, p => p.MapFrom(c => c.PostTagMaps.Select(c => c.PostId))).ReverseMap();
            CreateMap<Tag, TagUpdateVM>().ReverseMap();
            CreateMap<Tag, TagCreateVM>().ReverseMap();

            CreateMap<Comment, CommentVM>().ReverseMap();
            CreateMap<Comment, CommentUpdateVM>().ReverseMap();
            CreateMap<Comment, CommentCreateVM>().ReverseMap();

            CreateMap<PostVM, PostCreateVM>().ReverseMap();
            CreateMap<PostVM, PostUpdateVM>().ReverseMap();
        }
    }
}
