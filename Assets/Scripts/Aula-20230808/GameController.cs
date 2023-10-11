using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Aula_20230808
{

    public class GameController : MonoBehaviour
    {
        public List<Hero> Heroes = new List<Hero>();

        private void Awake()
        {
            var go = new GameObject("PlayerController");
            go.AddComponent<Aula_20230808.PlayerController>();


            Heroes.Add(new Hero()
            {
                Name = "Pedrinho",
                Health = 2,
                Level = 4,
                Xp = 100,
            });
            Heroes.Add(new Hero()
            {
                Name = "Claudio",
                Health = 10,
                Level = 45,
                Xp = 234,
            });
            Heroes.Add(new Hero()
            {
                Name = "Megaman",
                Health = 100,
                Level = int.MaxValue,
                Xp = int.MaxValue
            });

            File.WriteAllText(Application.persistentDataPath + "/text.csv", "Name,Health,Level,Xp");

        }
    }

}