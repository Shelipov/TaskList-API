using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.DAL.Interface.Models;

namespace TaskList.DAL.DataBase.Context
{
    public class TaskListContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CurrentTaskList> CurrentTaskLists { get; set; }
        public DbSet<CurrentTask> CurrentTasks { get; set; }
        public DbSet<UserCurrentTaskList> UserCurrentTaskLists { get; set; }

        public TaskListContext(DbContextOptions<TaskListContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
