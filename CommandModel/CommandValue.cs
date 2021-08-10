using System;
using System.Collections.Generic;
using System.Text;

namespace InputArgumentsParser.CommandModel
{
    public class CommandValue : CommandArgument
    {
#nullable enable
        public CommandValue(Type expectedtype, string name, bool ismandatory, string? description = null)
        {
            ExpectedValueType = expectedtype;
            Name = name;
            IsMandatory = ismandatory;
            Description = description;
        }
#nullable disable
    }
}
