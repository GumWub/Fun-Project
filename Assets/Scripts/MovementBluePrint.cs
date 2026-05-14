 using UnityEngine;

public abstract class MovementBluePrint : MonoBehaviour
{
    public abstract void Move(Vector3 Direction);

    public abstract void fly();

    public abstract void Jump();
}
