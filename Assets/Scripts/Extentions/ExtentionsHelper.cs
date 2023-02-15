using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtentionsHelper
{
    #region Transform Jobs

    public static Transform SetZeroPosition(this Transform transform)
    {
        transform.position = Vector3.zero;
        return transform;
    }

    public static Transform SetPosX(this Transform transform, float xPos)
    {
        var pos = transform.position;
        pos.x = xPos;
        transform.position = pos;
        return transform;
    }

    public static Transform SetPosY(this Transform transform, float yPos)
    {
        var pos = transform.position;
        pos.y = yPos;
        transform.position = pos;
        return transform;
    }

    public static Transform SetPosZ(this Transform transform, float zPos)
    {
        var pos = transform.position;
        pos.z = zPos;
        transform.position = pos;
        return transform;
    }
    #endregion

    #region List Jobs
    public static void CloseAllListElements(this List<GameObject> lists)
    {
        for (int i = 0; i < lists.Count; i++)
            lists[i].SetActive(false);
    }

    public static void OpenAllListElements(this List<GameObject> lists)
    {
        for (int i = 0; i < lists.Count; i++)
            lists[i].SetActive(true);
    }

    #endregion

    public static Transform AddScaleValues(this Transform vector3, float value)
    {
        var newVec3 = new Vector3(value, value, value);
        vector3.localScale += newVec3;
        return vector3;
    }
}
