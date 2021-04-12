using Newtonsoft.Json;
using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Service.ExternService.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_talycapglobal.Service.ExternService
{
    public static class FakeRestAPI
    {
        /// <summary>
        /// Funcion que consume el Api externo al sistema consulta usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public static async Task<IEnumerable<User>> GetUser()
        {
            string url = "https://fakerestapi.azurewebsites.net/api/v1/Users";
            using (var httpClient = new HttpClient())
            {
                var response = await Task.FromResult(httpClient.GetStringAsync(new Uri(url)).Result);
                return JsonConvert.DeserializeObject<IEnumerable<User>>(response);
            }
        }
        /// <summary>
        /// Funcion que consume el Api externo al sistema consulta auroeres
        /// </summary>
        /// <returns>Lista de autores</returns>
        public static async Task<IEnumerable<FakeAuthor>> GetAuthors()
        {
            string url = "https://fakerestapi.azurewebsites.net/api/v1/Authors";
            using (var httpClient = new HttpClient())
            {
                var response = await Task.FromResult(httpClient.GetStringAsync(new Uri(url)).Result);
                return JsonConvert.DeserializeObject<IEnumerable<FakeAuthor>>(response);
            }
        }
        /// <summary>
        /// Funcion que consume el Api externo al sistema consulta Books
        /// </summary>
        /// <returns>Lista de books</returns>
        public static async Task<IEnumerable<FakeBook>> GetBooks()
        {
            string url = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            using (var httpClient = new HttpClient())
            {
                var response = await Task.FromResult(httpClient.GetStringAsync(new Uri(url)).Result);
                return JsonConvert.DeserializeObject<IEnumerable<FakeBook>>(response);
            }
        }

    }
}
