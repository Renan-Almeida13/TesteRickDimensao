using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Server
{
    public class AppConfig
    {
        public AmazonCredentials AWSCredentials { get; set; }
    }

    public class AmazonCredentials
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }
}
