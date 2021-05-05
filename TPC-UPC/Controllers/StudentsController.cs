using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;
using TPC_UPC.Domain.Models;
using TPC_UPC.Extensions;

namespace TPC_UPC.Controllers
{
    [Route("/api/[controller]")]
    //el formato, devuelve en .json
    [Produces("application/json")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public StudentsController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all users",
            Description = "List of Users",
            OperationId = "ListAllUsers")]
        [SwaggerResponse(200, "List of Users", typeof(IEnumerable<UserResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
    }
}