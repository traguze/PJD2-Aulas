using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AULA_20231024
{

    public class CameraController : MonoBehaviour
    {
        public Transform Target;

        protected Transform tf;

        [Range(0, 1f)]
        public float t = 0.5f;
        private void Awake()
        {
            tf = GetComponent<Transform>();
            var player = GameObject.FindObjectOfType<PlayerController>();
            Target = player.GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            Vector3 targetPosition = new Vector3(
                Target.position.x,
                tf.position.y,
                Target.position.z
            );
            tf.position = Vector3.Lerp(tf.position, targetPosition, t);
        }
    }

}