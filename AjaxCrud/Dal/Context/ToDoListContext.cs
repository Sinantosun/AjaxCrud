using AjaxCrud.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace AjaxCrud.Dal.Context
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Process> Processes { get; set; }
    }


}
