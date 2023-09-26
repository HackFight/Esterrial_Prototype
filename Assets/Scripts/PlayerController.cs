using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public InputAction playerControls;
    public float moveSpeed = 5f;

    public PlayerInputs playerControls;
    private InputAction move;
    private InputAction look;

    private Vector2 moveDirection;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputs();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        look = playerControls.Player.Look;
        look.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
    }

    private void Update()
    {

        FaceMouse();
        Move();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 lookDirection = new Vector2
            (
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y
            );

        transform.up = lookDirection;
    }

    private void Move()
    {
        moveDirection = move.ReadValue<Vector2>();
    }
}
