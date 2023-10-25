using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

namespace AULA_20231024
{


    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        public Transform Pointer;

        public Vector3 worldPointer;
        public Vector3 mousePosition;
        public Ray ray;

        protected Vector3 Destination;

        protected Rigidbody rb;

        protected NavMeshAgent agent;

        public float Speed = 5f;

        public float elapsedTime = 0;

        //public HudController hudController;

        public float time;

        public BoolEvent playerEvent = new BoolEvent();
        public UnityEvent playerEvent1 = new UnityEvent();

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            agent = GetComponent<NavMeshAgent>();

            //hudController = GameObject.FindObjectOfType<HudController>();

            //playerEvent.AddListener((bool b) => {
            //    Debug.Log($"Player Event {b}");
            //});

            playerEvent1.AddListener(() => {
                gameObject.SetActive(false);
            });
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(h, 0, v);
            Vector3 velocity = direction * Speed;

            rb.velocity = velocity;

            elapsedTime = Time.timeSinceLevelLoad;

            mousePosition = Input.mousePosition;
            worldPointer = Camera.main.ScreenToWorldPoint(mousePosition);

            ray = Camera.main.ScreenPointToRay(mousePosition);

            Debug.DrawRay(ray.origin, ray.direction, Color.red);

            var hits = Physics.RaycastAll(ray);
            if(hits.Length > 0)
            {
                Pointer.position = Destination = hits[0].point;
            }


            //hudController.SetTimerText(elapsedTime);

            GameEvents.OnElapsedTime.Invoke(elapsedTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Player Space");
                GameEvents.OnGenericEvent.Invoke();
                //playerEvent.Invoke(false);
                playerEvent1.Invoke();

                GameEvents.OnElapsedTime.AddListener((float t) =>
                {
                    time = t;
                });


            }

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                agent.SetDestination(Destination);
            }
        }
    }

}