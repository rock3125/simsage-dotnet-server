using System;
using System.Collections.Generic;

namespace SimSage.Model
{
    public class SimSageResponseObject 
    {
        public SimSageResponseObject()
        {
            queryResultList = new List<QueryResult>();
        }
        
        public string sessionId = ""; // the user's session, same as the customerId (context related)
        public string jobId = ""; // job identifier
        public string organisationId = ""; // the organisation
        public string kbId = ""; // the kb to query
        public string email = ""; // the user / owner
        public string query = ""; // the query asked
        public float scoreThreshold = 0.01f; // the score threshold used / specified
        public int numResults = 10; // the number of results to return
        public string errorStr = ""; // any error reporting from the query engine
        public string error = ""; // any error reporting from the main api
        public IEnumerable<QueryResult> queryResultList; // the result set
        public IEnumerable<string> contextStack;    // stack of the states, most recent at the top
        public Dictionary<string,string> context;   // user's context
    }
}
