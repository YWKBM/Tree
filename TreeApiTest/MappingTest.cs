using System.Reflection;
using NUnit.Framework;
using AutoMapper;

namespace TreeApiTest;

public class MappingTest
{
    [Test]
    public void AutoMapperConfigurationIsValid()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(TreeApi.Mapping.TreeMapping).Assembly);
        });
        configuration.AssertConfigurationIsValid();
    }
}