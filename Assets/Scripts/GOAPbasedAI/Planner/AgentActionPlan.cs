using System.Collections;
using System.Collections.Generic;

public class AgentActionPlan {
    public AgentGoal AgentGoal{get;}
    public Stack<AgentAction> Actions {get;}
    public float TotalCost {get; set;}

    public AgentActionPlan(AgentGoal goal, Stack<AgentAction> actions, float totalCost)
    {
        AgentGoal = goal;
        Actions = actions;
        TotalCost = totalCost;
    }

    

}
