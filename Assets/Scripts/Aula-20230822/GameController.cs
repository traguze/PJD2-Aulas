using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Linq;


namespace Aula_20230822
{
    public class GameController : MonoBehaviour
    {
        public List<Post> posts;
        public List<Comment> comments;

        public GameObject[] gos;

        public List<int> listInt;
        

        private void Awake()
        {
            posts = LoadJson<List<Post>>("posts");
            //comments = LoadJson<List<Comment>>("comments");

            LoadJson("comments", out comments);

            gos = FindObjectsOfType<GameObject>();

            foreach (var item in gos)
            {
                //var b = item.GetComponent<Block1x1Tag>();
                //if(b != null)
                //{
                //    item.SetActive(false);
                //}

                if(item.TryGetComponent<Block1x1Tag>(out var block))
                {
                    block.gameObject.SetActive(false);
                }
            }

            FindPostComments();
        }

        void FindPostComments()
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (var comment in comments)
            {
                if(counts.TryGetValue(comment.postId, out var v))
                {
                    counts[comment.postId] = v + 1;
                } else
                {
                    counts.Add(comment.postId, 1);
                }
            }

            int i = 0;
            foreach (var kvp in counts)
            {
                Debug.Log($"{kvp.Key} {kvp.Value}");
                
            }

            listInt = comments.Select(c => c.postId).ToList();
            var g = comments.GroupBy(g => g.postId).Select(s => new {
                Key = s.Key,
                Value = s.Count()
            }).ToDictionary(d => d.Key).OrderBy(o => o.Key).First();

            Debug.Log($"> {g.Key} {g.Value}");
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
