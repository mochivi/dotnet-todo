using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace todo_cli;

internal class Input
{
    internal Command command {  get; private set; }
    internal string? key { get; private set; }
    internal string? value { get; private set; }

    public Input(string? input)
    {
        if (input == null || input == "")
        {
            throw new ArgumentException("please provide some command");
        }

        var inputList = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)!;

        // This is a terrible way to parse commands
        switch (inputList[0].Trim().ToLower())
        {
            case "add":
            case "a":
                this.command = Command.Add;
                this.key = inputList[1];
                this.value = string.Join(" ", inputList.Skip(2));
                break;
            
            case "get":
            case "g":
                this.command = Command.Get;
                this.key = string.Join(string.Empty, inputList.Skip(1));
                break;
            
            case "delete":
            case "d":
                this.command = Command.Delete;
                this.key = string.Join(string.Empty, inputList.Skip(1));
                break;

            case "update":
            case "u":
                this.command = Command.Update;
                this.key = inputList[1];
                break;

            case "list":
            case "l":
                this.command = Command.List;
                break;

            case "quit":
            case "q":
                this.command = Command.Quit;
                break;
            
            default:
                throw new ArgumentException("invalid command");
        }

        
    }
}