using TMPro;

namespace CodeBase
{
    public class HelpInfoShower 
    {
        private TextMeshProUGUI _infoText;

        public HelpInfoShower(TextMeshProUGUI meshProUGUI)
        {
            _infoText = meshProUGUI;
        }

        public void ShowMessage(string message)
        {
            _infoText.text = message;
        }
    }
}