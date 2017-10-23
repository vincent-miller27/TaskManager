using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers.Api
{
    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController
    {
        private ITaskManagerRepository _repository;

        public TasksController(ITaskManagerRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Tasks
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTasks()
        {
            try
            {
                var results = _repository.GetAllTasks();

                return Ok(Mapper.Map<IEnumerable<TaskViewModel>>(results));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Tasks
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostTask(TaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Task task = Mapper.Map<Task>(viewModel);

                _repository.AddTask(task);

                return Created($"api/tasks/{viewModel.Title}", Mapper.Map<TaskViewModel>(viewModel));
            }

            return BadRequest("Failed to post task");
        }

        // PUT: api/Tasks/5
        [HttpPut]
        [Route("")]
        public IHttpActionResult EditTask(TaskViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Task task = Mapper.Map<Task>(viewModel);

                _repository.EditTask(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("status")]
        public IHttpActionResult ChangeStatus(TaskViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Task task = Mapper.Map<Task>(viewModel);

                _repository.ChangeStatus(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // DELETE: api/Tasks/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteTask(int id)
        {
            Task task = _repository.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            _repository.DeleteTask(task);

            return Ok(task);
        }
    }
}