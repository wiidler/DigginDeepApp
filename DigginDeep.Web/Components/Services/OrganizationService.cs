using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using DigginDeep.Models;

namespace DigginDeep.Web.Components.Services
{
    public class OrganizationService: IOrganizationService
    {
        private readonly HttpClient _httpClient;

        public OrganizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        Task<IEnumerable<Organization>> IOrganizationService.GetOrganizations()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Organization>>("api/Organization")!;
        }
    }
}