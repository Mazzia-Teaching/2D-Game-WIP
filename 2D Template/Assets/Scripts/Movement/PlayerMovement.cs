using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    
    private float horizontalMovement;
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void FixedUpdate(){
        rb.linearVelocityX = speed * horizontalMovement;
    }
    
    public void OnMove(InputAction.CallbackContext context){
        var movementVector = context.ReadValue<Vector2>();
        horizontalMovement = movementVector.x;

        Debug.Log($"horizontalMovement = {horizontalMovement}");
    }
}
