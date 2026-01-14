using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    
    private float horizontalMovement;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        rb.linearVelocityX = speed * horizontalMovement;
    }

    public void OnMove(InputAction.CallbackContext context){
        var movementVec = context.ReadValue<Vector2>();
        horizontalMovement = movementVec.x;

        Debug.Log($"horizontalMovement = {horizontalMovement}");
    }
}
