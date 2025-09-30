using UnityEngine;
public class CraneData : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private CraneConfig _config;
    
    [Header("Crane Datas")]
    [SerializeField] private float _upMoveSpeed;
    [SerializeField] private float _downMoveSpeed;
    [SerializeField] private float _northMoveSpeed;
    [SerializeField] private float _southMoveSpeed;
    [SerializeField] private float _westMoveSpeed;
    [SerializeField] private float _eastMoveSpeed;
    
    [Header("Crane Move Limits")]
    [SerializeField] private float _yMaxPos;
    [SerializeField] private float _yMinPos;
    [SerializeField] private float _xMaxPos;
    [SerializeField] private float _xMinPos;
    [SerializeField] private float _zMaxPos;
    [SerializeField] private float _zMinPos;

    public float YMaxPos
    {
        get => _yMaxPos;
        set => _yMaxPos = value;
    }

    public float YMinPos
    {
        get => _yMinPos;
        set => _yMinPos = value;
    }

    public float XMaxPos
    {
        get => _xMaxPos;
        set => _xMaxPos = value;
    }

    public float XMinPos
    {
        get => _xMinPos;
        set => _xMinPos = value;
    }

    public float ZMaxPos
    {
        get => _zMaxPos;
        set => _zMaxPos = value;
    }

    public float zMinPos
    {
        get => _zMinPos;
        set => _zMinPos = value;
    }

    private float _minValue = 0;
    private float _maxValue = 50;
    
    //Public Properties
    public float UpMoveSpeed
    {
        get => _upMoveSpeed;
        set
        {
            var speed = Mathf.Clamp(value, _minValue, _maxValue);
            _upMoveSpeed = speed;
        }
    }
    
    public float DownMoveSpeed
    {
        get => _downMoveSpeed;
        set
        {
            var speed = Mathf.Clamp(value, _minValue, _maxValue);
            _downMoveSpeed = speed;
        }
    }
    
    public float NorthMoveSpeed
    {
        get => _northMoveSpeed;
        set
        {
            var speed = Mathf.Clamp(value, _minValue, _maxValue);
            _northMoveSpeed = speed;
        }
    }
    
    public float SouthMoveSpeed
    {
        get => _southMoveSpeed;
        set
        {
            var speed = Mathf.Clamp(value, _minValue, _maxValue);
            _southMoveSpeed = speed;
        }
    }
    
    public float WestMoveSpeed
    {
        get => _westMoveSpeed;
        set
        {
            var speed = Mathf.Clamp(value, _minValue, _maxValue);
            _westMoveSpeed = speed;
        }
    }
    
    public float EastMoveSpeed
    {
        get => _eastMoveSpeed;
        set
        {
            var speed = Mathf.Clamp(value, _minValue, _maxValue);
            _eastMoveSpeed = speed;
        }
    }

    private CraneDataConfigurator _craneDataConfigurator;

    private void Awake()
    {
        _craneDataConfigurator = new CraneDataConfigurator(this);
        _craneDataConfigurator.ConfigureData(_config);
    }
}