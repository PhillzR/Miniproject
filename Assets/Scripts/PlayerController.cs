using Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool debugging = false;
    [SerializeField] float currentSpeed;
    [SerializeField] float moveSpeed = 300f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float sprintSpeed = 400f;
    
    /* Does not work yet, needs to get set up. 
    [SerializeField] float verticalSensitivity;
    [SerializeField] float horizontalSensitivity;
    */

    Rigidbody rb;
    CinemachineVirtualCamera playerCamera;
    Vector2 move;
    float moveX;
    float moveY;
    bool isSprinting;
    bool isJumping = false;



    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        playerCamera = FindFirstObjectByType<CinemachineVirtualCamera>();
    }

    void Start()
    {

    }

    void Update()
    {
        DebugMovement(debugging);
    }

    private void FixedUpdate()
    {
        Move();
        Look();
        Sprint(isSprinting);
        Jump();

    }

    public void OnMove(InputValue value) 
    {
        move = value.Get<Vector2>();
        moveX = move.x;
        moveY = move.y;
    }

    void Move() 
    {
        Vector3 movement = rb.linearVelocity;
        movement.x = moveX;
        movement.y = moveY;
        Vector3 transformMove = transform.TransformVector(movement);
        rb.linearVelocity = transformMove * currentSpeed * Time.deltaTime;
    }

    void Look() 
    {
        Quaternion lookRotation = playerCamera.transform.rotation;
        transform.rotation = new Quaternion (transform.rotation.x, lookRotation.y, transform.rotation.z, transform.rotation.w);
    }

    public void OnSprint(InputValue value) 
    {
        isSprinting = !isSprinting;
    }

    void Sprint(bool sprinting) 
    {
        if (sprinting)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }
    }

    public void OnJump() 
    {
        isJumping = !isJumping;
    }

    void Jump()
    {
        if (isJumping)
        {
            rb.AddRelativeForce(Vector3.up * -Physics.gravity.y * jumpForce);
        }
        isJumping = false;
    }

    void DebugMovement(bool debugging)
    {
        if (debugging)
        {
            Debug.Log(move + "this is the direction you're moving");
        }
        else
        {
            return;
        }
    }

}
