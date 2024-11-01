using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace DigginDeep.API.Models
{
    public class OrganizationRepository: IOrganizationRepository
    {
        private readonly DDDatabase _DDDatabase;

        public Organization(DDDatabase DDDatabase)
        {
            _DDDatabase = DDDatabase;
        }

        public async Task<Organization> AddOrganization(Organization organization)
        {
            var result = await _DDDatabase.Organizations.AddAsync(organization);
            await _DDDatabase.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteOrganization(int id)
        {
            var organization = await _DDDatabase.Organizations.FirstOrDefaultAsync(o => o.Id == id);
            if (organization != null)
            {
                _DDDatabase.Organizations.Remove(organization);
                await _DDDatabase.SaveChangesAsync();
            }
        }

        public async Task<Organization> GetOrganization(int id)
        {
            var organization = await _DDDatabase.Organizations.FirstOrDefaultAsync(o => o.Id == id);
            if (organization == null)
            {
                throw new Exception($"Organization with id {id} not found.");
            }
            return organization;
        }

        public async Task<IEnumerable<Organization>> GetOrganizations()
        {
            return await _DDDatabase.Organizations.ToListAsync();
        }

        public async Task<Organization> UpdateOrganization(Organization organization)
        {
            var result = _DDDatabase.Organizations.Update(organization);
            await _DDDatabase.SaveChangesAsync();
            return result.Entity;
        }
    }
}