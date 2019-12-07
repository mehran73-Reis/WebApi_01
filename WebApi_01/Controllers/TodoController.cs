using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_01.Models;

namespace WebApi_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public ITodoRepository todoItems { get; set; }

        public TodoController(ITodoRepository todoitems)
        {
            todoItems = todoitems;
        }

        [HttpGet]
        public IEnumerable<Todoitem> GetAll()
        {
            return todoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult GetById(string id)
        {
            var item = todoItems.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Todoitem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            todoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Todoitem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            todoItems.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] Todoitem item, string id)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var item1 = todoItems.Find(id);
            if (item1 == null)
            {
                return NotFound();
            }

            item.Key = item1.Key;
            todoItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult Remove(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var item = todoItems.Find(id);
            todoItems.Remove(id);
            return new NoContentResult();
        }

    }
}
