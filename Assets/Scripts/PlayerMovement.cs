using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    
    private Vector3 isoRight;
    private Vector3 isoUp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        isoRight = new Vector3(1, 0, 1).normalized;
        isoUp = new Vector3(1, 0, -1).normalized;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Vertical"); 
        float vertical = Input.GetAxisRaw("Horizontal");     

        Vector3 moveDir = (isoRight * horizontal + isoUp * vertical).normalized;
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }
}