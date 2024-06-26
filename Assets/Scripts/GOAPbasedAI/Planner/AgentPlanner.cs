using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AgentPlanner : IAgentPlanner {
    public AgentActionPlan Plan(Agent agent, HashSet<AgentGoal> goals, AgentGoal mostRecentGoal = null) {
        List<AgentGoal> orderedGoals = goals
            .Where(g => g.DesiredEffects.Any(b => !b.Evaluate()))
            .OrderByDescending(g => g == mostRecentGoal ? g.Priority - 0.01 : g.Priority)
            .ToList();
        
        // Try to solve each goal in order.
        foreach (var goal in orderedGoals)
        {
            AgentPlanNode goalNode = new AgentPlanNode (null, null, goal.DesiredEffects, 0);

            // If we can find a path to the goal, return the plan.
            if (FindPath(goalNode, agent.actions))
            {
                // if the goal node has no leaves and no action to perform, try a different goal.
                if (goalNode.IsLeafDead) continue;

                Stack<AgentAction> actionStack = new Stack<AgentAction>();
                while (goalNode.Leaves.Count > 0)
                {
                    var cheapestLeaf = goalNode.Leaves.OrderBy(leaf => leaf.Cost).First();
                    goalNode = cheapestLeaf;
                    actionStack.Push(cheapestLeaf.Action);
                }

                return new AgentActionPlan(goal, actionStack, goalNode.Cost);
            }
        }

        Debug.LogWarning("No Plan found.");
        return null;
    }

    bool FindPath(AgentPlanNode parent, HashSet<AgentAction> actions){
        // Order Actions by cost, ascending
        var orderedActions = actions.OrderBy(a => a.Cost);
        foreach (var action in orderedActions)
        {
            var requiredEffects = parent.RequiredEffects;

            // remove any effect that evaluate to true, there is no action to take.
            requiredEffects.RemoveWhere(b => b.Evaluate());

            // If there are no required effects to fulfill, we have no plan.
            if (requiredEffects.Count == 0) return true;

            if (action.Effects.Any(requiredEffects.Contains))
            {
                var newRequiredEffects = new HashSet<AgentBelief>(requiredEffects);
                newRequiredEffects.ExceptWith(action.Effects);
                newRequiredEffects.UnionWith(action.Preconditions);

                var newAvailableActions = new HashSet<AgentAction>(actions);
                newAvailableActions.Remove(action);

                var newNode = new AgentPlanNode (parent, action, newRequiredEffects, parent.Cost + action.Cost);

                // Explore new node recursively
                if (FindPath(newNode, newAvailableActions))
                {
                    parent.Leaves.Add(newNode);
                    newRequiredEffects.ExceptWith(newNode.Action.Preconditions);
                }

                // If all effects are satisfied
                if (newRequiredEffects.Count == 0)
                {
                    return true;
                }

            }
        }

        return false;
    }
}
