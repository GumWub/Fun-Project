using UnityEngine;

public abstract class CameraBluePrint : MonoBehaviour
{
    public abstract void Rotate(Vector3 rotation);
    public abstract void Follow(Vector3 targetPosition);
}
