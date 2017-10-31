using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Movement
{
    public class Agent : MonoBehaviour
    {
        // Parameters
        public float maxLinearVelocity = 1;
        public float maxAngularVelocity = 90;
        public float maxLinearAcceleration = 1;
        public float maxLinearDeceleration = 1;
        public float maxAngularAcceleration = 90;
        

        // State
        Vector2 linearVelocity;
        float angularVelocity;
        float currentLinearVelocity;
        float linearAcceleration;
        float angularAcceleration;
        SteeringBehaviour[] steeringBehaviours;
        // Use this for initialization
        void Start()
        {
            steeringBehaviours = gameObject.GetComponents<SteeringBehaviour>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 totalSteering = Vector2.zero;
            float totalWeight = 0;

            // Get the steering output
            foreach(SteeringBehaviour steeringBehaviour in steeringBehaviours)
            {
                totalSteering += steeringBehaviour.GetSteering().targetLinearVelocityPercent * steeringBehaviour.weight;
                totalWeight += steeringBehaviour.weight;
            }

            totalSteering = totalSteering / totalWeight;
            
            // Set accelerations based on steering target
            var targetVelocityPercent = totalSteering;
            var targetVelocity = targetVelocityPercent * maxLinearVelocity;

            if(targetVelocity.sqrMagnitude > currentLinearVelocity * currentLinearVelocity)
            {
                linearAcceleration = maxLinearAcceleration;
            }
            else if(targetVelocity.sqrMagnitude < currentLinearVelocity * currentLinearVelocity)
            {
                linearAcceleration = -maxLinearDeceleration;
            }
            else
            {
                linearAcceleration = 0;
            }

            Vector3 crossVector = Vector3.Cross(targetVelocityPercent, transform.right);
            float angle = Mathf.Abs(Vector3.Angle(targetVelocityPercent, transform.right));
            int rotationDirection = -(int) Mathf.Sign(crossVector.z);

            float accelerationRatio = Mathf.Clamp(angle, 0, 5) / 5f;
            angularAcceleration = rotationDirection * maxAngularAcceleration * accelerationRatio;

            // Velocity update
            currentLinearVelocity += linearAcceleration * Time.deltaTime;
            currentLinearVelocity = Mathf.Clamp(currentLinearVelocity, 0, maxLinearVelocity);
            linearVelocity = (Vector2) transform.right * currentLinearVelocity;

            angularVelocity += angularAcceleration * Time.deltaTime;
            angularVelocity = Mathf.Clamp(angularVelocity, -maxAngularVelocity, maxAngularVelocity);
            angularVelocity = angularVelocity * accelerationRatio;

            // Position / rotation update
            transform.position += (Vector3) (linearVelocity * Time.deltaTime);
            transform.localEulerAngles += Vector3.forward * angularVelocity * Time.deltaTime;

            Debug.DrawLine(transform.position, transform.position + (Vector3)linearVelocity, Color.gray);
            Debug.DrawLine(transform.position, transform.position + (Vector3)totalSteering, Color.blue);
        }
    }
}