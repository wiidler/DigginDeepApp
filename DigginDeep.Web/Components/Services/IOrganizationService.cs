using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;

namespace DigginDeep.Web.Components.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetOrganizations();

        Task<Organization> GetOrganization(int id);

        Task<Organization> CreateOrganization(Organization organization);
        Task<Organization> UpdateOrganization(int id, Organization organization);

        Task DeleteOrganization(int id);

        Task<IEnumerable<Organization>> SearchOrganizations(string name);


    }
}