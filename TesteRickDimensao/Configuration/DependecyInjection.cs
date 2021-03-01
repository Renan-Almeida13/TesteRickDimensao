using Core;
using Core.Contracts;
using Core.Core.Base;
using Microsoft.Extensions.DependencyInjection;
using Core.Core;

namespace TesteRickDimensao.Configuration
{
    public class DependecyInjection
    {
        #region [ Método Externo ]

        public static void AddDependencies(ref IServiceCollection services)
        {
            AddGenericCore(ref services);
            AddEspecificCore(ref services);
        }

        #endregion [ Método Externo ]

        #region [ Repositório Genérico ]

        private static void AddGenericCore(ref IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityCoreBase<>), typeof(EntityCoreBase<>));
        }

        #endregion [ Repositório Genérico ]

        #region [ Repositório Específicos - Core]

        private static void AddEspecificCore(ref IServiceCollection services)
        {
            services.AddScoped(typeof(IRickCore), typeof(RickCore));
            services.AddScoped(typeof(IUniversoCore), typeof(UniversoCore));
        }

        #endregion [ Repositório Específicos ]
    }
}
