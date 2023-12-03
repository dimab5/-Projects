using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.User;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public static class UserTryReadMessage
{
    [Fact]
    public static void UserTryReadMessage_ShouldReturnException()
    {
        IUser user = Substitute.For<IUser>();

        IMessage message = Message.Builder()
            .WithHeader("Header")
            .WithBody("Body")
            .WithImportanceLevel(new ImportanceLevel(5))
            .Build();

        user.When(x => x.ReadMessage(Arg.Any<IMessage>()))
            .Do(x => throw new InvalidOperationException("Сообщение уже прочитано!"));

        var topic = new Topic("Topic", new AddresseeUser(user));

        topic.GiveMessage(message);

        Assert.Throws<InvalidOperationException>(() => user.ReadMessage(message));
        Assert.Throws<InvalidOperationException>(() => user.ReadMessage(message));
    }
}