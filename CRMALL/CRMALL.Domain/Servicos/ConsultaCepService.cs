using CRMALL.Domain.Dto;
using CRMALL.Domain.Interfaces.Servicos;
using RestSharp;
using System.Text.Json;

namespace CRMALL.Domain.Servicos
{
    public class ConsultaCepService : IConsultaCepService
    {
        private string _urlBase = "https://viacep.com.br/ws/";
        private readonly RestClient _restClient;

        public ConsultaCepService()
        {
            _restClient = new RestClient(_urlBase);
        }
        public ViaCepDto Consultar(string cep)
        {
            var url = "{0}/json/";
            var urlConsulta = string.Format(url, cep);
            var request = new RestRequest(urlConsulta, Method.GET);
            var response = _restClient.Execute(request);
            var viaCepDto = JsonSerializer.Deserialize<ViaCepDto>(response.Content);
            return viaCepDto;
        }
    }
}
