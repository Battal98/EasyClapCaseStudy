using UnityEngine;
using UIModules.Enums;
using Enums;
using UIModules.Controllers;
using System.Collections.Generic;
using TMPro;
using CoreGameModule.Signals;
using UIModules.Signals;
using LevelModule.Signals;

namespace UIModules.Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField]
        private List<GameObject> panels;
        [SerializeField]
        private TextMeshProUGUI gemText;
        [SerializeField]
        private TextMeshProUGUI moneyText;        
        #endregion

        #region Private Variables

        private UIPanelControllers _uiPanelController;
        private LevelPanelController _levelPanelController;

        #endregion

        #endregion

        private void Awake()
        {
            _uiPanelController = new UIPanelControllers(panels);
            _levelPanelController = new LevelPanelController(gemText, moneyText);
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onUpdateBlueScore += OnUpdateMoneyScore;
            UISignals.Instance.onUpdateGreenScore += OnUpdateGemScore;

            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;

            LevelSignals.Instance.onLevelInitialize += OnLevelInitialize;
            
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onUpdateBlueScore -= OnUpdateMoneyScore;
            UISignals.Instance.onUpdateGreenScore -= OnUpdateGemScore;

            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;

            LevelSignals.Instance.onLevelInitialize -= OnLevelInitialize;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnOpenPanel(PanelTypes panelParam)
        {
            _uiPanelController.OpenPanel(panelParam);
        }

        private void OnClosePanel(PanelTypes panelParam)
        {
            _uiPanelController.ClosePanel(panelParam);
        }

        private void InitPanels()
        {
            _uiPanelController.CloseAllPanel();
            _uiPanelController.OpenPanel(PanelTypes.LevelPanel);
        }

        private void OnReset()
        {
            InitPanels();
        }

        private void OnPlay()
        {
            _uiPanelController.CloseAllPanel();
            _uiPanelController.OpenPanel(PanelTypes.LevelPanel);
        }

        private void OnLevelInitialize()
        {
            InitPanels();
        }

        public void PlayButton()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        public void NextLevelButton()
        {
            LevelSignals.Instance.onNextLevel?.Invoke();
        }

        public void RestartButton()
        {
            _uiPanelController.CloseAllPanel();
            _uiPanelController.OpenPanel(PanelTypes.LevelPanel);
            LevelSignals.Instance.onRestartLevel?.Invoke();
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        private void OnUpdateGemScore(int gemValue)
        {
            _levelPanelController.SetGemScoreText(gemValue);
        }

        private void OnUpdateMoneyScore(int moneyValue)
        {
            _levelPanelController.SetMoneyScoreText(moneyValue);
        }
    } 
}
