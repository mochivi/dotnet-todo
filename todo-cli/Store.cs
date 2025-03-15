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
    void UpdateItem(string key, Status status);
    void DeleteItem(string key);
    List<Item> GetItems();
}


internal class Store : IStore
{
    private Dictionary<string, Item> storage { get; set; } = new Dictionary<string, Item>();

    public Item GetItem(string key) => this.storage[key];
    public void AddItem(string key, Item item) => this.storage[key] = item;
    public void UpdateItem(string key, Status status) => this.storage[key].State = status;
    public void DeleteItem(string key) => this.storage.Remove(key);
    public List<Item> GetItems() => this.storage.Values.ToList();
}
