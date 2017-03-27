using System;

namespace JFV.WebAPI.Gateway
{
    public class Service : IModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Uri { get; set; }
    }
}
