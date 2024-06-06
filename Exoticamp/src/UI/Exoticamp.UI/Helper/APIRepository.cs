using Exoticamp.UI.Models.ResponseModels;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;

namespace Exoticamp.UI.Helper
{
    public class APIRepository
    {
        private readonly IConfiguration _configuration;
        public IOptions<ApiBaseUrl> _apiBaseUrl { get; private set; }

         public APIRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region APICommunication - Common Method for API calling

        public async Task<Response<string>> APICommunication(string baseurl, string URL, HttpMethod invokeType, ByteArrayContent body, string token)
        {
            Response<string> response = new Response<string>();
            response.statusCode = HttpStatusCode.BadRequest;
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();

                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(baseurl + URL);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage oHttpResponseMessage = new HttpResponseMessage();

                    if (invokeType.Method == HttpMethod.Get.ToString())
                    {
                        var responseTask = await client.GetAsync(client.BaseAddress);
                        responseTask.EnsureSuccessStatusCode();
                        var response1 = await responseTask.Content.ReadAsStringAsync();

                        oHttpResponseMessage = responseTask;
                    }
                    else if (invokeType.Method == HttpMethod.Post.ToString())
                    {
                        if (body != null)
                            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        var responseTask = await client.PostAsync(client.BaseAddress, body);
                        responseTask.EnsureSuccessStatusCode();
                        oHttpResponseMessage = responseTask;

                    }
                    else if (invokeType.Method == HttpMethod.Put.ToString())
                    {
                        if (body != null)
                            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        var responseTask = await client.PutAsync(URL, body);
                        responseTask.EnsureSuccessStatusCode();

                        oHttpResponseMessage = responseTask;
                    }
                    else if (invokeType.Method == HttpMethod.Delete.ToString())
                    {
                        var responseTask = await client.DeleteAsync(URL);
                        responseTask.EnsureSuccessStatusCode();

                        oHttpResponseMessage = responseTask;
                    }

                    response.statusCode = oHttpResponseMessage.StatusCode;
                    if (oHttpResponseMessage.IsSuccessStatusCode)
                    {
                        response.data = oHttpResponseMessage.Content.ReadAsStringAsync().Result;
                        response.Success = true;

                    }
                    else
                    {
                        response.data = oHttpResponseMessage.Content.ReadAsStringAsync().Result;
                        response.Success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        private static StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
        {
            try
            {
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                {
                    Name = "UploadedFile",
                    FileName = "\"" + fileName + "\""
                };
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                return fileContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion APICommunication - Common Method for API calling
    }
}
