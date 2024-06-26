using System.Collections.Generic;

public class AgentPlanNode {
    public AgentPlanNode Parent {get;}
    public AgentAction Action {get;}
    public HashSet<AgentBelief> RequiredEffects {get;}
    public List<AgentPlanNode> Leaves {get;}
    public float Cost {get;}

    public bool IsLeafDead => Leaves.Count == 0 && Action == null;

    public AgentPlanNode(AgentPlanNode parent, AgentAction action, HashSet<AgentBelief> effects, float cost)
    {
        Parent = parent;
        Action = action;
        RequiredEffects = new HashSet<AgentBelief>(effects);
        Leaves = new List<AgentPlanNode>();
        Cost = cost;
    }
}
