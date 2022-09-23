using Microsoft.EntityFrameworkCore;
using ToDoList_New.Models;

namespace ToDoList_New.Data;

public class ToDoContext:DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options):base(options)
    {
        
    }
    
    public DbSet<ToDo> ToDoList { get; set; }
}