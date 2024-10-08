﻿using AgendApp.Requests;
using AgendApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private IAppService _appService;

        public AppController(IAppService appService)
        {
            this._appService = appService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("citas")]
        public async Task<IActionResult> GetAppointments()
        {
            var resp = await _appService.getAppointments();

            return Ok(resp);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("cita/{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var result = await _appService.getAppointment(id);

            return Ok(result);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("cita/{id}")]
        public async Task<IActionResult> EditAppointment(int id, CitaRequest request)
        {
            var result = _appService.editAppointment(id, request);

            return Ok(result);
        }
    }
}
