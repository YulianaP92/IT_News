using AutoMapper;
using IT_News_BLL.Infrastructure.MappingProfiles;

namespace IT_News.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile(typeof(CommentMappingProfile)));
            Mapper.Initialize(c => c.AddProfile(typeof(NewsMappingProfile)));
            Mapper.Initialize(c => c.AddProfile(typeof(SectionMappingProfile)));
            Mapper.Initialize(c => c.AddProfile(typeof(TagMappingProfile)));
        }
    }
}