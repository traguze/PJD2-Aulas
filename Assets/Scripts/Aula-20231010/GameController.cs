using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace API_DND
{
    public class GameController : MonoBehaviour
    {
        public ApiClient apiClient;
        public WeaponDTO weapon;


        public bool IsCooldown = false;

        public Transform cube;

        public float px0 = -4f;
        public float px1 = 4f;


        public Matrix4x4 cameraMatrix;
        public Matrix4x4 cameraMatrix1;

        private void Awake()
        {
            apiClient = new ApiClient();

            StartCoroutine(apiClient.Dispatch(UnityWebRequest.Get("https://www.dnd5eapi.co/api/equipment/greatsword"),
                (output) =>
                {
                    Debug.Log("API");
                    Debug.Log(output);
                }    
            ));

            string path = Application.dataPath + "/Scripts/Aula-20231010/weapon1.json";
            string jsonString = File.ReadAllText(path);
            //Debug.Log(jsonString);

            weapon = JsonUtility.FromJson<WeaponDTO>(jsonString);

            cube = SceneManager.GetActiveScene()
                .GetRootGameObjects()
                .Where(g => g.name == "Cube")
                .Select(s => s.GetComponent<Transform>())
                .First();

            cameraMatrix1 = Camera.main.projectionMatrix;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ExecWithouCoroutine();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartCoroutine(ExecWithCoroutine());
                
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                StartCoroutine(RunCooldown(4f));

            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                StartCoroutine(MoveCube());
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                cameraMatrix = Camera.main.projectionMatrix;
            }

            Camera.main.projectionMatrix = cameraMatrix1;
        }

        IEnumerator MoveCube()
        {
            cube.position = Vector3.right * px0;
            float t = 0;
            while(t < 1f)
            {
                float px = Mathf.Lerp(px0, px1, t);
                cube.position = Vector3.right * px;
                yield return null;
                t += Time.deltaTime;
            }
        }

        void ExecWithouCoroutine()
        {
            Debug.Log($"1 {Time.frameCount}");
            Debug.Log($"2 {Time.frameCount}");
            Debug.Log($"3 {Time.frameCount}");
            Debug.Log($"4 {Time.frameCount}");
            Debug.Log($"5 {Time.frameCount}");
        }

        IEnumerator RunCooldown(float waitSeconds)
        {
            IsCooldown = true;
            yield return new WaitForSeconds(waitSeconds);
            IsCooldown = false;
        }

        IEnumerator ExecWithCoroutine()
        {
            Debug.Log($"1 {Time.frameCount}");
            yield return new WaitForSeconds(1f);
            Debug.Log($"2 {Time.frameCount}");
            yield return new WaitForSeconds(1f);
            Debug.Log($"3 {Time.frameCount}");
            yield return new WaitForSeconds(1f);
            Debug.Log($"4 {Time.frameCount}");
            yield return new WaitForSeconds(1f);
            Debug.Log($"5 {Time.frameCount}");
        }
    }
}
