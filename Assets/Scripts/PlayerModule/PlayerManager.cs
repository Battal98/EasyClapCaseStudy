using CoreGameModule.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerType playerType;

    [SerializeField]
    private Rigidbody myRB;

    public Rigidbody GetRigidBody()
    {
        return myRB;
    }

    public PlayerType GetPlayerType()
    {
        return playerType;
    }
}
