using AutoMapper;
using StockPlatform.Application.Common.Mappings;
using StockPlatform.Domain;
using System;

namespace StockPlatform.Application.StockPlatform.Queries.GetPhotoDetails
{
    public class PhotoDetailsVm : IMapWith<Photo>
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
            profile.CreateMap<Photo, PhotoDetailsVm>()
                .ForMember(photoVm => photoVm.Title,
                option => option.MapFrom(photo => photo.Title))
                .ForMember(photoVm => photoVm.ContentLink,
                option => option.MapFrom(photo => photo.ContentLink))
                .ForMember(photoVm => photoVm.Height,
                option => option.MapFrom(photo => photo.Width))
                .ForMember(photoVm => photoVm.Width,
                option => option.MapFrom(photo => photo.Width))
                .ForMember(photoVm => photoVm.CreationDate,
                option => option.MapFrom(photo => photo.CreationDate))
                .ForMember(photoVm => photoVm.Author,
                option => option.MapFrom(photo => photo.Author))
                .ForMember(photoVm => photoVm.Cost,
                option => option.MapFrom(photo => photo.Cost))
                .ForMember(photoVm => photoVm.NumberPurchases,
                option => option.MapFrom(photo => photo.NumberPurchases));
        }
    }
}
