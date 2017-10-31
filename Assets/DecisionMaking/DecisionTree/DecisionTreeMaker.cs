﻿namespace AI.DecisionTree
{
    public class DecisionTreeMaker : DecidionMaker
    {
        Decision root;

        private void Awake()
        {
            // Create the decision tree
            root = gameObject.AddComponent<MyHealthCondition>();

            root.trueNode = gameObject.AddComponent<EnemyCloseCondition>();
            root.falseNode = gameObject.AddComponent<SeekPickUp>();

            Decision decision2 = root.trueNode as Decision;
            decision2.trueNode = gameObject.AddComponent<SeekShoot>();
            decision2.falseNode = gameObject.AddComponent<SeekBase>();

            // ... add parameters

            SeekPickUp seekPickUpNode = root.falseNode as SeekPickUp;
            seekPickUpNode.seekBe = GetComponent<AI.Movement.SeekBehaviour>();
            seekPickUpNode.fleeBe = GetComponent<AI.Movement.FleeBehaviour>();

            SeekShoot seekShootNode = decision2.trueNode as SeekShoot;
            seekShootNode.seekBe = GetComponent<AI.Movement.SeekBehaviour>();
            seekShootNode.fleeBe = GetComponent<AI.Movement.FleeBehaviour>();
            seekShootNode.shootAction = GetComponent<ShootAction>();

            SeekBase seekBaseNode = decision2.falseNode as SeekBase;
            seekBaseNode.seekBe = GetComponent<AI.Movement.SeekBehaviour>();
            seekBaseNode.fleeBe = GetComponent<AI.Movement.FleeBehaviour>();
        }

        public override void MakeDecision()
        {
            // Ask for an action
            root.MakeDecision();
        }
    }
}