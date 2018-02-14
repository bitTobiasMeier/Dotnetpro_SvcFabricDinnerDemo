using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvcFabricDinnerDemo.ReliableServicesCore
{
    public class ServiceFabricUriBuilder : IServiceFabricUriBuilder
    {
        private ICodePackageActivationContext _activationContext;

        public Uri Build(string servicename)
        {
            if (this._activationContext == null)
            {
                this._activationContext = FabricRuntime.GetActivationContext();
            }
            return new Uri(_activationContext.ApplicationName + "/" + servicename);
        }
    }
}
