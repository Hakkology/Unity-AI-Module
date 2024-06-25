using System;
using UnityEngine;

public class AgentBelief {
    
    public string _name {get;}

    Func<bool> condition = () => false;
    Func<Vector3> observedLocation = () => Vector3.zero;
    public Vector3 Location => observedLocation();
    public AgentBelief(string name) 
    {
        _name = name;
    }
    public bool Evaluate() => condition();
}