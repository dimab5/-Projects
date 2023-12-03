using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.User;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;
using NSubstitute;
using Xunit;
using ImportanceLevel = Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels.ImportanceLevel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public static class AddresseeLogger
{
    [Fact]
    public static void AddresseeLogger_ShouldLogMessage()
    {
        IMessage message = Message.Builder()
            .WithHeader("Header")
            .WithBody("Body")
            .WithImportanceLevel(new ImportanceLevel(5))
            .Build();

        ILogger logger = Substitute.For<ILogger>();
        IAddressee addressee = new AddresseeLoggerDecorator(new AddresseeUser(new User("Dima")), logger);
        var topic = new Topic("Topic", addressee);

        topic.GiveMessage(message);

        logger.Received().Log(message);
    }
}