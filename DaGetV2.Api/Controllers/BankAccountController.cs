﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DaGetV2.Dal.Interface;
using DaGetV2.Service.DTO;
using DaGetV2.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DaGetV2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _service;
        private readonly IContextFactory _contextFactory;

        public BankAccountController([FromServices] IContextFactory contextFactory, [FromServices] IBankAccountService bankAccountService)
        {
            _service = bankAccountService;
            _contextFactory = contextFactory;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<BankAccountDto>> Get([FromHeader(Name = "username")] string userName)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return _service.GetAll(context, userName);
            }
        }
    }
}