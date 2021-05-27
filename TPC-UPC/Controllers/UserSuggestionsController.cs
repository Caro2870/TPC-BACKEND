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
using TPC_UPC.API.Extensions;

namespace TPC_UPC.Controllers
{
    [ApiController]
    [Route("/api/users/{userId}/suggestions")]
    public class UserSuggestionsController : Controller
    {
        private readonly ISuggestionService _suggestionService;
        private readonly IMapper _mapper;

        public UserSuggestionsController(ISuggestionService suggestionService, IMapper mapper)
        {
            _suggestionService = suggestionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all faculties of a User",
            Description = "List of faculties of a specific User",
            OperationId = "ListAllfacultiesOfAUser")]
        [SwaggerResponse(200, "List of all faculties of a User", typeof(IEnumerable<SuggestionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SuggestionResource>), 200)]
        public async Task<IEnumerable<SuggestionResource>> GetAllAsync(int UserId)
        {
            var suggestions = await _suggestionService.ListByUserIdAsync(UserId);
            var resources = _mapper
                .Map<IEnumerable<Suggestion>, IEnumerable<SuggestionResource>>(suggestions);
            return resources;
        }
    }
}
