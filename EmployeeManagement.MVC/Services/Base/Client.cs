using System.Net.Http;

namespace EmployeeManagement.MVC.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        } 
    }
}
