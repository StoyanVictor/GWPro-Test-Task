using UnityEngine;

namespace CodeBase.GazeAnalizator
{
    public class GazeAnalizatorController : MonoBehaviour
    {
        [SerializeField] private ViveGazeAnalizatorInput _inputHandler;
        [SerializeField] private GazeAnalizatorView _analizatorView;

        private void Update()
        {
            _inputHandler.ToggleAnalizator(_analizatorView);
            _inputHandler.HandleGripButton(_analizatorView);
        }
    }
}