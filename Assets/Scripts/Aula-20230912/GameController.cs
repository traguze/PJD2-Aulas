using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


namespace Aula_20230912
{

    public class GameController : MonoBehaviour
    {
        public bool IsCooldown;

        public string Url = "https://jsonplaceholder.typicode.com/users";
        void Start()
        {
            //StartCoroutine(MakeRequest());

            //ExWithoutCoroutine();

            StartCoroutine(ExWithCoroutine());
            
        }


        IEnumerator MakeRequest()
        {
            string json = "";
            var request = UnityWebRequest.Get(Url);
            yield return request.SendWebRequest();

            switch(request.result)
            {
                case UnityWebRequest.Result.Success:
                    json = request.downloadHandler.text;
                    Debug.Log(json);
                    break;
            }

            
        }

        void ExWithoutCoroutine()
        {
            Debug.Log($"{Time.time} ExWithoutCoroutine");
            Debug.Log($"{Time.time} 1");
            Debug.Log($"{Time.time} 2");
            Debug.Log($"{Time.time} 3");
            Debug.Log($"{Time.time} 4");
            Debug.Log($"{Time.time} 5");
            Debug.Log($"{Time.time} End");
        }

        IEnumerator RunCooldown()
        {
            IsCooldown = true;
            yield return new WaitForSeconds(3f);
            IsCooldown = false;
        }

        IEnumerator ExWithCoroutine()
        {
            Debug.Log($"{Time.time} {Time.frameCount} ExWithoutCoroutine");
            yield return new WaitForSeconds(1f);
            Debug.Log($"{Time.time} {Time.frameCount} 1");
            yield return new WaitForSeconds(1f);
            Debug.Log($"{Time.time} {Time.frameCount} 2");
            yield return new WaitForSeconds(1f);
            Debug.Log($"{Time.time} {Time.frameCount} 3");
            yield return new WaitForSeconds(1f);
            Debug.Log($"{Time.time} {Time.frameCount} 4");
            yield return new WaitForSeconds(1f);
            Debug.Log($"{Time.time} {Time.frameCount} 5");
            yield return new WaitForSeconds(1f);
            Debug.Log($"{Time.time} {Time.frameCount} End");
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(MakeRequest());
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(RunCooldown());
            }

        }
    }

}