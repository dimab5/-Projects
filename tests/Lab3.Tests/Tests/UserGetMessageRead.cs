using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.User;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public static class UserGetMessageRead
{
    [Fact]
    public static void UserGetMessage_ShouldReturnRead()
    {
        IMessage message = Message.Builder()
            .WithHeader("Header")
            .WithBody("Body")
            .WithImportanceLevel(new ImportanceLevel(5))
            .Build();

        var user = new User("Dima");
        var addressee = new AddresseeUser(user);
        var topic = new Topic("Topic", addressee);

        topic.GiveMessage(message);
        user.ReadMessage(message);

        Assert.Contains(message, user.Messages);
        Assert.DoesNotContain(message, user.UnreadMessages);
    }
}