using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string) : base() { }
    }
}
