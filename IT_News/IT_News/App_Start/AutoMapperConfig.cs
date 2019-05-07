using AutoMapper;
using IT_News.Infrastucture.MappingProfiles;

namespace IT_News
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile(typeof(NewsMappingProfile)));
        }
    }
}