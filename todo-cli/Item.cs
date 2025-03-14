using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_cli;

internal enum State
{
    Pending,
    Done,
    Late
}

internal class Item
{
    private State state {  get; set; }
    private string value { get; set; }

    internal Item(State state, string value) 
    {
        this.state = state;
        this.value = value;
    }

    public void Display()
    {
        string display = state.ToString() + ": " + value;
        Console.WriteLine(display);
    }
}
