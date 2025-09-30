using System;
using UnityEngine;
 
namespace CodeBase
{
    public class CraneButton : MonoBehaviour
    {
        [SerializeField] private CraneMoveDirection _moveDirection;
    
        public static Action<CraneMoveDirection> _onCraneButtonPressed;

        public void CallButtonPressEvent()
        {
            _onCraneButtonPressed?.Invoke(_moveDirection);
        }
    }
}