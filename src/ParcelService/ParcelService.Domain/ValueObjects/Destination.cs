using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record Destination
    {
        public string Region { get; init; }
        public string Terminal { get; init; }

        [SetsRequiredMembers]
        private Destination() { }
        public Destination(string region, string terminal)
        {
            Region = region;
            Terminal = terminal;
        }

    }
}
