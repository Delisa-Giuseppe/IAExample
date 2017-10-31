using UnityEngine;

namespace AI.Movement
{
    public class AlignmentBehaviour : SteeringBehaviour
    {
        public float radius = 1;

        public override SteeringOutput GetSteering()
        {
            SteeringOutput steering = new SteeringOutput();
            // Get alla agents inside the circle
            Vector2 averageDirection = Vector2.zero;
            int totalAgent = 0;
            foreach(var agent in FindObjectsOfType<Agent>())
            {
                if(agent.gameObject == this.gameObject)
                {
                    continue;
                }
                if((agent.transform.position - transform.position).sqrMagnitude <= radius * radius)
                {
                    averageDirection += (Vector2)agent.transform.right;
                    totalAgent++;
                }
            }
            // Nobody inside the circle
            if(totalAgent == 0)
            {
                return steering;
            }

            averageDirection /= totalAgent;
            steering.targetLinearVelocityPercent = averageDirection;
            return steering;
        }
    }
}