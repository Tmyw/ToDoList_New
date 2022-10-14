using Microsoft.EntityFrameworkCore;
using ToDoList_New.Models;

namespace ToDoList_New.Data;

public class ToDoContext:DbContext
{
    public ToDoContext(DbContextOptions options) : base(options)
    {
    }

    protected ToDoContext()
    {
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseInMemoryDatabase(databaseName: "ToDoDb");
    // }
    //
    
    public DbSet<ToDo> ToDoList { get; set; } = null!;
}