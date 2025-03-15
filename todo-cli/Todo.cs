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
                    UpdateItem(input.key!); break;
                case Command.Delete:
                    DeleteItem(input.key!); break;
                case Command.List:
                    ListItems(); break;
                case Command.Quit:
                    return;
            }

            Console.WriteLine("Executed");
        }
    }

    public void AddItem(string key, string value)
    {
        try
        {
            var item = new Item(Status.Pending, value);
            store.AddItem(key, item);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
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

    public void UpdateItem(string key) 
    {
        try
        {
            var item = store.GetItem(key);

            Console.WriteLine($"{key} {item.State}");
            Console.WriteLine("Enter status (1: Pending, 2: Done, 3: Late): ");

            var statusInput = Console.ReadLine();
            if (!(Enum.TryParse<Status>(statusInput, out Status parsedStatus) && Enum.IsDefined(typeof(Status), parsedStatus)))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            store.UpdateItem(key, parsedStatus);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public void DeleteItem(string key)
    {
        try
        {
            store.DeleteItem(key);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public void ListItems() 
    {
        try
        {
            var items = store.GetItems();
            foreach (var item in items)
            { 
                item.Display();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

}
