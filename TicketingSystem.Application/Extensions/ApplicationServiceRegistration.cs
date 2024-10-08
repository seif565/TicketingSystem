﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketingSystem.Application.Jobs;

namespace TicketingSystem.Application.Extensions;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });                                
        return services;
    }
}
