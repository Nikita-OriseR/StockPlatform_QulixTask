using AutoMapper;
using StockPlatform.Application.Common.Mappings;
using StockPlatform.Application.StockPlatform.Commands.UpdatePhoto;
using System;

namespace StockPlatform.WebApi.Models
{
    public class UpdatePhotoDto : IMapWith<UpdatePhotoCommand>
    {
        public Guid PhotoId { get; set; }
        public string Title { get; set; }
        public string ContentLink { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Cost { get; set; }
        public int NumberPurchases { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePhotoDto, UpdatePhotoCommand>()
                .ForMember(photoCommand => photoCommand.PhotoId,
                option => option.MapFrom(photoDto => photoDto.PhotoId))
                .ForMember(photoCommand => photoCommand.Title,
                option => option.MapFrom(photoDto => photoDto.Title))
                .ForMember(photoCommand => photoCommand.ContentLink,
                option => option.MapFrom(photoDto => photoDto.ContentLink))
                .ForMember(photoCommand => photoCommand.Height,
                option => option.MapFrom(photoDto => photoDto.Height))
                .ForMember(photoCommand => photoCommand.Width,
                option => option.MapFrom(photoDto => photoDto.Width))
                .ForMember(photoCommand => photoCommand.Cost,
                option => option.MapFrom(photoDto => photoDto.Cost))
                .ForMember(photoCommand => photoCommand.NumberPurchases,
                option => option.MapFrom(photoDto => photoDto.NumberPurchases));
        }
    }
}
