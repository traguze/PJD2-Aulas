using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aula_20230822
{
    [System.Serializable]
    public class Comment
    {
        public int postId;
        public int id;
        public string email;
        public string name;
        [TextArea(2,6)]
        public string body;

        public override string ToString()
        {
            return $"Comment id:{id} postId:{postId} name:{name}";
        }
    }
}
