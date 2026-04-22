using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record PersonInfo
    {
        public string Name { get; init; }
        public Address Address { get; init; }

        [SetsRequiredMembers]
        private PersonInfo() { }
        public PersonInfo(string name, Address address)
        {
            Name = name;
            Address = address;
        }
    }
}
