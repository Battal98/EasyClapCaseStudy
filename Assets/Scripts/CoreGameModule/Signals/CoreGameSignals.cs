using System;
using Extentions;
using UnityEngine.Events;
using UnityEngine;
using Enums;
using CameraModule.Enums;

namespace CoreGameModule.Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction<GameStates> onChangeGameState = delegate { };
        public UnityAction<Transform, int> onSetCameraTarget = delegate { };
        public UnityAction onReset = delegate { };
        public UnityAction onPlay = delegate { };

        public UnityAction<int> onUpdateGreenScore = delegate { };
        public UnityAction<int> onUpdateBlueScore = delegate { };
    } 
}
