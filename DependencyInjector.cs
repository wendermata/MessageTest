using MassTransit;

namespace MessagesTest
{
    public static class DependencyInjector
    {

        public static IServiceCollection AddConfigurationBusMasstransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.Message<CreateCustomerOmieContract>(x =>
                    {
                        x.SetEntityName("accountancy_accountgateway_mottuaccounting_customer_integrate_omie");
                    });

                });
            });

            return services;
        }

    }
}