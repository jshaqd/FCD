using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using FCD.Authorization;

namespace FCD
{
    [DependsOn(
        typeof(FCDCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FCDApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FCDAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}