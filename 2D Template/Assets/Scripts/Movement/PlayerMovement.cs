using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public LayerMask groundMask;
    public float groundCastLength = 1f;
    public float jumpImpulseForce = 2f;

    private float horizontalMovement;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float jumpForce = 0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var groundRayCast = RaycastUtilities.CastRay(
            new RaycastUtilities.RayData<string>("groundCast", transform.position, Vector2.down,
                                                groundCastLength, groundMask));
        isGrounded = groundRayCast;      
                        
    }

    void FixedUpdate(){
        rb.linearVelocityX = speed * horizontalMovement;

        if(jumpForce > 0){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpForce = 0f;
        }
    }

    public void OnJump(InputAction.CallbackContext context){
        if(context.ReadValueAsButton() && isGrounded){
            jumpForce = jumpImpulseForce;
        }
    }

    public void OnMove(InputAction.CallbackContext context){
        var movementVector = context.ReadValue<Vector2>();
        horizontalMovement = movementVector.x;

        Debug.Log($"horizontalMovement = {horizontalMovement}");
    }
}
