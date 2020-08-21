using Mapster;
using LeetcodeMemoApp_V1.Entity;

namespace LeetcodeMemoApp_V1.Model.MapsterConfig
{
    /// <summary>
    /// TypeAdapterConfigExtension
    /// </summary>
    public static class TypeAdapterConfigExtension
    {
        public static TypeAdapterConfig LeetcodeMemoNewConfig(this TypeAdapterConfig config)
        {
            LeetcodeMemoEntityToLeetcodeMemoModel(config);
            return config;
        }

        public static void LeetcodeMemoEntityToLeetcodeMemoModel(TypeAdapterConfig config)
        {
            config.NewConfig<LeetcodeMemoEntity, LeetcodeMemoModel>();
        }
    }
}
