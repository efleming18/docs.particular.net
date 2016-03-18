﻿using System;
using NServiceBus;

class Program
{

    static void Main()
    {
        Console.Title = "Samples.RabbitMQ.NativeIntegration.Receiver";
        #region ConfigureRabbitQueueName
        BusConfiguration busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Samples.RabbitMQ.NativeIntegration");
        busConfiguration.UseTransport<RabbitMQTransport>()
            .ConnectionString("host=localhost");
        #endregion

        busConfiguration.EnableInstallers();
        busConfiguration.UsePersistence<InMemoryPersistence>();

        using (IBus bus = Bus.Create(busConfiguration).Start())
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}