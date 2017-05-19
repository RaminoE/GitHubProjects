using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
namespace ToDoList.Controllers
{
   
    public class ToDoListController : Controller
    {
        private ToDoListContext db = new ToDoListContext();
        // GET: ToDoList
        public ActionResult Index()
        {
            var model = db.ToDoList.ToList();
            return View("View", model);
        }

        [HttpPost]
        public ActionResult Index(string name, int id, string mode)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (mode == "new")
                    {
                        db.ToDoList.Add(new Models.ToDoList() { TaskName = name, TaskDate = DateTime.UtcNow, Priority = null });
                        db.SaveChanges();

                    }
                    else if (mode == "edit")
                    {
                        var Nid = db.ToDoList.Find(id);
                        Nid.TaskName = name;
                        Nid.TaskDate = DateTime.UtcNow;
                        Nid.Priority = null;
                        db.SaveChanges();

                    }

                    return PartialView("Display", db.ToDoList.ToList());
                }
                    //ViewBag.mode = "new";
                } catch (Exception ) {
                    return null;
                }

            return null;
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            var todoList = db.ToDoList.Find(id);

            return PartialView("Display", db.ToDoList.ToList());
        }
        [HttpPost]
        public ActionResult Checked(int id, bool completed)
        {
            var todo = db.ToDoList.Find(id);
            todo.TaskDate = DateTime.UtcNow;
            todo.Priority = null;
            todo.IsCompleted = completed;
            db.Entry(todo).State = EntityState.Modified;
            db.SaveChanges();
            //ViewBag.mode = "new";
            return PartialView("Display", db.ToDoList.ToList());
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var todoList = db.ToDoList.Find(id);
            db.ToDoList.Remove(todoList);
            db.SaveChanges();
            ViewBag.mode = "new";
            return PartialView("Display", db.ToDoList.ToList());
        }
    }
}