using UnityEngine;
using UnityEngine.InputSystem;

public class zadanie2 : MonoBehaviour
{
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [Header("Input Actions")]
    public InputActionReference moveAction; // expects Vector2
    public InputActionReference jumpAction; // expects Button

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Pobieramy dane wejściowe (WASD)
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // Ruch względem kamery
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        Vector3 move = camRight * input.x + camForward * input.y;
        move = Vector3.ClampMagnitude(move, 1f);

        // Skok
        if (jumpAction.action.triggered)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Grawitacja
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Połączenie ruchu poziomego i pionowego
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);

        // Ruch tylko gdy niezerowy wektor
        if (finalMove != Vector3.zero)
        {
            controller.Move(finalMove * Time.deltaTime);
        }
    }
}
