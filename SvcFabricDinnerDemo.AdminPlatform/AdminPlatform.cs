﻿using System;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using SvcFabricDinnerDemo.DinnerMenuService.Interfaces;
using SvcFabricDinnerDemo.KitchenActor.Interfaces;
using SvcFabricDinnerDemo.OrderActor.Interfaces;
using SvcFabricDinnerDemo.RestaurantService.Interfaces;
using SvcFabricDinnerDemo.TableActor.Interfaces;

namespace SvcFabricDinnerDemo.AdminPlatform
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class AdminPlatform : StatelessService
    {
        public AdminPlatform(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        return new WebHostBuilder()
                                    .UseKestrel()
                                    .ConfigureServices(
                                        services => services
                                            .AddSingleton<StatelessServiceContext>(serviceContext)
                                            .AddTransient<IRestaurantBackupRestoreManager, RestaurantBackupRestoreManager>()
                                            .AddTransient<IDinnerMenuBackupRestoreManager, DinnerMenuBackupRestoreManager>()
                                            .AddTransient<IKitchenActorServiceBackupRestoreManager, KitchenActorServiceBackupRestoreManager>()
                                            .AddTransient<IOrderActorServiceBackupRestoreManager, OrderActorServiceBackupRestoreManager>()
                                            .AddTransient<ITableActorServiceBackupRestoreManager, TableActorServiceBackupRestoreManager>()
                                            )
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseStartup<Startup>()
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url)
                                    .Build();
                    }))
            };
        }
    }
}
