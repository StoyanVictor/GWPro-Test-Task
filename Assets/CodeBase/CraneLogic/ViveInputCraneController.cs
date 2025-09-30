using System;
using HTC.UnityPlugin.Pointer3D;
using HTC.UnityPlugin.Vive;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase
{
    public class ViveInputCraneController : MonoBehaviour
    {
        [SerializeField] private CraneView _craneView;
    
        [SerializeField] private Pointer3DRaycaster raycaster;
    
        private MeshRenderer lastMat;

        private void Awake()
        {
            if (raycaster == null)
            {
                throw new ArgumentNullException("We dont have link to Pointer3DRaycaster");
            }
        }
        void Update()
        {
            var result = raycaster.FirstRaycastResult();

            if (result.isValid && result.gameObject != null)
            {
                _craneView.ShowMessage();
                if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger))
                {
                    VisualCollisionDetection(result,false,Color.red);
                    var a = result.gameObject.GetComponent<CraneButton>();
                    a.CallButtonPressEvent();
                }
                else
                    VisualCollisionDetection(result,true,Color.black);
            }
            else
            {
                _craneView.RestInfoString();
                Debug.Log("Промах");
            }
        }
        private void VisualCollisionDetection(RaycastResult result,bool isDetectionLose,Color color)
        {
            if (!isDetectionLose)
            {
                Debug.Log("Попал в: " + result.gameObject.name);
                lastMat = result.gameObject.GetComponent<MeshRenderer>();
                lastMat.material.color = color;
            }
            else if (isDetectionLose && lastMat != null)
            {
                lastMat.material.color = color;
            }
        }
    }
}