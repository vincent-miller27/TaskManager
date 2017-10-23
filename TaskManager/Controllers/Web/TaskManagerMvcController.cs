using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskManagerMvcController : Controller
    {
        private ITaskManagerRepository _repository;

        public TaskManagerMvcController(ITaskManagerRepository repository)
        {
            _repository = repository;
        }
        
        public ActionResult Index()
        {
            var results = _repository.GetAllTasks();

            return View(Mapper.Map<IEnumerable<TaskViewModel>>(results));
        }

        //Use Edit also for Create because the views are the exact same
        //To keep code DRY
        public ActionResult EditTask(int id)
        {
            Task task = new Task();

            if (id == 0)
            {
                task.Status = false;
            }
            else
            {
                task = _repository.GetTaskById(id);
            }

            return View(Mapper.Map<TaskViewModel>(task));
        }

        [HttpPost]
        public ActionResult EditTask(TaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Task task = Mapper.Map<Task>(viewModel);

                if (task.Id == 0)
                {
                    _repository.AddTask(task);
                }
                else
                {
                    _repository.EditTask(task);
                }

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public ActionResult ChangeStatus(int id)
        {
            Task task = _repository.GetTaskById(id);
            _repository.ChangeStatus(task);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteTask(int id)
        {
            Task task = _repository.GetTaskById(id);
            _repository.DeleteTask(task);

            return RedirectToAction("Index");
        }
    }
}
