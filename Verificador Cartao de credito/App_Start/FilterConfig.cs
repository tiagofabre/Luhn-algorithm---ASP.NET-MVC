using System.Web;
using System.Web.Mvc;

namespace Verificador_Cartao_de_credito
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
