using AutoMapper;
using StockPlatform.Application.Common.Mappings;
using StockPlatform.Application.StockPlatform.Commands.CreateAuthor;
using System;

namespace StockPlatform.WebApi.Models
{
    public class CreateAuthorDto : IMapWith<CreateAuthorCommand>
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public DateTime AccountСreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorDto, CreateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Name,
                option => option.MapFrom(photoDto => photoDto.Name))
                .ForMember(authorCommand => authorCommand.Nickname,
                option => option.MapFrom(photoDto => photoDto.Nickname))
                .ForMember(authorCommand => authorCommand.Age,
                option => option.MapFrom(photoDto => photoDto.Age))
                .ForMember(authorCommand => authorCommand.AccountСreationDate,
                option => option.MapFrom(photoDto => photoDto.AccountСreationDate));
        }
    }
}
