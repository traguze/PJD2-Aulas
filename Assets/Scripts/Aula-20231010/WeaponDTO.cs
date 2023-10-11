using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace API_DND
{
    [System.Serializable]
    public class ItemListRef
    {
        public string index;
        public string name;
        public string url;
    }

    [System.Serializable]
    public class RangeRef
    {
        public float normal;
        public float Long;
    }

    [System.Serializable]
    public class CostRef
    {
        public float quantity;
        public string unit;
    }

    [System.Serializable]
    public class DamageRef
    {
        public string damage_dice;
        public ItemListRef damage_type;
    }

    [System.Serializable]
    public class WeaponDTO
    {
        public string index;
        public string name;
        public string url;
        public string weapon_category;
        public string weapon_range;
        public string category_range;
        public float weight;
        public ItemListRef equipment_category;
        public ItemListRef[] properties;
        public RangeRef range;
        public DamageRef damage;
        public DamageRef two_handed_damage;
        public CostRef cost;
    }

}