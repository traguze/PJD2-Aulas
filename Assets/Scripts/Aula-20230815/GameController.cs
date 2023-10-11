using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Aula_20230815
{

    public class GameController : MonoBehaviour
    {
        public List<Hero> Heroes = new List<Hero>();

        public List<Hero> Heroes2 = new List<Hero>();

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

            //SerializeHeroesCsv();

            //SerializeHeroesXml();
            //DeserializeHeroesXml();

            SerializeHeroesJson();
            //DeserializeHeroesJson();
        }

        protected void SerializeHeroesCsv()
        {
            List<string> lines = new List<string>();

            lines.Add($"Name,Health,Level,Xp");

            

            foreach (var hero in Heroes)
            {
                lines.Add(hero.Serialize());
            }

            File.WriteAllLines(Application.dataPath + "/heroes.csv", lines);
        }

        protected void SerializeHeroesXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Hero>));
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true
            };
            XmlWriter writer = XmlWriter.Create(Application.dataPath + "/heroes.xml",settings);

            xmlSerializer.Serialize(writer, Heroes);
        }

        protected void DeserializeHeroesXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Hero>));
            XmlReader reader = XmlReader.Create(Application.dataPath + "/heroes.xml");

            var obj = xmlSerializer.Deserialize(reader);
            Heroes2 = obj as List<Hero>;
        }

        protected void SerializeHeroesJson()
        {
            var json = JsonUtility.ToJson(Heroes,true);
            File.WriteAllText(Application.dataPath + "/heroes.json", json);
        }

        protected void DeserializeHeroesJson()
        {
            var json = File.ReadAllText(Application.dataPath + "/heroes.json");
            var hero = JsonUtility.FromJson<List<Hero>>(json);
            Debug.Log(hero.ToString());
        }
    }

}