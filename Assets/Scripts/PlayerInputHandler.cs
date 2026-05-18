using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MovementBluePrint _playerMovement;
    [SerializeField] private CameraBluePrint _cameraMovement;

    private bool _cursorLockState;

    private void Start()
    {
        lockCursor(true);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMovement.Jump();
        }

        float cameraRotation = handleCameraInput();
        handleMovementInput(cameraRotation);
        handleCursor();

    }

    private float handleCameraInput()
    {
        Vector3 mouseRotation = Vector3.zero;
        mouseRotation.y += Input.GetAxis("Mouse X");
        mouseRotation.x -= Input.GetAxis("Mouse Y");
        _cameraMovement.Rotate(mouseRotation);
        return mouseRotation.y;
    }

    private void handleCursor() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_cursorLockState)
            {
                lockCursor(true);
                return;
            }
            lockCursor(false);
        }
    }

    private void lockCursor(bool isTrue) 
    {
        if (isTrue)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = !isTrue;
            _cursorLockState = true;
            return;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !isTrue;
        _cursorLockState = false;
    }

    private void handleMovementInput(float cameraRotation)
    {
        Vector3 direction = Vector3.zero;
        Vector3 rotation = Vector3.zero;
        rotation.y = cameraRotation;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction.z += 1;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x -= 1;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.z -= 1;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x += 1;
        }

        _playerMovement.Move(direction, rotation);
    }
}
