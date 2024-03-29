﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RefereeApp.Abstractions;
using RefereeApp.Models.FixtureModels;

namespace RefereeApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly IFixtureService _fixtureService;

        public FixtureController(IFixtureService fixtureService)
        {
            _fixtureService = fixtureService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<FixtureResponseModel>>> Get()
        {
            var fixture = await _fixtureService.Get();
            return Ok(fixture);
        }

        [HttpGet("id")]
        public async Task<ActionResult<FixtureResponseModel>> Get([FromQuery] int id)
        {
            var fixture = await _fixtureService.GetById(id);
            return Ok(fixture);
        }
        
        [Authorize(Roles = ("Admin,Employee"))]
        [HttpPost]
        public async Task<ActionResult<FixtureResponseModel>> Create(CreateFixtureRequestModel request)
        {
            var fixture = await _fixtureService.Create(request);
            return Ok(fixture);
        }

        [Authorize(Roles = ("Admin,Employee"))]
        [HttpPut]
        public async Task<ActionResult<FixtureResponseModel>> Update(UpdateFixtureRequestModel request)
        {
            var fixture = await _fixtureService.Update(request);
            return Ok(fixture);
        }
        
        
    }


}