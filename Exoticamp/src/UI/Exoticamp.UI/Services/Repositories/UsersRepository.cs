﻿using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Users;
using Exoticamp.UI.Models.UserQuery;
using Exoticamp.UI.Models.Users;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Exoticamp.UI.Models.Vendors;


namespace Exoticamp.UI.Services.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private  APIRepository _apiRepository;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private string _sToken = string.Empty;
        private Response<string> _oApiResponse;

        public UsersRepository(IOptions<ApiBaseUrl> apiBaseUrl, IConfiguration configuration)
        {
            _apiBaseUrl = apiBaseUrl;
            _configuration = configuration;
            _apiRepository = new APIRepository(_configuration);
        }

        //public async Task<CreateUserResponse> CreateUserAsync(UsersVM usersVM)
        //{
        //    var json = JsonConvert.SerializeObject(usersVM, Formatting.Indented);
        //    byte[] content = Encoding.ASCII.GetBytes(json);
        //    var bytes = new ByteArrayContent(content);

        //    var response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.Users, HttpMethod.Post, bytes, _sToken);

        //    if (response.data != null)
        //    {
        //        return JsonConvert.DeserializeObject<CreateUserResponse>(response.data);
        //    }

        //    return new CreateUserResponse
        //    {
        //        Succeeded = false,
        //        Message = "Failed to create user."
        //    };
        //}

        //public async Task<UsersResponse> GetAllUsersAsync()
        //{
        //    var response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllUsers, HttpMethod.Get, null, _sToken);

        //    if (response.data != null)
        //    {
        //        return JsonConvert.DeserializeObject<UsersResponse>(response.data);
        //    }

        //    return new List<UsersResponse>();
        //}
        public async Task<IEnumerable<UsersVM>> GetAllUsersAsync()
        {
             UsersResponse response = new UsersResponse();
            List<UsersVM> events = new List<UsersVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper. GetAllUsers, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject< UsersResponse>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }

        public async Task<IEnumerable<UsersVM>> GetAllVendorsAsync()
        {
            UsersResponse response = new UsersResponse();
            List<UsersVM> events = new List<UsersVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllVendorsQueries, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<UsersResponse>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }

        public async Task< string> IsDeleteAsync(string id)
        {
            _apiRepository = new APIRepository(_configuration);

            var url = string.Format(URLHelper.IsDeleteUser, id);
            var response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, url, HttpMethod.Put, null, _sToken);

            if (response.data != null)
            {
                return response.data;
            }

            return null;
        }

        public async Task<string> IsLockedUsersAsync(string id)
        {
            _apiRepository = new APIRepository(_configuration);

            var url = string.Format(URLHelper.IsLockedUser, id);
            var response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, url, HttpMethod.Put, null, _sToken);

            if (response.data != null)
            {
                return response.data;
            }

            return null;
        }



        public async Task<Response<UsersVM>> GetUserByIdAsync(string UserId)
        {
            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(UserId, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetUserById.Replace("{0}", UserId), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<Response<UsersVM>>(response.data));

            }

            return new Response<UsersVM>
            {
                Success = false,
                Message = "User Not Found"
            };
        }

        public async Task<Response<VendorVM>> GetVendorByIdAsync(string UserId)
        {
            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(UserId, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetVendorDetails.Replace("{0}", UserId), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<Response<VendorVM>>(response.data));

            }

            return new Response<VendorVM>
            {
                Success = false,
                Message = "User Not Found"
            };
        }

        public async Task<Response<UsersVM>> IUsersRepository(string UserId)
        {
            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(UserId, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetVendorById.Replace("{0}", UserId), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<Response<UsersVM>>(response.data));

            }

            return new Response<UsersVM>
            {
                Success = false,
                Message = "User Not Found"
            };
        }

        public async Task<Response<string>> UpdateProfile(UsersVM model)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(model, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.UpdateProfile, HttpMethod.Put, bytes, _sToken);

            if (_oApiResponse.data != null)
            {
                return JsonConvert.DeserializeObject<Response<string>>(_oApiResponse.data);
            }

            return new Response<string>()
            {
                Success = false,
                Message = "Failed to add user query."
            };
        }
    }
}

