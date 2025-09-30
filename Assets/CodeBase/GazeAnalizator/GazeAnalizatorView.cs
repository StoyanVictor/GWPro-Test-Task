using System.Collections;
using UnityEngine;
public class GazeAnalizatorView : MonoBehaviour
{
    [SerializeField] private GameObject _gazeAnalizator;
    [SerializeField] private GazeZoneDetector _gazeZoneDetector;
    [SerializeField] private TextMesh _analizatorText;
    [SerializeField] private Material _displayMat;

    [SerializeField] private float _colorChangeDuration = 0.5f;
    
    private bool _isDisplayActive;
    private Coroutine _colorChangeCoroutine;

    private void Awake()
    {
        DisableDisplay();
        SetupVisualState(false);
    }

    private void Update()
    {
        
        if(_isDisplayActive)ShowDistance();
        else StopShowDistance();
    }
    private void StopShowDistance()
    {
        _analizatorText.text = "";
    }
    private void ShowDistance()
    {
        _analizatorText.text = $"Distance\n{Mathf.Round(_gazeZoneDetector.Distance)}m";
    }
    private void StartColorChange(Color targetColor)
    {
        // Останавливаем предыдущую корутину, если она активна
        if (_colorChangeCoroutine != null)
        {
            StopCoroutine(_colorChangeCoroutine);
        }
        
        _colorChangeCoroutine = StartCoroutine(ChangeColorSmoothly(targetColor));
    }

    private IEnumerator ChangeColorSmoothly(Color targetColor)
    {
        Color startColor = _displayMat.color;
        float elapsedTime = 0f;

        while (elapsedTime < _colorChangeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / _colorChangeDuration;
            
            _displayMat.color = Color.Lerp(startColor, targetColor, t);
            
            yield return null;
        }
        _displayMat.color = targetColor;
        _colorChangeCoroutine = null;
    }
    public void EnableDisplay()
    {
        _isDisplayActive = true;
        StartColorChange(Color.green);
    }
    public void DisableDisplay()
    {
        _isDisplayActive = false;
        StartColorChange(Color.black);
    }
    public void SetupVisualState(bool isActive)
    {
        _gazeAnalizator.SetActive(isActive);
    }
}