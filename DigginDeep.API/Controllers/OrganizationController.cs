using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DigginDeep.API.Models;
using DigginDeep.Models;

namespace DigginDeep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrganizations()
        {
            try
            {
                return Ok(await _organizationRepository.GetOrganizations());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrganization(int id)
        {
            try
            {
                return Ok(await _organizationRepository.GetOrganization(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrganization(Organization organization)
        {
            try
            {
                return Ok(await _organizationRepository.AddOrganization(organization));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrganization(Organization organization)
        {
            try
            {
                return Ok(await _organizationRepository.UpdateOrganization(organization));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrganization(int id)
        {
            try
            {
                _organizationRepository.DeleteOrganization(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}