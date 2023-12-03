using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Filtering;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.User;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public static class UserGetFilterMessage
{
    [Fact]
    public static void UserGetFilterMessag_eShouldNotSend()
    {
        IUser user = Substitute.For<IUser>();

        IMessage message = Message.Builder()
            .WithHeader("Header")
            .WithBody("Body")
            .WithImportanceLevel(new ImportanceLevel(1))
            .Build();

        var addressee = new AddresseeFilterProxy(
            new AddresseeUser(user),
            new ImportanceLevel(2));
        var topic = new Topic("Topic", addressee);

        topic.GiveMessage(message);

        user.Received(0).ReceiveMessage(message);
    }
}