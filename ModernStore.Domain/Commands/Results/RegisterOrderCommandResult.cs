using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Results
{
    public class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult() { }
        public RegisterOrderCommandResult(string number) => Number = number;

        public string Number { get; set; }
    }
}
