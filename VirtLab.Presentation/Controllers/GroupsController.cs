using System;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public GroupsController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetGroups()
        {
            var groups = _service.GroupService.GetAllGroups(trackChanges: false);

            return Ok(groups);
        }
    }
}
