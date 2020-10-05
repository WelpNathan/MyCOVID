using System.Collections.Generic;
using System.Threading.Tasks;
using MyCOVID.Web.WebMVC.Models;

namespace MyCOVID.Web.WebMVC.Services
{
    public interface ICaseFetcher
    {
        public Task<List<Block>> GetCasesAsync();
    }
}