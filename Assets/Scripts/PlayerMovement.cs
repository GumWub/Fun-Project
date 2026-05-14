using UnityEngine;

public class PlayerMovement : MovementBluePrint
{
    [SerializeField] private uint MoveSpeed;
    [SerializeField] private uint GravityForce;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameObject Camera;
    [SerializeField] private Transform CameraTarget;
    [SerializeField] private float speed;
    [SerializeField] private float smoothtime;
    [SerializeField] private Vector3 Offset;

    private Vector3 velocity;
    private Vector3 GravityVector;

    private void Awake()
    {
        GravityVector = Vector3.zero;
        GravityVector.y = -GravityForce;
    }

    private void Update()
    {
        if (!characterController.isGrounded)
            characterController.Move(GravityVector * Time.deltaTime);


    }

    private void LateUpdate()
    {
        Camera.transform.position = Vector3.SmoothDamp(Camera.transform.position, CameraTarget.position + Offset, ref velocity, smoothtime, speed);
    }
    public override void Move(Vector3 Direction) 
    {
        Vector3 movement = Direction * MoveSpeed * Time.deltaTime;
        characterController.Move(movement);
    }

    public override void fly()
    {

    }


    public override void Jump()
    {
        Debug.Log("Jump");
    }
}