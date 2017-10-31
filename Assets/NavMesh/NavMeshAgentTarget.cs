using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.NavMesh
{

    public class NavMeshAgentTarget : MonoBehaviour {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    transform.position = hit.point;
                }
            }
        }
    }
}