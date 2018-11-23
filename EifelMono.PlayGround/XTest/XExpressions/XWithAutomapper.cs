﻿using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Linq.Expressions;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;
using AutoMapper.Extensions.ExpressionMapping;

namespace EifelMono.PlayGround.XTest.XExpressions
{
    public class XWithAutoMapper : XPlayGround
    {
        private List<PersonDto1> ListOfPerson1 = new List<PersonDto1> {
            new PersonDto1 {
                Id1=1,
                Name1="Andreas Klapperich",
                Gender1= GenderDto1.Male,
                BirthDate1= new DateTime(1961,2,14),
                City1= "Rieden",
            },
            new PersonDto1 {
                Id1=2,
                Name1="Heinz Becker",
                Gender1= GenderDto1.Male,
                BirthDate1= new DateTime(1949,10,13),
                City1= "Bexbach",
            },
                new PersonDto1 {
                Id1=3,
                Name1="Hugo Egon Balder",
                Gender1= GenderDto1.Male,
                BirthDate1= new DateTime(1950,3,22),
                City1= "Köln",
            },
            new PersonDto1 {
                Id1=4,
                Name1="Alber Eintstein",
                Gender1= GenderDto1.Male,
                BirthDate1= new DateTime(1879,3,14),
                City1= "Ulm",
            },
            new PersonDto1 {
                Id1=2,
                Name1="Hilde Becker",
                Gender1= GenderDto1.Female,
                BirthDate1= new DateTime(1955,10,13),
                City1= "Bexbach"
            }
        };

        public XWithAutoMapper(ITestOutputHelper output) : base(output)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<PersonDtoMapping>();
                cfg.AddExpressionMapping();
            });
        }

        internal PersonDto1 Map(PersonDto2 persionDto2)
            => persionDto2 is null
                ? null
                : Mapper.Map<PersonDto1>(persionDto2);

        internal IEnumerable<PersonDto1> Map(IEnumerable<PersonDto2> persionDto2)
            => persionDto2 is null
                ? null
                : Mapper.Map<List<PersonDto1>>(persionDto2);

        internal PersonDto2 Map(PersonDto1 personDto1)
            => personDto1 is null
                ? null
                : Mapper.Map<PersonDto2>(personDto1);

        internal IEnumerable<PersonDto2> Map(IEnumerable<PersonDto1> personDto1)
            => personDto1 is null
                ? null
                : Mapper.Map<List<PersonDto2>>(personDto1);

        internal Expression<Func<PersonDto1, bool>> Map(Expression<Func<PersonDto2, bool>> expression2)
            => Mapper.Map<Expression<Func<PersonDto2, bool>>, Expression<Func<PersonDto1, bool>>>(expression2);

        internal Expression<Func<PersonDto2, bool>> Map(Expression<Func<PersonDto1, bool>> expression1)
            => Mapper.Map<Expression<Func<PersonDto1, bool>>, Expression<Func<PersonDto2, bool>>>(expression1);

        [Fact]
        public void TestNormalMapping()
        {
            {
                var p1 = ListOfPerson1.Where(p => p.Name1 == "Andreas Klapperich");
                Dump(p1);
                var p2 = Map(p1);
                Assert.Single(p2);
                Dump(p2);
            }
            {
                var p1 = ListOfPerson1.Where(p => p.Name1.StartsWith("H"));
                Dump(p1);
                var p2 = Map(p1);
                Assert.Equal(3, p2.Count());
                Dump(p2);
            }
            {
                var p1 = ListOfPerson1.Where(p => p.Gender1== GenderDto1.Female);
                Dump(p1);
                var p2 = Map(p1);
                Assert.Single(p2);
                Assert.Equal(GenderDto1.Female, p1.First().Gender1);
                Assert.Equal(GenderDto2.Female, p2.First().Gender2);
                Dump(p2);
            }
        }

        [Fact]
        public void TestExpressionMapHere()
        {
            Expression<Func<PersonDto2, bool>> expression2 = (p => p.Name2 == "Andreas Klaperich");

            var expression1 = Mapper
                .Map<
                    Expression<Func<PersonDto2, bool>>
                    , Expression<Func<PersonDto1, bool>>>
                    (expression2);

            var func1 = expression1.Compile();
            var p1 = ListOfPerson1.Where(func1).FirstOrDefault();
            Dump(p1);

            var p2 = Map(p1);

            Dump(p2);
        }

        [Fact]
        public void TestExpression()
        {
            {
                Expression<Func<PersonDto2, bool>> expression2 = (p => p.Name2 == "Andreas Klapperich");
                var p1 = ListOfPerson1.Where(Map(expression2).Compile());
                Dump(p1);
                var p2 = Map(p1);
                Assert.Single(p2);
                Dump(p2);
            }

            {
                Expression<Func<PersonDto2, bool>> expression2 = (p => p.Name2.StartsWith("H"));
                var p1 = ListOfPerson1.Where(Map(expression2).Compile());
                Dump(p1);
                var p2 = Map(p1);
                Assert.Equal(3, p2.Count());
                Dump(p2);
            }

            {
                Expression<Func<PersonDto2, bool>> expression2 = (p => p.Gender2 == GenderDto2.Female);
                var p1 = ListOfPerson1.Where(Map(expression2).Compile());
                Dump(p1);
                var p2 = Map(p1);
                Assert.Single(p2);
                Assert.Equal(GenderDto1.Female, p1.First().Gender1);
                Assert.Equal(GenderDto2.Female, p2.First().Gender2);
                Dump(p2);
            }
        }
    }
}
