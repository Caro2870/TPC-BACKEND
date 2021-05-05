﻿using Microsoft.AspNetCore.Mvc;
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
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TPC_UPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper) 
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        [SwaggerOperation(
            Summary = "List all accounts",
            Description = "List of Accounts",
            OperationId = "ListAllAccounts")]
        [SwaggerResponse(200, "List of Accounts", typeof(IEnumerable<AccountResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AccountResource>), 200)]
        public async Task<IEnumerable<AccountResource>> GetAllAsync()
        {
            var accounts = await _accountService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Account>, IEnumerable<AccountResource>>(accounts);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AccountResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveAccountResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var account = _mapper.Map<SaveAccountResource, Account>(resource);
            var result = await _accountService.SaveAsync(account);

            if (!result.Success)
                return BadRequest(result.Message);
            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);
            return Ok(accountResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AccountResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAccountResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var account = _mapper.Map<SaveAccountResource, Account>(resource);
            var result = await _accountService.UpdateASync(id, account);

            if (!result.Success)
                return BadRequest(result.Message);
            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);
            return Ok(accountResource);
        }
    }
}
