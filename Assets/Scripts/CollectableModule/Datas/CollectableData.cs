using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollectableModule.Data
{
    [System.Serializable]
    public class CollectableData
    {
        public CollectableType Type;
        public float ReduceScaleFactor;
        public float IncreaseScaleFactor;
        public int ScoreValue;
    } 
}
