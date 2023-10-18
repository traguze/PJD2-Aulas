using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace API_DND
{
    [System.Serializable]
    public class ResourceListDTO
    {
        public int count;
        public ItemListRef[] results;
    }
}
