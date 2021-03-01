using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Server
{
    public class ServerContainer
    {
        public string ConnectionString { get; set; }
        public AppConfig Configuration { get; set; }

        public ServerContainer()
        {
            Configuration = new AppConfig();
        }
    }
}
