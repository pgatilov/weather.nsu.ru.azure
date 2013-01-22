using System.Web;
using System.Web.Mvc;

namespace weather.nsu.ru.azure
{
    internal class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}