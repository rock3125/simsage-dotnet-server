using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

using SimSage.Model;


namespace SimSage.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class QueryController : Controller
    {

        // these parameters are SimSage's keys, see:  https://simsage.nz/api.html
        private const string organisationId = "?";
        private const string kbId = "?";
        private const string securityId = "?";


        public QueryController()
        {
        }

        // POST api/values
        [HttpPost]
        public async Task<IEnumerable<QueryResult>> Post([FromBody]Query query)
        {
            if (organisationId == "?")
                throw new Exception("You must setup your SimSage keys first, please visit https://simsage.nz/api.html");

            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Security-Id", securityId);
            client.DefaultRequestHeaders.Add("API-Version", "1");

            var uri = String.Format("https://cloud.simsage.nz/api/query/{0}", query.customerId);

            // setup payload for SimSage
            var data = new 
            {
                query = query.query, 
                organisationId = organisationId, 
                kbId = kbId, 
                numResults = 10, 
                scoreThreshold = 0.5 
            };
            var jsonInString = JsonConvert.SerializeObject(data);
            // call simsage
            var response = await client.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            // convert to object
            var simSageResult = JsonConvert.DeserializeObject<SimSageResponseObject>(responseString);
            if (!string.IsNullOrEmpty(simSageResult.error))
                throw new Exception(String.Format("SimSage internal error: {0}", simSageResult.error));
            if (!string.IsNullOrEmpty(simSageResult.errorStr))
                throw new Exception(String.Format("SimSage query error: {0}", simSageResult.errorStr));
            // only return the query list to the user - the rest is "secret"
            return simSageResult.queryResultList;
        }

    }
}

