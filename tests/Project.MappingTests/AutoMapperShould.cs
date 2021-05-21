using System;
using AutoMapper;
using Proj2Aalst_G3.Data.Mappers;
using Proj2Aalst_G3.Services.Toornament;
using Xunit;

namespace Project.MappingTests
{
    public class AutoMapperShould
    {
        [Fact]
        public void MapModelsCorrectly()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ToornamentProfile>();
            });
            
            configuration.AssertConfigurationIsValid();
        }
    }
}
