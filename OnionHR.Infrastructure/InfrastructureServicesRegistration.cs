using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionHR.Application.Contracts.Email;
using OnionHR.Application.Models.Email;
using OnionHR.Infrastructure.EmailService;

namespace OnionHR.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrasrtuctureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}
