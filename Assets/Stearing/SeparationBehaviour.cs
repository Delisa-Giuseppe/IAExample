using UnityEngine;

namespace AI.Movement
{
    public class SeparationBehaviour : SteeringBehaviour
    {
        public float radius = 1;

        public override SteeringOutput GetSteering()
        {
            SteeringOutput steering = new SteeringOutput();
            // Get alla agents inside the circle
            Vector2 totalSeparation = Vector2.zero;
            int totalAgent = 0;
            foreach(var agent in FindObjectsOfType<Agent>())
            {
                if(agent.gameObject == this.gameObject)
                {
                    continue;
                }
                if((agent.transform.position - transform.position).sqrMagnitude <= radius * radius)
                {
                    totalSeparation += -((Vector2)agent.transform.position - (Vector2)transform.position).normalized;
                    totalAgent++;
                }
            }
            // Nobody inside the circle
            if(totalAgent == 0)
            {
                return steering;
            }

            totalSeparation /= totalAgent;
            steering.targetLinearVelocityPercent = totalSeparation;
            return steering;
        }
    }
}