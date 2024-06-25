using System;
using UnityEngine;

public class AgentBelief {
    
    public string Name {get;}

    Func<bool> condition = () => false;
    Func<Vector3> observedLocation = () => Vector3.zero;
    public Vector3 Location => observedLocation();
    AgentBelief(string name) 
    {
        Name = name;
    }
    public bool Evaluate() => condition();

    public class Builder {
        readonly AgentBelief belief;
        public Builder(string name)
        {
            belief = new AgentBelief(name);
        }

        public Builder WithCondition(Func<bool> condition){
            belief.condition = condition;
            return this;
        }

        public Builder WithLocation(Func<Vector3> observedLocation){
            belief.observedLocation = observedLocation;
            return this;
        }

        public AgentBelief Build(){
            return belief;
        }
    }
}