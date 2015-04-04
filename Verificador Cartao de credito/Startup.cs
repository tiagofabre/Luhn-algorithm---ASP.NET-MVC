using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Verificador_Cartao_de_credito.Startup))]
namespace Verificador_Cartao_de_credito
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
