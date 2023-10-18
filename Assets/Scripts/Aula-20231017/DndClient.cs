using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

namespace AULA_20231017
{


    public class DndClient : ApiClient
    {
        public Func<string, Action<string>, IEnumerator> GetMonsters;
        public Func<string, Action<string>, IEnumerator> GetSpells;
        public DndClient(string baseUrl = "https://www.dnd5eapi.co") : base(baseUrl) {

            GetMonsters = CreateGetRequest($"{baseUrl}/api/monsters");
            GetSpells = CreateGetRequest($"{baseUrl}/api/spells");
        }

        protected Func<string, Action<string>, IEnumerator> CreateGetRequest(string url)
        {
            return (string index, Action<string> callback) =>
            {
                var req = UnityWebRequest.Get($"{url}/{index}");
                return Dispatch(req, callback);
            };
        }

        public IEnumerator GetClasses(string index, Action<string> callback)
        {
            var req = UnityWebRequest.Get($"{BaseUrl}/api/classes/{index}");
            return Dispatch(req, callback);
        }

        public IEnumerator GetEquipment(string index, Action<string> callback)
        {
            var req = UnityWebRequest.Get($"{BaseUrl}/api/equipment/{index}");
            return Dispatch(req, callback);
        }

        public IEnumerator GetRaces(string index, Action<string> callback)
        {
            var req = UnityWebRequest.Get($"{BaseUrl}/api/races/{index}");
            return Dispatch(req, callback);
        }
    }

}