 using UnityEngine;

public abstract class MovementBluePrint : MonoBehaviour
{
    public abstract void Move(Vector3 Direction, Vector3 Rotation);

    public abstract void Jump();

    public abstract void Fly();
}
