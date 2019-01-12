using System;
using System.Collections.Generic;

namespace SimSage.Model
{
    public class QueryResult
    {
        public string url;  // result origin
        public float score = 0.0f;  // query relevance, 1.0 == 100%

        public IEnumerable<Action> actionList;  // list of parameters to this action
    }
}
