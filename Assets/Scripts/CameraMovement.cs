using UnityEngine;

public class CameraMovement : CameraBluePrint
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _followSpeed = 20f;//recommended value: PlayerSpeed * 2
    [SerializeField] private float _cameraRadius;

    private Vector3 _camRotation;

    private void Awake()
    {
        _camRotation = Vector3.zero;
    }

    private void LateUpdate()
    {
        Follow(_playerPosition.position);
    }

    public override void Follow(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition - transform.forward * _cameraRadius, 1 - Mathf.Exp(-_followSpeed * Time.deltaTime));
    }

    public override void Rotate(Vector3 rotation)
    {
        
        _camRotation += rotation;
        _camRotation.x = Mathf.Clamp(_camRotation.x, -89, 89);
        transform.rotation = Quaternion.Euler(_camRotation);
    }
}
