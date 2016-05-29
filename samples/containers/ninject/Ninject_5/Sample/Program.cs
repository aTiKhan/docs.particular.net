﻿using System;
using Ninject;
using NServiceBus;

static class Program
{
    static void Main()
    {
        Console.Title = "Samples.Ninject";
        #region ContainerConfiguration
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Samples.Ninject");

        var kernel = new StandardKernel();
        kernel.Bind<MyService>().ToConstant(new MyService());
        busConfiguration.UseContainer<NinjectBuilder>(c => c.ExistingKernel(kernel));
        #endregion
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.UsePersistence<InMemoryPersistence>();
        busConfiguration.EnableInstallers();

        using (var bus = Bus.Create(busConfiguration).Start())
        {
            var myMessage = new MyMessage();
            bus.SendLocal(myMessage);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}