using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record PersonInfo
    {
        public required string Name { get; init; } = null!;
        public required Address Address { get; init; } = null!;

        [SetsRequiredMembers]
        private PersonInfo() { }

        [SetsRequiredMembers]
        public PersonInfo(string name, Address address)
        {
            Name = name;
            Address = address;
        }
    }
}
