using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Pathfinding
{
    public class Node : MonoBehaviour
    {
        public Color color = Color.white;

        SpriteRenderer spriteRenderer;
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            spriteRenderer.color = color;
        }

        // A* wights
        public float cost = float.MaxValue;
        public float heuristic;
    }
}