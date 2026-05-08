using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalService.Infrastructure.InfrastructureErrors
{
    public class MessageError
    {
        public static Error MessagePublishError() =>
            Error.Failure("Message.Error", $"Unexpected error when publishing to Dapr PubSub");
    }
}
