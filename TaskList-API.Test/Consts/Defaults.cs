using System;
using TaskList.DAL.Interface.Models;

namespace TaskList_API.Test.Consts
{
    public static class Defaults
    {
        public static readonly User[] Users =
        {
            new User()
            {
                UserId = new Guid("8fc22b4c-ffed-4f5e-abe2-6bfe98a54c07"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                FirstName = "FirstName1",
                LastName = "LastName2"
            },
            new User()
            {
                UserId = new Guid("8fc22b4c-ffed-4f5e-abe2-6bfe98a54c55"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                FirstName = "FirstName2",
                LastName = "LastName2"
            },
        };
        public static readonly UserCurrentTaskList[] UserCurrentTaskLists =
        {
            new UserCurrentTaskList
            {
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                UserId = new Guid("8fc22b4c-ffed-4f5e-abe2-6bfe98a54c07"),
            }
        };
        public static readonly CurrentTaskList[] CurrentTaskLists =
        {
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("a2186eeb-c91a-4f2b-a3ec-6bc85ad10c97"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName1",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("3de95218-4094-4ca5-b80c-8d2458b910b9"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName2",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("2fd6de1c-dc62-48ae-b225-548906a2569a"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName3",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("5b7756a6-1405-4a6b-955e-46ea34b1be76"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName4",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("5a9dfe63-ba7e-4c68-889b-980b8392bf62"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName5",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("8d0f8911-6ec2-4256-9396-5c380ea267f4"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName5",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("717a4d21-fc78-447f-86dc-9bf7129ae74a"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName7",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("466033b5-bd35-4564-9c08-5d6dc0942f1c"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName8",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("24e1ca82-a990-44eb-a3f9-090ae18c7d8a"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName9",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },
            new CurrentTaskList
            {
                CurrentTaskListId = new Guid("82de6b7b-f149-4ef9-a083-a058b92ece10"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListName = "CurrentTaskListName11",
                UserCurrentTaskListId = new Guid("a6a35352-d265-495e-800c-abbefab0da61"),
            },

        };
        public static readonly CurrentTask[] CurrentTasks =
        {
            new CurrentTask
            {
                CurrentTaskId = new Guid("a6a35352-d265-495e-800c-abbefab0da62"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListId = new Guid("a2186eeb-c91a-4f2b-a3ec-6bc85ad10c97"),
                CurrentTaskName = "CurrentTaskName",
                Description = "Description",
                IsCompleted = false,
            },
            new CurrentTask
            {
                CurrentTaskId = new Guid("a6a35352-d265-495e-800c-abbefab0da63"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListId = new Guid("a2186eeb-c91a-4f2b-a3ec-6bc85ad10c97"),
                CurrentTaskName = "CurrentTaskName",
                Description = "Description",
                IsCompleted = false,
            },
            new CurrentTask
            {
                CurrentTaskId = new Guid("a6a35352-d265-495e-800c-abbefab0da64"),
                CreatedDate = new DateTime(2023, 3, 23, 1, 1, 1, DateTimeKind.Utc),
                CurrentTaskListId = new Guid("a2186eeb-c91a-4f2b-a3ec-6bc85ad10c97"),
                CurrentTaskName = "CurrentTaskName",
                Description = "Description",
                IsCompleted = false,
            }
        };
       
    }
}
