using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace FCD.Web.Views
{
    public abstract class FCDRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected FCDRazorPage()
        {
            LocalizationSourceName = FCDConsts.LocalizationSourceName;
        }
    }
}
