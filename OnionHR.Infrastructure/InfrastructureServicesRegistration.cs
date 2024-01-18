using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionHR.Application.Contracts.Email;
using OnionHR.Application.Contracts.Logging;
using OnionHR.Application.Models.Email;
using OnionHR.Infrastructure.EmailService;
using OnionHR.Infrastructure.Logging;

namespace OnionHR.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrasrtuctureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}
