using AutoMapper;
using BasicXCloneBackend.Application.DTOs;
using BasicXCloneBackend.Application.RequestModels;
using BasicXCloneBackend.Domain.Entities;

namespace BasicXCloneBackend.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Post, PostDTO>();
        CreateMap<Post, PostDTO>().ReverseMap();
        CreateMap<Repost, RepostDTO>();
        CreateMap<Repost, RepostDTO>().ReverseMap();
        CreateMap<Record, RecordDTO>();
        CreateMap<Record, RecordDTO>().ReverseMap();
        CreateMap<Post, Record>();
        CreateMap<Post, Record>().ReverseMap();
        CreateMap<PostDTO, RecordDTO>();
        CreateMap<PostDTO, RecordDTO>().ReverseMap();
        CreateMap<CreateNewPostRequest, PostDTO>();
        CreateMap<CreateNewRepostRequest, RepostDTO>();
    }
}

