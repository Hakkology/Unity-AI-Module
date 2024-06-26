using System.Collections.Generic;
using System.Linq;

public class AgentPlanner : IAgentPlanner {
    public AgentActionPlan Plan(Agent agent, HashSet<AgentGoal> goals, AgentGoal mostRecentGoal = null) {
        List<AgentGoal> orderedGoals = goals
            .Where(g => g.DesiredEffects.Any(b => !b.Evaluate()))
            .OrderByDescending(g => g == mostRecentGoal ? g.Priority - 0.01 : g.Priority)
            .ToList();
        
        foreach (var goal in orderedGoals)
        {
            AgentPlanNode goalNode = new AgentPlanNode (null, null, goal.DesiredEffects, 0);

            if (FindPath(goalNode, agent.actions))
            {
                // WIP
            }
        }

        return orderedGoals;
    }

    bool FindPath(AgentPlanNode parent, HashSet<AgentAction> actions){
        foreach (var action in actions)
        {
            var requiredEffects = parent.RequiredEffects;
            requiredEffects.RemoveWhere(b => b.Evaluate());
            if (requiredEffects.Count == 0) return true;
        }


    }
}
