using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Pathfinding
{
    public class BreathdFirstSearch : MonoBehaviour
    {
        public Node startNode;
        public Node endNode;

        GraphMaker graphMaker;

        void Start()
        {
            graphMaker = FindObjectOfType<GraphMaker>();

            var nodes = graphMaker.nodes;
            var edges = graphMaker.edges;

            StartCoroutine(Search(nodes, edges, startNode, endNode));
        }

        IEnumerator Search(List<Node> nodes, List<Edge> edges, Node startNode, Node endNode)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(startNode);
            List<Node> visitedNode = new List<Node>();

            while(queue.Count > 0)
            {
                Node n = queue.Dequeue();
                visitedNode.Add(n);

                n.color = Color.blue;
                yield return new WaitForSeconds(0.25f);

                if (n == endNode)
                {
                    Debug.Log("Found the end node!!");
                    break;
                }

                List<Node> neighs = graphMaker.GetNeighbours(n);
                foreach(Node neigh in neighs)
                {
                    if(!visitedNode.Contains(neigh) && !queue.Contains(neigh))
                    {
                        Edge e = graphMaker.GetEdge(n, neigh);
                        e.color = Color.red;
                        yield return new WaitForSeconds(0.25f);
                        queue.Enqueue(neigh);
                    }
                }
            }

            yield return null;
        }
    }
}