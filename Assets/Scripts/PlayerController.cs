using Cinemachine;
using Unity.VisualScripting;
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
    [SerializeField] float vacuumRange = 20f;
    
    /* Does not work yet, needs to get set up. 
    [SerializeField] float verticalSensitivity;
    [SerializeField] float horizontalSensitivity;
    */

    Rigidbody rb;
    Transform targetTransform;
    CinemachineVirtualCamera playerCamera;
    Vector2 move;
    float moveX;
    float moveY;
    bool isSprinting;
    bool isJumping = false;
    bool isVacuuming = false;



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
        Vector3 movement = new Vector3(moveX, 0f, moveY);
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

    public void OnVacuum()
    {
        isVacuuming = !isVacuuming;
        Vacuum();
    }

    void Vacuum()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, playerCamera.transform.forward, out hit, vacuumRange) && hit.transform.tag == "ObjectToPickUp" && isVacuuming)
        {
            Transform target = hit.transform.GetComponent<Transform>();
            targetTransform = target.transform;

            targetTransform.position = transform.position;
            targetTransform.gameObject.SetActive(false);
            isVacuuming = false;
            //Debug.DrawLine(transform.position, hit.point, Color.yellow);
        }
        else if (Physics.Raycast(transform.position, playerCamera.transform.forward, out hit, vacuumRange) && hit.transform.tag == "ObjectToPlace" && isVacuuming)
        {
            Transform objectPlacement = hit.transform.GetComponent<Transform>();

            targetTransform.gameObject.SetActive(true);
            targetTransform.tag = "Untagged";
            targetTransform.position = objectPlacement.position;
            objectPlacement.GetComponent<MeshRenderer>().enabled = false;
            
            isVacuuming = false;

        }
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
