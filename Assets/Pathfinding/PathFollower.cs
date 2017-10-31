using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Pathfinding;
using System;

namespace AI.Movement
{
    public class PathFollower : MonoBehaviour
    {
        public SeekBehaviour seekBehaviour;
        public float nextTargetRadius;
        public AStarSearch aStarSearch;
        public Node startNode;
        public Node endNode;

        List<Node> path;
        

        void Start()
        {
            StartCoroutine(FindPath());
        }

        private IEnumerator FindPath()
        {
            var graphMaker = FindObjectOfType<GraphMaker>();
            var nodes = graphMaker.nodes;
            var edges = graphMaker.edges;
            List<Node> bestPath = new List<Node>();
            yield return aStarSearch.StartCoroutine(aStarSearch.Search(nodes, edges, startNode, endNode, bestPath));
            path = bestPath;

            var nextTarget = path[0];
            seekBehaviour.targetTransform = nextTarget.transform;
        }

        // Update is called once per frame
        void Update()
        {
            if(path != null && path.Count > 0)
            {
                
                var distSqr = Vector2.SqrMagnitude(seekBehaviour.targetTransform.position - transform.position);
                if(distSqr < nextTargetRadius * nextTargetRadius)
                {
                    path.RemoveAt(0);
                    if(path.Count > 0)
                    {
                        var nextTarget = path[0];
                        seekBehaviour.targetTransform = nextTarget.transform;
                    }
                    
                }
            }
        }
    }
}


