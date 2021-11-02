using AutoMapper;
using StockPlatform.Application.Common.Mappings;
using StockPlatform.Application.StockPlatform.Commands.UpdateAuthor;


namespace StockPlatform.WebApi.Models
{
    public class UpdateAuthorDto : IMapWith<UpdateAuthorCommand>
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorDto, UpdateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Name,
                option => option.MapFrom(photoDto => photoDto.Name))
                .ForMember(authorCommand => authorCommand.Nickname,
                option => option.MapFrom(photoDto => photoDto.Nickname))
                .ForMember(authorCommand => authorCommand.Age,
                option => option.MapFrom(photoDto => photoDto.Age));
        }
    }
}
