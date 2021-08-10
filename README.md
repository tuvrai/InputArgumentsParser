# InputArgumentsParser
Plugin that can parse program's dashed input arguments in CLI (like -n 10, --count, etc.) defined by user

## Usage
`Create list of arguments you expect to be inputted. Specify their expected type, option long and short name and whether they are mandatory.`

`Use CommandOptions for arguments, that are as such: -option <arg> (booleans don't take args, e.g. -t in ping command) and CommandValues when you expect some value not to be preceeded by dashed option before (e.g. hostname in ping command)`
```csharp
CommandArgument arg1 = new CommandOption(typeof(Int32), "count", "n", false);
CommandArgument arg2 = new CommandOption(typeof(Boolean),"repeat", "t", false);
CommandArgument arg3 = new CommandValue(typeof(String),"hostname", true);
List<CommandArgument> arglist = new List<CommandArgument>(new CommandArgument[] { arg1, arg2, arg3});
```
`Create a type which will gather the values - the property names should match those long ones given in the list:`
```csharp
public class ArgumentsToParse
{
    public int count { get; set; } = 4;
    public string hostname { get; set; }
    public bool repeat { get; set; } = false;
}
```
`Use the parser to examine input and extract the values`
```csharp
ArgumentParser parser = new ArgumentParser(arglist);
parser.Parse(args); //parse user arguments (args)
parser.PrintArgumentsWithValues(); //print extracted values with respecting argument names
ArgumentsToParse myArgs = (ArgumentsToParse)parser.GetObject(typeof(ArgumentsToParse)); //generate object from the extracted values
```
