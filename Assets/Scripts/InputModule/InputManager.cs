using CoreGameModule.Signals;
using Data.ValueObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables
    [SerializeField]
    private PlayerType playerType;
    [SerializeField] 
    private bool isJoystick;
    [SerializeField] 
    private Joystick joystick;
    [SerializeField] 
    private InputManager inputManager;
    [SerializeField]
    private List<PlayerManager> playerRBList = new List<PlayerManager>();

    #endregion

    #region Private Variables

    private PlayerData _playerData;

    #endregion

    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _playerData = GetPlayerData();
    }

    private PlayerData GetPlayerData()
    {
        return Resources.Load<CD_Player>("Datas/CD_Player").PlayerData;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerType == PlayerType.Player2)
            {
                playerType = PlayerType.Player1;
                CoreGameSignals.Instance.onSetCameraTarget?.Invoke(playerRBList[(int)playerType].transform, (int)playerType);
            }
            else
            {
                playerType = PlayerType.Player2;
                CoreGameSignals.Instance.onSetCameraTarget?.Invoke(playerRBList[(int)playerType].transform, (int)playerType);
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (isJoystick)
            {
                JoystickMove(playerRBList[(int)playerType].GetRigidBody(), _playerData);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerRBList[(int)playerType].GetRigidBody().velocity = Vector3.zero;
        }
    }

    private void JoystickMove(Rigidbody _rigidbody,
            PlayerData _playerMovementData)
    {
        Vector3 _movement = new Vector3(joystick.Horizontal * _playerMovementData.PlayerJoystickSpeed,
            0,
            joystick.Vertical * _playerMovementData.PlayerJoystickSpeed);

        _rigidbody.velocity = _movement;
        if (_movement != Vector3.zero)
        {
            Quaternion _newDirect = Quaternion.LookRotation(_movement);
            _rigidbody.transform.GetChild(0)
                .rotation = _newDirect;
        }
    }
}

public enum PlayerType
{
    Player1,
    Player2,
}
