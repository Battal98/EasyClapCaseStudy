using TMPro;

namespace UIModules.Controllers
{
    public class LevelPanelController
    {

        #region Self Variables

        #region Private Variables

        private readonly TextMeshProUGUI _gemText;
        private readonly TextMeshProUGUI _moneyText;
        private readonly TextMeshProUGUI _levelText;

        #endregion

        #endregion

        public LevelPanelController(TextMeshProUGUI gemText, TextMeshProUGUI moneyText)
        {
            _gemText = gemText;
            _moneyText = moneyText;
        }

        public void SetGemScoreText(int gemValue)
        {
            _gemText.text = gemValue.ToString();
        }

        public void SetMoneyScoreText(int moneyValue)
        {
            _moneyText.text = moneyValue.ToString();
        }
    }
}
