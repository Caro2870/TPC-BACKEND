using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Services;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using TPC_UPC.Resources;
using TPC_UPC.Domain.Models;
using TPC_UPC.API.Extensions;

namespace TPC_UPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SuggestionsController : ControllerBase
    {
        private readonly ISuggestionService _suggestionService;
        private readonly IMapper _mapper;

        public SuggestionsController(ISuggestionService suggestionService, IMapper mapper)
        {
            _suggestionService = suggestionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all Suggestions",
            Description = "List of Suggestions",
            OperationId = "ListAllSuggestions")]
        [SwaggerResponse(200, "List of Suggestions", typeof(IEnumerable<SuggestionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SuggestionResource>), 200)]
        public async Task<IEnumerable<SuggestionResource>> GetAllAsync()
        {
            var suggestions = await _suggestionService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Suggestion>, IEnumerable<SuggestionResource>>(suggestions);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SuggestionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSuggestionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var suggestion = _mapper.Map<SaveSuggestionResource, Suggestion>(resource);
            var result = await _suggestionService.SaveAsync(suggestion); 

            if (!result.Success)
                return BadRequest(result.Message);
            var suggestionResource = _mapper.Map<Suggestion, SuggestionResource>(result.Resource);
            return Ok(suggestionResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SuggestionResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSuggestionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Suggestion = _mapper.Map<SaveSuggestionResource, Suggestion>(resource);
            var result = await _suggestionService.UpdateASync(id, Suggestion);

            if (!result.Success)
                return BadRequest(result.Message);
            var suggestionResource = _mapper.Map<Suggestion, SuggestionResource>(result.Resource);
            return Ok(suggestionResource);
        }
    }
}
