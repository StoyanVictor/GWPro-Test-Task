using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class CraneView : MonoBehaviour

    {
        [SerializeField] private TextMeshProUGUI _meshProUGUI;
        
        [SerializeField] private string _message;
        
        private HelpInfoShower _infoShower;

        private void Awake()
        {
            _infoShower = new HelpInfoShower(_meshProUGUI);
        }
        public void RestInfoString()
        {
            _infoShower.ShowMessage("");
        }
        public void ShowMessage()
        {
            _infoShower.ShowMessage(_message);
        }
    }
}