using System;
using System.Collections.Generic;
using System.Text;

namespace InputArgumentsParser.CommandModel
{
    public class CommandOption : CommandArgument
    {
        public string OptionShort { get; set; }
        public string OptionShortTag
        {
            get
            {
                return "-" + OptionShort;
            }
        }
        #nullable enable
        public string? OptionLongTag
        {
            get
            {
                if (Name is null) return null;
                else return "--" + Name;
            }
        }
        
        public bool IsBoolean { get; set; }
        public CommandOption(Type expected, string name,string option_short, bool ismandatory, string? desc = null)
        {
            ExpectedValueType = expected;
            OptionShort = option_short;
            IsBoolean = expected.Equals(typeof(Boolean))?true:false;
            if (IsBoolean) Value = "False";
            IsMandatory = ismandatory;
            Name = name;
            Description = desc;
        }
#nullable disable
    }
}
