﻿using NServiceBus;
using NServiceBus.Logging;

public class MyHandler :
    IHandleMessages<MyMessage>
{
    static ILog log = LogManager.GetLogger<MyHandler>();

    #region MessageHandler
    public void Handle(MyMessage message)
    {
        log.Info("Message received at endpoint");
    }
    #endregion
}