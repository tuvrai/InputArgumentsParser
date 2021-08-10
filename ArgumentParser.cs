using System;
using System.Collections.Generic;
using System.Text;

namespace InputArgumentsParser
{
    using CommandModel;
    public class ArgumentParser
    {
        List<CommandArgument> arglist;

        public List<CommandArgument> GetList
        {
            get
            {
                return arglist;
            }
        }

        public List<CommandOption> GetCommandOptions
        {
            get
            {
                List<CommandOption> list = new List<CommandOption>();
                foreach(CommandArgument arg in arglist)
                {
                    if (arg is CommandOption)
                    {
                        list.Add((CommandOption)arg);
                    }
                }
                return list;
            }
        }

        public List<CommandValue> GetCommandValues
        {
            get
            {
                List<CommandValue> list = new List<CommandValue>();
                foreach (CommandArgument arg in arglist)
                {
                    if (arg is CommandValue)
                    {
                        list.Add((CommandValue)arg);
                        
                    }
                }
                return list;
            }
        }

        public string GetStringByArgumentName(string argumentname)
        {
            foreach (CommandArgument arg in arglist)
            {
                if (arg.Name.Equals(argumentname))
                {
                    return arg.Value;
                }
            }
            return null;
        }

        public void PrintArgumentsWithValues()
        {
            foreach(CommandArgument arg in arglist)
            {
                string value = GetStringByArgumentName(arg.Name);
                if (value is null) value = "<Undefined>";
                Console.WriteLine($"Argument: {arg.Name}, Value: {value}");
            }
        }

        public void Parse(string[] inputargs)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < inputargs.Length; i++)
                {
                    if (inputargs[i][0].Equals('-'))
                    {
                        foreach (CommandOption arg in GetCommandOptions)
                        {

                            if (inputargs[i].Equals(arg.OptionShortTag) || inputargs[i].Equals(arg.OptionLongTag))
                            {
                                if (arg.IsBoolean)
                                {
                                    arg.Value = "True";
                                }
                                else if (i + 1 < inputargs.Length && !(inputargs[i + 1][0].Equals('-')))
                                {
                                    i += 1;
                                    try
                                    {
                                        Convert.ChangeType(inputargs[i], arg.ExpectedValueType);
                                    }
                                    catch
                                    {
                                        throw new Exceptions.IncorrectOptionValueException("Unexpected option value of option named: "+arg.Name,arg.Name);
                                    }
                                    arg.Value = inputargs[i];
                                }
                                else
                                {
                                    Console.WriteLine("error: no value for non boolean option.");
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            CommandValue a = GetCommandValues[count++];
                            try
                            {
                                Convert.ChangeType(inputargs[i], a.ExpectedValueType);
                            }
                            catch
                            {
                                throw new Exceptions.IncorrectOptionValueException("Unexpected option value of argument named: " + a.Name, a.Name);
                            }
                            a.Value = inputargs[i];
                        }
                        catch
                        {
                            throw new Exceptions.TooManyValueArgumentsException("Value arguments in input exceed expected amount.");
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public object GetObject(Type type)
        {
            try
            {
                object obj = Activator.CreateInstance(type);
                foreach (var property in type.GetProperties())
                {
                    try
                    {
                        string strValue = GetStringByArgumentName(property.Name);
                        //Console.WriteLine("xd: " + property.Name + " " + property.PropertyType+ " " + strValue);
                        if (!(strValue is null))
                        {
                            property.SetValue(obj, Convert.ChangeType(strValue, property.PropertyType));
                        }
                    }
                    catch
                    {
                        throw new Exceptions.IncorrectOptionValueException();
                    }
                }
                return obj;
            }
            catch
            {
                Console.WriteLine("Parsing object error.");
                throw;
            }
        }

        public ArgumentParser(List<CommandArgument> list)
        {
            arglist = list;
        }
    }
}
