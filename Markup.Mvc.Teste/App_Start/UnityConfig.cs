using Markup.Business.Teste.Services;
using Markup.Business.Teste.Services.Interfaces;
using Markup.Data.Teste;
using Markup.Data.Teste.Repositories;
using Markup.Models.Teste.Interfaces.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Markup.Mvc.Teste
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<MarkupContext>();
            container.RegisterType<IContatoRepository, ContatoRepository>();
            container.RegisterType<IContatoBusinessService, ContatoBusinessService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}