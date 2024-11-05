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

        Task<Organization> IOrganizationService.GetOrganization(int id)
        {
            return _httpClient.GetFromJsonAsync<Organization>($"api/Organization/{id}")!;
        }

        Task<Organization> IOrganizationService.CreateOrganization(Organization organization)
        {
            return _httpClient.PostAsJsonAsync("api/Organization", organization).Result.Content.ReadFromJsonAsync<Organization>()!;
        }

        Task<Organization> IOrganizationService.UpdateOrganization(int id, Organization organization)
        {
            return _httpClient.PutAsJsonAsync($"api/Organization/{id}", organization).Result.Content.ReadFromJsonAsync<Organization>()!;
        }

        Task IOrganizationService.DeleteOrganization(int id)
        {
            return _httpClient.DeleteAsync($"api/Organization/{id}");
        }

        Task<IEnumerable<Organization>> IOrganizationService.SearchOrganizations(string name)
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Organization>>($"api/Organization/Search/{name}")!;
        }
    }
}