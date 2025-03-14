using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace todo_cli;

internal interface IStore
{    
    Item GetItem(string key);
    void AddItem(string key, Item item);
    void UpdateItem(string key, Item item);
    void DeleteItem(string key);
    List<Item> GetItems();
}


internal class Store
{
    private Dictionary<string, Item> storage { get; set; }

    public Store() 
    {
        this.storage = new Dictionary<string, Item>();
    }

    public Item GetItem(string key) => this.storage[key];
    public void AddItem(string key, Item item) => this.storage[key] = item;
}
