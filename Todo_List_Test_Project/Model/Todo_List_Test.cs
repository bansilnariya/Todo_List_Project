using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.OpenApi.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_List_Project.Model;
using Todo_List_Project.Properties;
using Xunit.Sdk;
using static Xunit.Assert;

namespace Todo_List_Test_Project.Model
{
    public class Todo_List_Test
    {
        public readonly DbContextOptions<TodoDBContext> _Options;
        public TodoDBContext db;
        public TodoListController Controller;


        public Todo_List_Test()
        {
            _Options = new DbContextOptionsBuilder<TodoDBContext>().UseInMemoryDatabase(databaseName: "TodoListDataBase").Options;
            db = new TodoDBContext(_Options);
            Controller = new TodoListController(db);


        }
        private static Todo todoinsert()
        {
            return new Todo()
            {
                Id = 1,
                Task = "create api",
                IsComplete = true,
                DateTime = DateTime.Now,

            };
        }
        //============================ Get Data Test ========================
        [Fact]
        public void gettododata()
        {
            //Setup
            var gettodo = todoinsert();
            db.Todos.Add(gettodo);
            db.SaveChanges();

            //Exicute
            var res = Controller.Get();

            //Assert
            NotEmpty(res);
            Equal("create api", res.FirstOrDefault().Task);
        }


        //====================== INSERT DATA TEST ==================================
        [Fact]
        public void todoinsertdata()
        {
            //Setup
            var addtododata = todoinsert();

            //Exicute
            var res = Controller.Post(addtododata);
            var result = db.Todos.FirstOrDefault(x => x.Id == addtododata.Id);
            db.SaveChanges();


            //Assert
            Equal(addtododata.Id, result.Id);
            Equal(addtododata.Task, result.Task);
            Equal(addtododata.IsComplete, result.IsComplete);
            Equal(addtododata.DateTime, result.DateTime);
            NotNull(result);
        }

        //===================== UPDATE DATA TEST ==========================================
        [Fact]
        public void updatetodo()
        {
            //Setup
            var updatetododata = todoinsert();
            db.Todos.Add(updatetododata);
            db.SaveChanges();

            //Exicute
            updatetododata.Id = 1;
            updatetododata.Task = "Creating .net core web api project with mock and unit test...";
            updatetododata.IsComplete = true;
            updatetododata.DateTime = DateTime.Now;

            //Exicute
            var res = Controller.Put(updatetododata.Id, updatetododata);
            var result = db.Todos.FirstOrDefault();

            //Assert               
            Equal(updatetododata.Id, result.Id);
            Equal(updatetododata.Task , result.Task);
            Equal(updatetododata.IsComplete, result.IsComplete);
            Equal(updatetododata.DateTime, result.DateTime);
            NotNull(result);
        }

        //=============================== DELETE DATA TEST ============================
        [Fact]
        public void deletetodolist()
        {
            //Setup
            var deletedata = todoinsert();                   

            //Exicute
            var res = Controller.Delete(deletedata.Id);
            var result = db.Todos.FirstOrDefault(x => x.Id == deletedata.Id);
      
            //Assert
             Null(result);


        }
    }

}
