namespace TaskManager.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManager.Models.TaskManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskManager.Models.TaskManagerContext context)
        {
            Task[] tasks =
            {
                new Task {Title = "Finish spreadsheets", Description = "Add new columns", DueDate = DateTime.Parse("01/01/2018"), Status = false},
                new Task {Title = "Clean the dishes", Description = "Run dishwasher", DueDate = DateTime.Parse("01/01/2018"), Status = false},
                new Task {Title = "Take cat to vet", Description = "Cat has fleas", DueDate = DateTime.Parse("01/01/2018"), Status = false}
            };

            context.Tasks.AddOrUpdate(t => t.Description, tasks);
        }
    }
}
