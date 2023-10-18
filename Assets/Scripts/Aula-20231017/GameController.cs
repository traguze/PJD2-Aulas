using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using API_DND;

namespace AULA_20231017
{

    public class GameController : MonoBehaviour
    {
        protected DndClient client;

        [SerializeField]
        protected TMP_Dropdown dropdownClasses;

        public ItemListRef[] classes;

        private void Awake()
        {
            InitializeRefs();

            client = new DndClient();

            //var req = UnityWebRequest.Get("https://www.dnd5eapi.co/api/classes/paladin");
            StartCoroutine(client.GetClasses("", GenericApiResponse));
            StartCoroutine(client.GetEquipment("greatsword", GenericApiResponse));
            StartCoroutine(client.GetRaces("elf", GenericApiResponse));

            StartCoroutine(client.GetMonsters("", GenericApiResponse));
            StartCoroutine(client.GetSpells("", GenericApiResponse));

            LoadClasses();
        }

        protected void InitializeRefs()
        {
            dropdownClasses = SceneManager.GetActiveScene().GetRootGameObjects()
                .Where(go => go.name == "Canvas")
                .Select(canvas => canvas.GetComponentInChildren<TMP_Dropdown>())
                .First();
            dropdownClasses.ClearOptions();
        }

        protected void LoadClasses()
        {
            StartCoroutine(client.GetClasses("", (data) => {
                var list = GenericParseData<ResourceListDTO>(data);
                classes = list.results;
                List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
                options.AddRange(
                    list.results
                    .Select(r => new TMP_Dropdown.OptionData(r.name))
                    .ToList()
                );
                dropdownClasses.AddOptions(options);
            }));
        }

        protected void GenericApiResponse(string data)
        {
            Debug.Log(data);
        }

        protected T GenericParseData<T>(string data)
        {
            return JsonUtility.FromJson<T>(data);
        }
    }

}