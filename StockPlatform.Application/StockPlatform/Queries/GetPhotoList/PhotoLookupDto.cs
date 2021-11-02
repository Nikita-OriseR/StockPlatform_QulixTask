using AutoMapper;
using StockPlatform.Application.Common.Mappings;
using StockPlatform.Domain;
using System;

namespace StockPlatform.Application.StockPlatform.Queries.GetPhotoList
{
    public class PhotoLookupDto : IMapWith<Photo>
    {
        public Guid PhotoId { get; set; }
        public string Title { get; set; }
        public string ContentLink { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Photo, PhotoLookupDto>()
                .ForMember(photoDto => photoDto.PhotoId,
                option => option.MapFrom(photo => photo.PhotoId))
                .ForMember(photoDto => photoDto.Title,
                option => option.MapFrom(photo => photo.Title))
                .ForMember(photoDto => photoDto.ContentLink,
                option => option.MapFrom(photo => photo.ContentLink));
        }
    }
}
