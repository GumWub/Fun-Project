using UnityEngine;

public class PlayerMovement : MovementBluePrint
{

    [SerializeField] private uint _moveSpeed;
    [SerializeField] private CharacterController _characterController;

    [HideInInspector] public CharacterAttributesBluePrint CurrentCharacter;
    [HideInInspector] public EnvironmentPropertiesBluePrint CurrentEnvironment;

    private Vector3 _currentGravitySpeed;

    private void Awake()
    {
    }

    private void Update()
    {
        RaycastHit rayCast;

        if (!_characterController.isGrounded) 
        {
            Debug.DrawRay(transform.position, -transform.up * 10f, Color.green);
            if (Physics.Raycast(transform.position, -transform.up, out rayCast, 10f))
            {
                Debug.Log(rayCast.collider.name);
            }
            _currentGravitySpeed.y -= CurrentEnvironment.GravitationalAcceleration * Time.deltaTime; 
        }
        else
        {
            _currentGravitySpeed.y = 0;
        }
        _characterController.Move(_currentGravitySpeed);
    }
    public override void Move(Vector3 direction, Vector3 rotation) 
    {
        Vector3 playerRotation = transform.rotation.eulerAngles + rotation;
        transform.rotation = Quaternion.Euler(playerRotation);
        Vector3 movement = (transform.right * direction.x + transform.up * direction.y + transform.forward * direction.z) * _moveSpeed * Time.deltaTime;
        _characterController.Move(movement);
    }

    public override void Fly()
    {

    }

    public override void Jump()
    {
        Debug.Log("Jump");
    }
}