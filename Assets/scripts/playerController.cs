using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 HorizontalInput;
    private Animator animator;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update() {
      rb.linearVelocity = HorizontalInput * speed;
    }


   public void Move(InputAction.CallbackContext context){
    HorizontalInput = context.ReadValue<Vector2>();
    
    animator.SetBool("isMoving", true);
    if(context.canceled){
        animator.SetBool("isMoving", false);
    }
   }
}
