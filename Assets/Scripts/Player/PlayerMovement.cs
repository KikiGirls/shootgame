using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 6f;

    private Rigidbody rb;
    
    private Vector3 movement;
    
    private PlayerManager playerManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
    private void FixedUpdate()
    {
        Move();

        FaceTarget();

    }

    private void FaceTarget()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        
        RaycastHit floorHit;
        
        bool isTouchingFloor = Physics.Raycast(cameraRay, out floorHit, 100);
        if (isTouchingFloor)
        {
            Vector3 v3 = floorHit.point - transform.position;
            v3.y = 0;
            
            Quaternion rotation = Quaternion.LookRotation(v3);
            transform.rotation = rotation;
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        movement = new Vector3(horizontal, 0, vertical).normalized;
        if (movement != Vector3.zero)
        {
            playerManager.state = PlayerManager.states.walk; 
            
            movement *= Speed * Time.deltaTime;

            rb.MovePosition(rb.position + movement);
        }
        else
        {
            playerManager.state = PlayerManager.states.idle;
        }
        
    }
}
