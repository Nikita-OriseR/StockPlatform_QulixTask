using AutoMapper;
using StockPlatform.Application.Common.Mappings;
using StockPlatform.Application.StockPlatform.Commands.CreateText;
using StockPlatform.Domain;
using System;

namespace StockPlatform.WebApi.Models
{
    public class CreateTextDto : IMapWith<CreateTextCommand>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Size { get; set; }
        public DateTime CreationDate { get; set; }
        public double Cost { get; set; }
        public Author Author { get; set; }
        public int NumberPurchases { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTextDto, CreateTextCommand>()
                .ForMember(textCommand => textCommand.Title,
                option => option.MapFrom(photoDto => photoDto.Title))
                .ForMember(textCommand => textCommand.Content,
                option => option.MapFrom(photoDto => photoDto.Content))
                .ForMember(textCommand => textCommand.Size,
                option => option.MapFrom(photoDto => photoDto.Size))
                .ForMember(textCommand => textCommand.CreationDate,
                option => option.MapFrom(photoDto => photoDto.CreationDate))
                .ForMember(textCommand => textCommand.Author,
                option => option.MapFrom(photoDto => photoDto.Author))
                .ForMember(textCommand => textCommand.Cost,
                option => option.MapFrom(photoDto => photoDto.Cost))
                .ForMember(textCommand => textCommand.NumberPurchases,
                option => option.MapFrom(photoDto => photoDto.NumberPurchases));
        }
    }
}
