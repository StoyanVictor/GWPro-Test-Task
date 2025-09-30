using System.Collections;
using HTC.UnityPlugin.Vive;
using UnityEngine;

namespace CodeBase.GazeAnalizator
{
    public class ViveGazeAnalizatorInput : MonoBehaviour
    {
        private bool _isAnalizatorActive;
        private bool _isDisplayActive;
        private Coroutine _gripHoldCoroutine;

        public void ToggleAnalizator(GazeAnalizatorView view)
        {
            bool triggerPress = ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Trigger);
            
            if (!_isAnalizatorActive && triggerPress)
            {
                view.SetupVisualState(true);
                _isAnalizatorActive = true;
            }
            else if (_isAnalizatorActive && triggerPress)
            {
                view.SetupVisualState(false);
                _isAnalizatorActive = false;
            }
        }

        private void ToggleDisplay(GazeAnalizatorView view)
        {
            if (!_isDisplayActive)
            {
                view.EnableDisplay();
                _isDisplayActive = true;
            }
            else
            {
                view.DisableDisplay();
                _isDisplayActive = false;
            }
        }

        public void HandleGripButton(GazeAnalizatorView view)
        {
            if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Grip))
            {
                _gripHoldCoroutine = StartCoroutine(CheckGripHold(view));
            }
            
            if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Grip))
            {
                if (_gripHoldCoroutine != null)
                {
                    StopCoroutine(_gripHoldCoroutine);
                    _gripHoldCoroutine = null;
                    Debug.Log("Grip button held for less than 3 seconds");
                }
            }
        }

        private IEnumerator CheckGripHold(GazeAnalizatorView view)
        {
            yield return new WaitForSeconds(3f);

            Debug.Log("Grip button held for 3 seconds");
            ToggleDisplay(view);
            _gripHoldCoroutine = null;
        }
    }
}