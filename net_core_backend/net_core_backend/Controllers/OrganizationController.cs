using Microsoft.AspNetCore.Mvc;
using net_core_backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrganization()
        {
            try
            {
                var response = await organizationService.GetOrganization();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
