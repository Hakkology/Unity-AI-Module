using System.Collections.Generic;

public interface IAgentPlanner
{
    AgentActionPlan Plan(Agent agent, HashSet<AgentGoal> goals, AgentGoal mostRecentGoal = null);
}
