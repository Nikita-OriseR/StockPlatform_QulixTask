using AutoMapper;
using StockPlatform.Application.Common.Mappings;
using StockPlatform.Application.StockPlatform.Commands.UpdateText;

namespace StockPlatform.WebApi.Models
{
    public class UpdateTextDto : IMapWith<UpdateTextCommand>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Size { get; set; }
        public double Cost { get; set; }
        public int NumberPurchases { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTextDto, UpdateTextCommand>()
                .ForMember(textCommand => textCommand.Title,
                option => option.MapFrom(photoDto => photoDto.Title))
                .ForMember(textCommand => textCommand.Content,
                option => option.MapFrom(photoDto => photoDto.Content))
                .ForMember(textCommand => textCommand.Size,
                option => option.MapFrom(photoDto => photoDto.Size))
                .ForMember(textCommand => textCommand.Cost,
                option => option.MapFrom(photoDto => photoDto.Cost))
                .ForMember(textCommand => textCommand.NumberPurchases,
                option => option.MapFrom(photoDto => photoDto.NumberPurchases));
        }
    }
}
