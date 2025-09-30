using UnityEngine;

public class GazeZoneDetector : MonoBehaviour
{
    [SerializeField] private float _distance;
    
    [SerializeField] private float _radius;
    
    [SerializeField] private LayerMask _mask;
    
    [SerializeField] private Transform _currentTarget;
    
    public float Distance => _distance;
    
    private void GetNearestTarget()
    {
        Collider[] gazeZones = Physics.OverlapSphere(transform.position, _radius,_mask);
        
        float nearestDistance = float.MaxValue;
        Transform nearestTarget = null;
        
        if (gazeZones.Length > 0)
        {
            foreach (var gazeZone in gazeZones)
            {
                float distanceForTarget = Vector3.Distance(transform.position, gazeZone.transform.position);
                
                if (distanceForTarget < nearestDistance)
                {
                    nearestDistance = distanceForTarget;
                    nearestTarget = gazeZone.transform;
                }
            }

            _currentTarget = nearestTarget;
        }
        else
        {
            _currentTarget = null;
        }
    }

    private void Update()
    {
        GetNearestTarget();
        if (_currentTarget != null) CalculateDistanceForTarget(_currentTarget);
    }

    public float CalculateDistanceForTarget(Transform target)
    {
        _distance = Vector3.Distance(transform.position, target.position);
        return _distance;
    }

}