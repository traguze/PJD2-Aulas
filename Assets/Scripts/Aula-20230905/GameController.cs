using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Aula_20230822;

namespace Aula_20230905
{

    public class GameController : MonoBehaviour
    {

        public List<Comment> comments;
        void Start()
        {
            LoadJson("comments", out comments);

            Debug.Log(comments.ToListString("\n"));
            
        }

        T LoadJson<T>(string name)
        {
            var jsonFilePath = Application.dataPath + $"/Scripts/Aula-20230822/Data/{name}.json";
            var jsonString = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        void LoadJson<T>(string name, out T output)
        {
            output = LoadJson<T>(name);
        }

    }

}