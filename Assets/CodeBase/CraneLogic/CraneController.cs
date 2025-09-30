using CodeBase;
using HTC.UnityPlugin.Vive;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    [SerializeField] private CraneMover _mover;
    [SerializeField] private Transform _cargo;

    public void MoveCrane(CraneMoveDirection direction)
    {
        _mover.MoveCrane(direction,_cargo,ViveInput.GetPress(HandRole.RightHand,ControllerButton.Trigger));
    }
    private void OnEnable()
    {
        CraneButton._onCraneButtonPressed += MoveCrane;
    }
    private void OnDisable()
    {
        CraneButton._onCraneButtonPressed -= MoveCrane;
    }
}