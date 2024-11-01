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
        private readonly IOrganization _organizationRepository;

        [HttpGet]
        public async Task<IEnumerable<Organization>> GetOrganizations()
        {
            return await _organizationRepository.GetOrganizations();
        }

        [HttpGet("{id}")]
        public async Task<Organization> GetOrganization(int id)
        {
            return await _organizationRepository.GetOrganization(id);
        }

        [HttpPost]
        public async Task<Organization> AddOrganization(Organization organization)
        {
            return await _organizationRepository.AddOrganization(organization);
        }

        [HttpPut]
        public async Task<Organization> UpdateOrganization(Organization organization)
        {
            return await _organizationRepository.UpdateOrganization(organization);
        }

        [HttpDelete("{id}")]
        public void DeleteOrganization(int id)
        {
            try
            {
                _organizationRepository.DeleteOrganization(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}