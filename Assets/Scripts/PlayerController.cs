using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    protected Rigidbody rb;

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

        //hudController.SetTimerText(elapsedTime);

        GameEvents.OnElapsedTime.Invoke(elapsedTime);

        if(Input.GetKeyDown(KeyCode.Space))
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
    }
}
