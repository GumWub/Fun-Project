using UnityEngine;

public class CameraMovement : CameraBluePrint
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _maxFollowSpeed = 20f;//recommended value: PlayerSpeed * 2
    [SerializeField] private float _cameraRadius;


    private Vector3 _velocity;

    private void LateUpdate()
    {
        Follow(_playerPosition.position);
    }

    public override void Follow(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition - transform.forward * _cameraRadius, 1 - Mathf.Exp(-_maxFollowSpeed * Time.deltaTime));
    }

    public override void Rotate(Vector3 rotation)
    {
        Vector3 camRotation = transform.rotation.eulerAngles;
        camRotation += rotation;
        if(Mathf.Abs(camRotation.x) > 90)
        {
            
        }
        transform.rotation = Quaternion.Euler(camRotation);
        if(transform.rotation.x > 90)
    }
}
