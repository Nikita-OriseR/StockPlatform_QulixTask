using AutoMapper;
using StockPlatform.Application.Common.Mappings;
using StockPlatform.Domain;
using System;

namespace StockPlatform.Application.StockPlatform.Queries.GetEntityList
{
    public class EntitiesLookupDto : IMapWith<Author>, IMapWith<Photo>, IMapWith<Text>
    {
        public Guid AuthorId { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public Guid PhotoId { get; set; }

        public string PhotoTitle { get; set; }

        public string ContentLink { get; set; }

        public Guid TextId { get; set; }

        public string TextTitle { get; set; }

        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, EntitiesLookupDto>()
                .ForMember(authorDto => authorDto.AuthorId,
                option => option.MapFrom(author => author.AuthorId))
                .ForMember(authorDto => authorDto.Name,
                option => option.MapFrom(author => author.Name))
                .ForMember(authorDto => authorDto.Nickname,
                option => option.MapFrom(author => author.Nickname));

            profile.CreateMap<Photo, EntitiesLookupDto>()
                .ForMember(photoDto => photoDto.PhotoId,
                option => option.MapFrom(photo => photo.PhotoId))
                .ForMember(photoDto => photoDto.PhotoTitle,
                option => option.MapFrom(photo => photo.Title))
                .ForMember(photoDto => photoDto.ContentLink,
                option => option.MapFrom(photo => photo.ContentLink));

            profile.CreateMap<Text, EntitiesLookupDto>()
                .ForMember(textDto => textDto.TextId,
                option => option.MapFrom(text => text.TextId))
                .ForMember(textDto => textDto.TextTitle,
                option => option.MapFrom(text => text.Title))
                .ForMember(textDto => textDto.Content,
                option => option.MapFrom(text => text.Content));
        }
    }
}
