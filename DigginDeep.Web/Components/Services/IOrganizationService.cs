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
    }
}