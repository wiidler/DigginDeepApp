using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DigginDeep.API.Models
{
    public interface IOrganization
    {
        Task<IEnumerable<Organization>> GetOrganizations();

        Task<Organization> GetOrganization(int id);

        Task<Organization> AddOrganization(Organization organization);

        Task<Organization> UpdateOrganization(Organization organization);

        void DeleteOrganization(int id);
    }
}