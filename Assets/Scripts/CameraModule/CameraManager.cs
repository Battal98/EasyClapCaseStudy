using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using Sirenix.OdinInspector;
using CoreGameModule.Signals;
using CameraModule.Enums;

namespace CameraModule
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Serializable Variables

        [SerializeField]
        private CameraStatesType cameraStates;

        [SerializeField] 
        private CinemachineStateDrivenCamera stateDrivenCamera;

        [SerializeField]
        private Animator animator;

        #endregion

        #region Private Variables
        [Space]
        [ShowInInspector] private Vector3 _initialPosition;
        private Transform target;

        #endregion

        #endregion

        private void Awake()
        {
            GetInitialPosition();
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onSetCameraTarget += OnSetCameraTarget;

        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void GetInitialPosition()
        {
            _initialPosition = transform.GetChild(0).localPosition;
        }

        private void OnSetCameraTarget(Transform _target, int _cameraState)
        {
            target = _target;
            var state = (CameraStatesType)_cameraState;
            SetCameraState(state);
            if (target is null)
                return;
            stateDrivenCamera.Follow = target;
            stateDrivenCamera.Follow = target.transform;
        }

        private void SetCameraState(CameraStatesType _cameraState)
        {
            cameraStates = _cameraState;
            animator.Play(cameraStates.ToString());
        }

        private void OnPlay()
        {
            GetInitialPosition();
            SetCameraState(CameraStatesType.GameCamera1);
            stateDrivenCamera.Follow = target.transform;
        }

        private void OnReset()
        {
            OnSetCameraTarget(target, 0);
        }

#if UNITY_EDITOR

        [Button]
        public void ChangeCameraState(CameraStatesType cameraStatesType)
        {
            SetCameraState(cameraStatesType);
        }

#endif
    } 
}
