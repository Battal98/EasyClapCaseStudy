using System.Collections.Generic;
using UnityEngine;

namespace CollectableModule.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CD_Collectable", menuName = "EasyClapStudy/CD_Collectable", order = 0)]
    public class CD_Collectable : ScriptableObject
    {
        public List<CollectableData> CollectableData;
    } 
}
