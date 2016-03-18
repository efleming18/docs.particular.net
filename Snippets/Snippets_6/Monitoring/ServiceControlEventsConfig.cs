﻿namespace Snippets6.Monitoring
{
    using NServiceBus;

    public class ServiceControlEventsConfig
    {
        public void Simple(EndpointConfiguration endpointConfiguration)
        {
            #region ServiceControlEventsConfig 

            // required to talk to ServiceControl
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.Conventions()
                .DefiningEventsAs(t => typeof(IEvent).IsAssignableFrom(t) ||
                                       //include ServiceControl events
                                       t.Namespace != null &&
                                       t.Namespace.StartsWith("ServiceControl.Contracts"));

            #endregion
        }
    }
}