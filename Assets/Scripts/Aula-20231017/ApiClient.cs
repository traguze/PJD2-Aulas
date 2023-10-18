using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace AULA_20231017
{

    public class ApiClient
    {
        public string BaseUrl { get; protected set; }

        public string Output { get; protected set; }
        public UnityWebRequest.Result Result { get; protected set; }

        public ApiClient(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public IEnumerator Dispatch(UnityWebRequest request, Action<string> callback)
        {
            //var req = UnityWebRequest.Get("https://www.dnd5eapi.co/api/equipment/greatsword");

            yield return request.SendWebRequest();

            Result = request.result;
            switch (request.result)
            {
                case UnityWebRequest.Result.InProgress:
                    Debug.Log("In Progress");
                    break;
                case UnityWebRequest.Result.Success:
                    Output = request.downloadHandler.text;
                    callback(Output);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log($"Error {request.result} {request.responseCode}");
                    break;
                default:
                    break;
            }
        }

        

    }

}