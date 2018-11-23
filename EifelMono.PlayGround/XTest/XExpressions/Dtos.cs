using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace EifelMono.PlayGround.XTest.XExpressions
{
    public class PersonDto1
    {
        public int Id1 { get; set; }
        public string Name1 { get; set; }

        public GenderDto1 Gender1 { get; set; } = GenderDto1.Neutral;
        public string City1 { get; set; }

        public DateTime BirthDate1 { get; set; } = DateTime.MinValue;
    }

    public enum GenderDto1
    {
        Neutral,
        Male,
        Female
    }


    public class PersonDto2
    {
        public int Id2 { get; set; }
        public string Name2 { get; set; }

        public GenderDto2 Gender2 { get; set; } = GenderDto2.Neutral;
        public string City2 { get; set; }

        public DateTime BirthDate2 { get; set; } = DateTime.MinValue;
    }

    public enum GenderDto2
    {
        Neutral,
        Male,
        Female
    }

    internal class PersonDtoMapping : Profile
    {
        public PersonDtoMapping()
        {
            CreateMap<PersonDto1, PersonDto2>()
                .ForMember(dest => dest.Id2, opt => opt.MapFrom(src => src.Id1))
                .ForMember(dest => dest.Name2, opt => opt.MapFrom(src => src.Name1))
                .ForMember(dest => dest.Gender2, opt => opt.MapFrom(src => src.Gender1))
                .ForMember(dest => dest.City2, opt => opt.MapFrom(src => src.City1))
                .ForMember(dest => dest.BirthDate2, opt => opt.MapFrom(src => src.BirthDate1))
                .ReverseMap()
                .ForMember(dest => dest.Id1, opt => opt.MapFrom(src => src.Id2))
                .ForMember(dest => dest.Name1, opt => opt.MapFrom(src => src.Name2))
                .ForMember(dest => dest.Gender1, opt => opt.MapFrom(src => src.Gender2))
                .ForMember(dest => dest.City1, opt => opt.MapFrom(src => src.City2))
                .ForMember(dest => dest.BirthDate1, opt => opt.MapFrom(src => src.BirthDate2));
            CreateMap<GenderDto1, GenderDto2>()
              .ReverseMap();
        }
    }

   
}
