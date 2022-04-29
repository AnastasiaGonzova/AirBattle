using System;
using System.Collections.Generic;

namespace AirBattle.Classes
{
    public class State
    {
        Dictionary<string, Object> parameteres;

        public State()
        {
            parameteres = new Dictionary<string, Object>();
        } 
        
        public State(Dictionary<string, Object> parameteres)
        {
            this.parameteres = new Dictionary<string, Object>();

           foreach(var parameter in parameteres)
            {
                this.parameteres.Add(parameter.Key, parameter.Value);
            }
        }

        public void addParameter(string key, Object value)
        {
            if (parameteres.ContainsKey(key))
            {
                parameteres[key] = value;
            }
            else
            {
                parameteres.Add(key, value);
            }
        }

        public Object getParameter(string key)
        {
            Object value;
            parameteres.TryGetValue(key, out value);
            return value;
        }

        public bool containsKey(string key)
        {
            return parameteres.ContainsKey(key);
        }

    }
}
