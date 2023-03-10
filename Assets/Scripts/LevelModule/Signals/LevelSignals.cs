using UnityEngine.Events;
using Extentions;
using System;

namespace LevelModule.Signals
{
    public class LevelSignals : MonoSingleton<LevelSignals>
    {
        public UnityAction onLevelInitialize = delegate { };
        public UnityAction onLevelInitDone = delegate { };
        public UnityAction onClearActiveLevel = delegate { };
        public UnityAction onLevelFailed = delegate { };
        public UnityAction onLevelSuccessful = delegate { };
        public UnityAction onNextLevel = delegate { };
        public UnityAction onRestartLevel = delegate { };

        public Func<int> onGetLevel = delegate { return 0; };
    } 
}
