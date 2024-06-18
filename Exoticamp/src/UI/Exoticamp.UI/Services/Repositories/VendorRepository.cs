using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.ResponseModels.Vendors;
using Exoticamp.UI.Models.Vendors;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Exoticamp.UI.Models.ResponseModels;

namespace Exoticamp.UI.Services.Repositories
{
    public class VendorsRepository : IVendorRepository
    {
        private APIRepository _apiRepository;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private string _sToken = string.Empty;
        private Response<string> _oApiResponse;

        public VendorsRepository(IOptions<ApiBaseUrl> apiBaseUrl, IConfiguration configuration)
        {
            _apiBaseUrl = apiBaseUrl;
            _configuration = configuration;
            _apiRepository = new APIRepository(_configuration);
        }


        public async Task<Response<VendorVM>> GetVendorByIdAsync(string vendorId)
        {
            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(vendorId, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetVendorDetails.Replace("{0}", vendorId), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<Response<VendorVM>>(response.data);
            }

            return new Response<VendorVM>
            {
                Success = false,
                Message = "Vendor Not Found"
            };
        }

        public async Task<Response<string>> UpdateVendorProfileAsync(VendorVM vendor)
        {
            _apiRepository = new APIRepository(_configuration);

            var json = JsonConvert.SerializeObject(vendor, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            var response = await _apiRepository.APICommunication(
                _apiBaseUrl.Value.ExoticampApiBaseUrl,
                URLHelper.UpdateVendorProfile,
                HttpMethod.Put,
                bytes,
                _sToken
            );

            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<Response<string>>(response.data);
            }

            return new Response<string>
            {
                Success = false,
                Message = "Failed to update vendor profile"
            };
        }





    }
}
