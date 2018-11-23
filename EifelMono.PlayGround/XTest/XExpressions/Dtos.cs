using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace EifelMono.PlayGround.XTest.XExpressions
{
    public enum StateDto1
    {
        None,
        Rlp,
        Nrw,
        Sar,
        Bay,
    }
    public class PersonDto1
    {
        public int Id1 { get; set; }
        public string Name1 { get; set; }

        public int Gender1 { get; set; } = 0;
        public string City1 { get; set; }

        public DateTime BirthDate1 { get; set; } = DateTime.MinValue;

        public StateDto1 State1 { get; set; } = StateDto1.None;

        public override string ToString()
            => $"{Id1} {Name1} {Gender1} {City1} {BirthDate1.ToString("yyyyMMdd")} {State1}";
    }

    public enum GenderDto2
    {
        Neutral = 0,
        Male = 1,
        Female = 2
    }

    public enum StateDto2
    {
        None,
        Rlp,
        Nrw,
        Sar,
        Bay,
    }

    public class PersonDto2
    {
        public int Id2 { get; set; }
        public string Name2 { get; set; }

        public GenderDto2 Gender2 { get; set; } = GenderDto2.Neutral;
        public string City2 { get; set; }

        public DateTime BirthDate2 { get; set; } = DateTime.MinValue;

        public StateDto2 State2 { get; set; } = StateDto2.None;

        public override string ToString()
            => $"{Id2} {Name2} {Gender2} {City2} {BirthDate2.ToString("yyyyMMdd")} {State2}";
    }

    internal class PersonDtoMapping : Profile
    {
        public PersonDtoMapping()
        {
            CreateMap<PersonDto1, PersonDto2>()
                .ForMember(dest => dest.Id2, opt => opt.MapFrom(src => src.Id1))
                .ForMember(dest => dest.Name2, opt => opt.MapFrom(src => src.Name1))
                .ForMember(dest => dest.Gender2, opt => opt.MapFrom(src => (GenderDto2)src.Gender1))
                .ForMember(dest => dest.City2, opt => opt.MapFrom(src => src.City1))
                .ForMember(dest => dest.BirthDate2, opt => opt.MapFrom(src => src.BirthDate1))
                .ForMember(dest => dest.State2, opt => opt.MapFrom(src => src.State1))
                .ReverseMap()
                .ForMember(dest => dest.Id1, opt => opt.MapFrom(src => src.Id2))
                .ForMember(dest => dest.Name1, opt => opt.MapFrom(src => src.Name2))
                .ForMember(dest => dest.Gender1, opt => opt.MapFrom(src => src.Gender2))
                .ForMember(dest => dest.City1, opt => opt.MapFrom(src => src.City2))
                .ForMember(dest => dest.BirthDate1, opt => opt.MapFrom(src => src.BirthDate2))
                .ForMember(dest => dest.State1, opt => opt.MapFrom(src => src.State2));

            CreateMap<StateDto1, StateDto2>()
                .ReverseMap();
        }
    }
}