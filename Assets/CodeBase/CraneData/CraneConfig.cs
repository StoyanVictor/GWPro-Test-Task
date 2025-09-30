using UnityEngine;

[CreateAssetMenu(fileName = "CraneConfig", menuName = "CraneConfigs/CreateCraneConfig")]
public class CraneConfig : ScriptableObject
{
   [SerializeField] private float _upMoveSpeed;
   [SerializeField] private float _downMoveSpeed;
   [SerializeField] private float _northMoveSpeed;
   [SerializeField] private float _southMoveSpeed;
   [SerializeField] private float _westMoveSpeed;
   [SerializeField] private float _eastMoveSpeed;

   [SerializeField] private float _yMaxPos;
   [SerializeField] private float _yMinPos;
   [SerializeField] private float _xMaxPos;
   [SerializeField] private float _xMinPos;
   [SerializeField] private float _zMaxPos;
   [SerializeField] private float _zMinPos;

   public float YMaxPos => _yMaxPos;
   public float YMinPos => _yMinPos;
   public float XMaxPos => _xMaxPos;
   public float XMinPos => _xMinPos;
   public float ZMaxPos => _zMaxPos;
   public float zMinPos => _zMinPos;
   public float UpMoveSpeed => _upMoveSpeed;
   public float DownMoveSpeed => _downMoveSpeed;
   public float NorthMoveSpeed => _northMoveSpeed;
   public float SouthMoveSpeed => _southMoveSpeed;
   public float WestMoveSpeed => _westMoveSpeed;
   public float EastMoveSpeed => _eastMoveSpeed;
}
