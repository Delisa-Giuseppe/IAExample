using AI.Movement;

namespace AI.DecisionTree
{
    public class EnemyCloseCondition : Decision
    {
        public float minDistance = 1;

        public override bool CheckCondition()
        {
            var allAgents = FindObjectsOfType<Agent>();
            foreach (var agent in allAgents)
            {
                if (agent != GetComponent<Agent>() && agent.GetComponent<Healthstate>().team != this.GetComponent<Healthstate>().team)
                {
                    if((agent.transform.position - this.transform.position).sqrMagnitude < minDistance)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
