using System;
using System.Collections.Generic;

namespace SimSage.Model
{
    public class Action
    {
        public string action;  // the action to perform

        public IEnumerable<string> parameters;  // list of parameters to this action
    }
}
