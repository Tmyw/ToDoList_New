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

    public DbSet<ToDo> ToDoList { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>(t =>
        {
            t.Property(p => p.Id).ValueGeneratedOnAdd();
        });

    }
}