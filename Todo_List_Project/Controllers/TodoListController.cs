using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Todo_List_Project.Model;

namespace Todo_List_Project.Properties
{
    [Route("Todo")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly TodoDBContext db;

        public TodoListController(TodoDBContext context)
        {
            db = context;

        }


        //Get (Read)
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return db.Todos.ToList();
        }

        //Post (Insert) 
        [HttpPost]
        public IActionResult Post([FromBody] Todo todo)
        {
            if (todo == null)
            {
                return Ok(ErrorCode.INVALID_DATA);
            }
            else
            {
                try
                {
                    db.Todos.Add(todo);
                    db.SaveChanges();
                    return Ok(ErrorCode.INSERT_DATA);
                }
                catch (Exception)
                {
                    return Ok(ErrorCode.ERROR);
                }
            }
        }

        //Put (Update)
        [HttpPut]
        public IActionResult Put(int id,[FromBody] Todo todo)
        {
            if(todo == null)
            {
                return Ok(ErrorCode.INVALID_DATA);

            }
            else
            {
                try
                {
                    var exite = db.Todos.FirstOrDefault(x => x.Id == id);
                    exite.Task = todo.Task;
                    exite.IsComplete = todo.IsComplete;
                    exite.DateTime = todo.DateTime;


                    db.Todos.Update(exite);
                    db.SaveChanges();
                    return Ok(ErrorCode.UPDATE_DATA);

                }
                catch(Exception)
                {
                    return Ok(ErrorCode.ERROR);
                }
            }
        }

        //Delete (Deleting Data)
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedata= db.Todos.Where(x=>x.Id== id).FirstOrDefault();

            if (deletedata == null)
            {
                return Ok(ErrorCode.INVALID_DATA);
            }
            else
            {
                try
                {
                    db.Todos.Remove(deletedata);
                    db.SaveChanges();
                    return Ok(ErrorCode.DELETE_DATD);

                }
                catch (Exception)
                {
                    return Ok(ErrorCode.ERROR);
                }
            }
        }
    }
}
