using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MovementBluePrint movement;
    private Vector3 direction;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump();
        }

        HandleMovementInput();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                return;
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void HandleMovementInput()
    {
        direction = Vector3.zero;

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

        movement.Move(direction);
    }
}
