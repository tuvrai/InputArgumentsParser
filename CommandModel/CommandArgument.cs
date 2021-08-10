using System;
using System.Collections.Generic;
using System.Text;

namespace InputArgumentsParser.CommandModel
{
    public class CommandArgument
    {
        public Type ExpectedValueType { get; set; }
        public string Name { get; set; }
        #nullable enable
            public string? Value { get; set; }
            public string? Description { get; set; }
        #nullable disable
        public bool IsMandatory { get; set; }
    }
}
