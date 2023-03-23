using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.DAL.DataBase.Context;
using TaskList_API.Test.Consts;

namespace TaskList_API.Test.Utilites
{
    public static class TaskListSetup
    {
        public static void InitializeDbForTests(TaskListContext context)
        {
            context.Users.AddRange(Defaults.Users);
            context.UserCurrentTaskLists.AddRange(Defaults.UserCurrentTaskLists);
            context.CurrentTaskLists.AddRange(Defaults.CurrentTaskLists);
            context.CurrentTasks.AddRange(Defaults.CurrentTasks);

            context.SaveChanges();
        }
    }
}
