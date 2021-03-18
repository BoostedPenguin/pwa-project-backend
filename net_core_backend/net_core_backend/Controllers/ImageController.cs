using Microsoft.AspNetCore.Mvc;
using net_core_backend.Models;
using net_core_backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> UploadImageInformation([FromBody] UploadImageModel model)
        {
            try
            {
                var response = await imageService.UploadImageInformation(model);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrganizationImages()
        {
            try
            {
                var response = await imageService.GetOrganizationImages();
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
