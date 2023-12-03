using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messanger;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public static class SendMesssageInMessenger
{
    [Fact]
    public static void MessengerReceived_ShouldReceiveMessage()
    {
        IMessage message = Message.Builder()
            .WithHeader("Header")
            .WithBody("Body")
            .WithImportanceLevel(new ImportanceLevel(5))
            .Build();

        IMessanger messanger = Substitute.For<IMessanger>();
        IAddressee addressee = new AddresseeMessanger(messanger);
        var topic = new Topic("Topic", addressee);

        topic.GiveMessage(message);

        messanger.Received().Write(message);
    }
}