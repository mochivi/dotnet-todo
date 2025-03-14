// See https://aka.ms/new-console-template for more information
using todo_cli;

var store = new Store();
var app = new Todo(store);

app.Loop();