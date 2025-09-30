using UnityEngine;

public class CraneMover : MonoBehaviour
{
    [SerializeField] private float _minY;
    
    [SerializeField] private CraneData _data;
    
    public void MoveCrane(CraneMoveDirection moveDirection, Transform cargo,bool needToWork)
    {
        switch (moveDirection)
        {
            case CraneMoveDirection.Down:
                MoveSmoothly(moveDirection,cargo,cargo.position + Vector3.down,_data.DownMoveSpeed,needToWork);
                break;
            case CraneMoveDirection.Up:
                MoveSmoothly(moveDirection,cargo,cargo.position + Vector3.up,_data.UpMoveSpeed,needToWork);
                break;
            case CraneMoveDirection.West:
                MoveSmoothly(moveDirection,cargo,cargo.position + Vector3.right,_data.WestMoveSpeed,needToWork);
                break;
            case CraneMoveDirection.East:
                MoveSmoothly(moveDirection,cargo,cargo.position + Vector3.left,_data.EastMoveSpeed,needToWork);
                break;
            case CraneMoveDirection.South:
                MoveSmoothly(moveDirection,cargo,cargo.position + Vector3.back,_data.SouthMoveSpeed,needToWork);
                break;
            case CraneMoveDirection.North:
                MoveSmoothly(moveDirection,cargo,cargo.position + Vector3.forward,_data.NorthMoveSpeed,needToWork);
                break;
        }
    }
    
    private void MoveSmoothly(CraneMoveDirection moveDirection,Transform cargo, Vector3 targetPosition, float speed,bool needToWork)
    {
        Vector3 startPosition = cargo.position;

        if (needToWork && IsCurrentAxisLimited(moveDirection,cargo))
        {
            cargo.position = Vector3.Lerp(startPosition, targetPosition,speed * Time.deltaTime);
        }
    }

    private bool IsCurrentAxisLimited(CraneMoveDirection moveDirection,Transform cargo)
    {
        switch (moveDirection)
        {
            case CraneMoveDirection.Down:
                return cargo.position.y > _data.YMinPos;
            case CraneMoveDirection.Up:
                return cargo.position.y < _data.YMaxPos;
            case CraneMoveDirection.West:
                return cargo.position.x < _data.XMaxPos;
            case CraneMoveDirection.East:
                return cargo.position.x > _data.XMinPos;
            case CraneMoveDirection.North:
                return cargo.position.z < _data.ZMaxPos;
            case CraneMoveDirection.South:
                return cargo.position.z > _data.zMinPos;
        }
        return false;
    }

}