using Microsoft.EntityFrameworkCore;
using ToDoList_New.Data;
using ToDoList_New.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ToDoContext>(it => it.UseInMemoryDatabase("ToDo"));
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
// builder.Services.AddSingleton<IToDoRepository, ToDoRepository>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();


// var toDoList = new List<ToDo>
// {
//     new ToDo { Id = 1, TaskName = "read a book", IsDone = true },
//     new ToDo { Id = 2, TaskName = "do homework", IsDone = false },
//     new ToDo { Id = 3, TaskName = "buy clothes", IsDone = true }
// };
//
// context.ToDoList.AddRange(toDoList);
// context.SaveChanges();