using CoreGameModule.Signals;
using LevelModule.Signals;
using SaveLoadModule.Enums;
using SaveLoadModule.Signals;
using ScoreModule.Data;
using ScoreModule.Data.ScriptableObjects;
using UIModules.Signals;
using UnityEngine;

namespace ScoreModule
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private ScoreData _scoreData;
        private const int _uniqeID = 1234;

        private int _totalMoneyScore;
        private int _totalGemScore;

        private void Start()
        {
            InitLevelData();
        }
        private void InitLevelData()
        {
            _scoreData = GetScoreData();
            if (!ES3.FileExists(_scoreData.GetKey().ToString() + $"{_uniqeID}.es3")) 
            {
                if (!ES3.KeyExists(_scoreData.GetKey().ToString()))
                {
                    _scoreData = GetScoreData();
                    SaveGameScoreData(_scoreData,_uniqeID);
                }
            }
            LoadGameScoreData();
        }

        private ScoreData GetScoreData()
        {
            return Resources.Load<CD_Score>("Datas/CD_Score").ScoreData;
        }

        private void LoadGameScoreData()
        {
            _scoreData = SaveLoadSignals.Instance.onLoadScoreData?.Invoke(SaveLoadType.ScoreData, _uniqeID);
            SetGameScore();
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onUpdateGreenScore += OnUpdateGreenScore;
            CoreGameSignals.Instance.onUpdateBlueScore += OnUpdateBlueScore;
        }
        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onUpdateGreenScore -= OnUpdateGreenScore;
            CoreGameSignals.Instance.onUpdateBlueScore -= OnUpdateBlueScore;
        }
        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void SetGameScore()
        {
            UISignals.Instance.onUpdateBlueScore?.Invoke(_scoreData.TotalBlueScore);
            UISignals.Instance.onUpdateGreenScore?.Invoke(_scoreData.TotalGreenScore);
        }

        private void OnUpdateBlueScore(int _amount)
        {
            _scoreData.TotalBlueScore += _amount;
            UISignals.Instance.onUpdateBlueScore?.Invoke(_scoreData.TotalBlueScore);
            SaveGameScoreData(_scoreData, _uniqeID);
        }

        private void OnUpdateGreenScore(int _amount)
        {
            _scoreData.TotalGreenScore += _amount;
            UISignals.Instance.onUpdateGreenScore?.Invoke(_scoreData.TotalGreenScore);
            SaveGameScoreData(_scoreData,_uniqeID);
        }

        private void SaveGameScoreData(ScoreData scoreData, int uniqeID) => SaveLoadSignals.Instance.onSaveScoreData?.Invoke(scoreData, uniqeID);

        private void OnApplicationQuit()
        {
            SaveGameScoreData(_scoreData, _uniqeID);
        }
    } 
}
