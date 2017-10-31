using AI.Movement;

namespace AI.DecisionTree
{
    public class SeekPickUp : Action
    {
        public SeekBehaviour seekBe;
        public FleeBehaviour fleeBe;

        public override void MakeDecision()
        {
            GetComponent<Agent>().maxLinearVelocity = 1;
            seekBe.weight = 1;
            fleeBe.weight = 0;

            var pickUp = FindObjectOfType<HealthPickUp>();
            if(pickUp)
            {
                seekBe.targetTransform = pickUp.transform;
            }
            else
            {
                seekBe.weight = 0;
                fleeBe.weight = 1;
                fleeBe.targetTransform = FindObjectOfType<Base>().transform;
            }
        }
    }
}
