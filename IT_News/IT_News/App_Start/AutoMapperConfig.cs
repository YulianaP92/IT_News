using AutoMapper;
using IT_News.Infrastucture.MappingProfiles;

namespace IT_News
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile(typeof(NewsMappingProfile));
                c.AddProfile(typeof(CommentMappingProfile));
                c.AddProfile(typeof(SectionMappingProfile));
                c.AddProfile(typeof(TagMappingProfile));
                c.AddProfile(typeof(UserPageMappingProfile));
                c.AddProfile(typeof(LikePostMappingProfile));
            });
        }
    }
}