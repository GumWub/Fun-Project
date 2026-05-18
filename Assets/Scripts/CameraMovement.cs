using UnityEngine;

public class CameraMovement : CameraBluePrint
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _maxFollowSpeed;


    private Vector3 _velocity;

    private void LateUpdate()
    {
        Follow(_playerPosition.position);
    }

    public override void Follow(Vector3 targetPosition)
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime, _maxFollowSpeed);
    }

    public override void Rotate(Vector3 rotation)
    {
        Vector3 camRotation = transform.rotation.eulerAngles;
        camRotation += rotation;
        transform.rotation = Quaternion.Euler(camRotation);
    }
}
