using Amazon.Runtime.CredentialManagement;
using Core;
using Core.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;


namespace TesteRickDimensao.Controllers.Base
{
    public class LocalizacaoRickControllerBase : ControllerBase
    {
        #region [ Properties / Constructor ]

        internal const string ROUTE = "main";

        private ServerContainer _server;
        internal ServerContainer _Server { get { return GetServerData(); } }

        public LocalizacaoRickControllerBase(IConfiguration configuration)
        {
            _server = new ServerContainer();
            _server.ConnectionString = configuration.GetConnectionString(configuration["BancoDados"].Trim());

            configuration.Bind(_server.Configuration);
        }

        internal virtual void CreateCoreConnections() { /* Para sobrecarga nos Controllers */ }

        #endregion [ Properties / Constructor ]

        protected IActionResult Result(LocalizacaoRickResult result)
        {
            return StatusCode(200, result);
        }

        public override OkObjectResult Ok([Microsoft.AspNetCore.Mvc.Infrastructure.ActionResultObjectValue] object value)
        {
            if (value is LocalizacaoRickResult)
                throw new PlatformNotSupportedException("Utilizar o método Result para retornar objetos do tipo TvAPIResult");

            return base.Ok(value);
        }

        private ServerContainer GetServerData()
        {
            return _server;
        }
    }
}
