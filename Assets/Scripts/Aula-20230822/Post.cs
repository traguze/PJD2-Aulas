using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aula_20230822
{
    [System.Serializable]
    public class Post
    {
        public int userId;
        public int id;
        public string title;
        [TextArea(2,6)]
        public string body;
    }
}
