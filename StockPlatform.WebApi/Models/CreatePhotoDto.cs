using AutoMapper;
using StockPlatform.Application.Common.Mappings;
using StockPlatform.Application.StockPlatform.Commands.CreatePhoto;
using StockPlatform.Domain;
using System;

namespace StockPlatform.WebApi.Models
{
    public class CreatePhotoDto : IMapWith<CreatePhotoCommand>
    {
        public string Title { get; set; }
        public string ContentLink { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public DateTime CreationDate { get; set; }
        public Author Author { get; set; }
        public double Cost { get; set; }
        public int NumberPurchases { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePhotoDto, CreatePhotoCommand>()
                .ForMember(photoCommand => photoCommand.Title,
                option => option.MapFrom(photoDto => photoDto.Title))
                .ForMember(photoCommand => photoCommand.ContentLink,
                option => option.MapFrom(photoDto => photoDto.ContentLink))
                .ForMember(photoCommand => photoCommand.Height,
                option => option.MapFrom(photoDto => photoDto.Height))
                .ForMember(photoCommand => photoCommand.Width,
                option => option.MapFrom(photoDto => photoDto.Width))
                .ForMember(photoCommand => photoCommand.CreationDate,
                option => option.MapFrom(photoDto => photoDto.CreationDate))
                .ForMember(photoCommand => photoCommand.Author,
                option => option.MapFrom(photoDto => photoDto.Author))
                .ForMember(photoCommand => photoCommand.Cost,
                option => option.MapFrom(photoDto => photoDto.Cost))
                .ForMember(photoCommand => photoCommand.NumberPurchases,
                option => option.MapFrom(photoDto => photoDto.NumberPurchases));
        }
    }
}
