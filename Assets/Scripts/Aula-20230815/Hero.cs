using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

namespace Aula_20230815
{

    
    [System.Serializable]
    public class Hero
    {
        
        [XmlAttribute]
        public string Name;

        [XmlAttribute]
        public int Health;

        [XmlAttribute]
        public int Level;

        [XmlAttribute]
        public int Xp;

        public override string ToString()
        {
            return $"Hero Name:{Name} Health:{Health} Level:{Level} Xp:{Xp}";
        }

        public string Serialize()
        {
            return $"{Name},{Health},{Level},{Xp}";
        }
    }
}
