using Microsoft.EntityFrameworkCore;
using ToDoList_New.Models;

namespace ToDoList_New.Data;

public class ToDoContext:DbContext
{
    protected void onConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ToDoDb");
    }
    
    public DbSet<ToDo> ToDoList { get; set; }
}