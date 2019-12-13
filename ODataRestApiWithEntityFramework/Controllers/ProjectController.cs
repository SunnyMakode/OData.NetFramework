using System;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using OData.Business.DomainClasses;
using OData.InternalDataService.Implementation;
using OData.InternalDataService.Interface;

namespace ODataRestApiWithEntityFramework.Controllers
{
    [Authorize]
    public class ProjectController : ODataController
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET: localhost/Projects
        [EnableQuery]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var projects = _projectRepository.GetProjects();
            return Ok(projects.ToList());
        }

        // GET: localhost/Projects(1)
        [EnableQuery]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get(long key)
        {
            Project temp = null;
            try
            {
                var resource = _projectRepository.GetProject(key);
                temp = resource;
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Conflict();
            }
            return Ok(temp);
        }

        [HttpPost]
        public IHttpActionResult Post(Project project)
        {
            try
            {
                _projectRepository.AddProject(project);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Conflict();
            }

            return Ok("Record saved successfully");
        }

        [HttpPut]
        public IHttpActionResult Put(Project project)
        {
            try
            {
                _projectRepository.UpdateProject(project);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Conflict();
            }

            return Ok("Record updated successfully");
        }

        [HttpDelete]
        public IHttpActionResult Delete(Project project)
        {
            try
            {
                _projectRepository.RemoveProject(project);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Conflict();
            }

            return Ok("Record deleted successfully");
        }
    }
}
