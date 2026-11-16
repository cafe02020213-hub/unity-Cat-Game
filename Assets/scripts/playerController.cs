using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 HorizontalInput;
    private Animator animator;
    public GameObject trapPrefab;
    private Vector2 mousePosition;
    public TMP_Text scoreText;
    private int score = 0;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update() {
      rb.linearVelocity = HorizontalInput * speed;
    }
    void SpawnTrap(){
        GameObject trap = Instantiate(trapPrefab, mousePosition, Quaternion.identity);
    }

   public void Move(InputAction.CallbackContext context){
    HorizontalInput = context.ReadValue<Vector2>();
    
    animator.SetBool("isMoving", true);
    if(context.canceled){
        animator.SetBool("isMoving", false);
        print("movement stopped");
    }
   }
   private void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.CompareTag("enemy")){
        Destroy(collision.gameObject);
        mousePosition = transform.position;
        score++;
        scoreText.text = "Score: " + score.ToString();
        Invoke("SpawnTrap", 1f);
    }
    if(collision.gameObject.CompareTag("trampa")){
        SceneManager.LoadScene("GameOver");
        print("Game Over");
        }   
   }
}
