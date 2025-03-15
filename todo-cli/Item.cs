using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_cli;

internal enum Status
{
    Pending = 1,
    Done = 2,
    Late = 3,
}

internal class Item
{
    internal Status State {  get; set; }
    internal string Value { get; set; }

    internal Item(Status state, string value) 
    {
        this.State = state;
        this.Value = value;
    }

    public void Display()
    {
        string display = State.ToString() + ": " + Value;
        Console.WriteLine(display);
    }
}
