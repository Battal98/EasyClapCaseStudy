using CollectableModule.Data;
using CollectableModule.Data.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    Sphere,
    Cube,
    Cylinder,
}

public class CollectableManager: MonoBehaviour
{
    #region Self Variables

    #region Serializable Variables

    [SerializeField]
    private CollectableData collectableData;

    [SerializeField]
    private CollectableType collectableType;

    #endregion

    #region Private Variables



    #endregion

    #endregion

    private void Awake()
    {
        collectableData = GetCollectableData();
    }

    private CollectableData GetCollectableData()
    {
        return Resources.Load<CD_Collectable>("Datas/CD_Collectable").CollectableData[(int)collectableType];
    }

    public CollectableType GetCollectableType()
    {
        return collectableType;
    }
    public float ReduceScaleFactor()
    {
        return collectableData.ReduceScaleFactor;
    }

    public float IncreaseScaleFactor()
    {
        return collectableData.IncreaseScaleFactor;
    }
    public int ScoreValue()
    {
        return collectableData.ScoreValue;
    }
}
