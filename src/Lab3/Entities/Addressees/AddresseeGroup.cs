using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeGroup : IAddressee
{
    private readonly IReadOnlyList<IAddressee> _addressees;

    public AddresseeGroup(IReadOnlyList<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public static AddresseeGroupBuilder Builder() => new AddresseeGroupBuilder();

    public void SendMessage(IMessage message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.SendMessage(message);
        }
    }

    public class AddresseeGroupBuilder
    {
        private readonly List<IAddressee> _addressees = new();

        public AddresseeGroupBuilder WithAddressee(IAddressee addressee)
        {
            _addressees.Add(addressee);
            return this;
        }

        public AddresseeGroup Build()
        {
            return new AddresseeGroup(_addressees);
        }
    }
}