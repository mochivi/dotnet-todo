using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_cli;

enum Command
{
    Add,
    Get,
    Update,
    Delete,
    List,
    Quit,
}

internal class Todo
{
    IStore store { get; set; }
    
    public Todo(IStore store)
    {
        this.store = store;
    }

    public void Loop()
    {
        var helpMsg = @"Welcome to this example TODO app in c#!
            Usage: <COMMAND> <INPUT>";
        Console.WriteLine(helpMsg);

        while (true)
        {
            // Create input
            Input? input;
            try
            {
                input = new Input(Console.ReadLine());
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                continue;
            }

            // Handle command
            switch (input.command)
            {
                case Command.Add:
                    AddItem(input.key!, input.value!); break;
                case Command.Get:
                    GetItem(input.key!); break;
                case Command.Update:
                    UpdateItem(input.key!, input.value!); break;
                case Command.Delete:
                    DeleteItem(input.key!); break;
                case Command.List:
                    ListItems(); break;
                case Command.Quit:
                    return;
            }
        }
    }

    public void AddItem(string key, string value)
    {
        var item = new Item(State.Pending, value);
        store.AddItem(key, item);
    }

    public void GetItem(string key)
    {
        try
        {
            var item = store.GetItem(key);
            item.Display();
        } 
        catch (Exception ex) 
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public void UpdateItem(string key, string value) { }
    
    public void DeleteItem(string key) { }

    public void ListItems() 
    {
        try
        {
            var items = store.GetItems();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

}
