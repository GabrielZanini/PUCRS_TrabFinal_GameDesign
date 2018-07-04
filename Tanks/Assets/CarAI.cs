using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Complete
{
    public class CarAI : MonoBehaviour
    {
        public Transform Fire;
        public LayerMask mask;

        public float _VerticalAxis = 0f;
        public float _HorizontalAxis = 0f;
        public bool _Fire1Down;
        public bool _Fire2Down;
        public bool _Fire1 = true;
        public bool _Fire2;
        public bool _Fire1Up;
        public bool _Fire2Up;

        float minDistance = -1f;
        float distance = -1f;
        public Vector3 closerTarget;

        NavMeshAgent _nvAgent;

        void Start()
        {
            _nvAgent = GetComponent<NavMeshAgent>();
            //_nvAgent.enabled = true;
        }

        void Update()
        {
            Vector3 start = Fire.position;
            start.y = 0.5f;

            Debug.DrawLine(start, start + Fire.forward * 100f, Color.green);
            RaycastHit hit;
            _Fire1 = Physics.Linecast(start, start + Fire.forward * 100f, out hit, mask);
        }

        void FixedUpdate()
        {
            GetCloserTarget();

            

            Turn();
        }


        private void GetCloserTarget()
        {
            for (int i = 0; i < GameManager.Instance.m_CameraControl.m_Targets.Length; i++)
            {
                if (GameManager.Instance.m_CameraControl.m_Targets[i] == transform)
                {
                    continue;
                }
                else
                {
                    distance = Vector3.Distance(transform.position, GameManager.Instance.m_CameraControl.m_Targets[i].position);

                    if (minDistance == -1f)
                    {
                        minDistance = distance;
                        closerTarget = GameManager.Instance.m_CameraControl.m_Targets[i].position;
                    }
                    else if (distance < minDistance)
                    {
                        minDistance = distance;
                        closerTarget = GameManager.Instance.m_CameraControl.m_Targets[i].position;
                    }
                }
            }

            distance = Vector3.Distance(transform.position, GameManager.Instance.m_CameraControl.targetsPowerUp.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closerTarget = GameManager.Instance.m_CameraControl.targetsPowerUp.position;
            }
        }

        private void Turn()
        {
            Vector3 directionTarget = (closerTarget - transform.position).normalized;
            Quaternion newRotation = Quaternion.LookRotation(directionTarget, Vector3.up);

            //float originalAngle, newAngle;

            //originalAngle = (transform.rotation.eulerAngles.y > 0f ? transform.rotation.eulerAngles.y : 360f + transform.rotation.eulerAngles.y);
            //newAngle = (newRotation.eulerAngles.y > 0f ? newRotation.eulerAngles.y : 360f + newRotation.eulerAngles.y);

            //Debug.Log("O: " + originalAngle + " N: " + newAngle + " = " + (originalAngle - newAngle));

            //if (originalAngle - newAngle > 5f)
            //{
            //    _HorizontalAxis = Mathf.Lerp(_HorizontalAxis, -1f, 10f * Time.deltaTime);
            //}
            //else if (originalAngle - newAngle < -5f)
            //{
            //    _HorizontalAxis = Mathf.Lerp(_HorizontalAxis, 1f, 10f * Time.deltaTime);
            //}
            //else
            //{
            //    _HorizontalAxis = Mathf.Lerp(_HorizontalAxis, 0f, 10f * Time.deltaTime);
            //}
            //Debug.Log(_HorizontalAxis);

            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 5f * Time.deltaTime);
        }
    }
}
