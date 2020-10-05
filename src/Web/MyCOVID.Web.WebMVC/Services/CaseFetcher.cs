using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCOVID.Web.WebMVC.Models;

namespace MyCOVID.Web.WebMVC.Services
{
    public class CaseFetcher : ICaseFetcher
    {
        private readonly HttpClient _client;
        private readonly ILogger<CaseFetcher> _logger;
        
        public CaseFetcher(HttpClient client, ILogger<CaseFetcher> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<List<Block>> GetCasesAsync()
        {
            var result = await _client.GetAsync("http://service-reporting/v1/report");
            
            var content = await result.Content.ReadAsStringAsync();
            var blockList = JsonSerializer.Deserialize<List<Block>>(content);
            var sortedBlockList = blockList.OrderBy(x => x.Id).ToList();

            return sortedBlockList;
        }
    }
}