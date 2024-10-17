using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using DigginDeep.Models;

namespace DigginDeep.Web.Components.Services
{
    public class StudentService: IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        Task<IEnumerable<Student>> IStudentService.GetStudents()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Student>>("api/student")!;
        }
    }
}