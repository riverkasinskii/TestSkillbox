using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;

    private Vector2 moveInput;

    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider2D;
    private Animator animator;
        
    bool isAlive = true;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }
        
    private void Update()
    {
        if (!isAlive) 
        { 
            return; 
        }
        RunHorizontal();
        RunVertical();
        FlipSprite();
        Die();
    }

    private void OnFire(InputValue inputValue)
    {
        if (!isAlive)
        {
            return;
        }
        Instantiate(bullet, gun.position, transform.rotation);
    }

    private void OnMove(InputValue inputValue)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = inputValue.Get<Vector2>();        
    }

    private void RunHorizontal()
    {
        Vector2 horizontalVelocity = new Vector2(moveInput.x * runSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = horizontalVelocity;

        bool playerHasHorizintalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerHasHorizintalSpeed);        
    }

    private void RunVertical()
    {
        Vector2 verticalVelocity = new Vector2(rigidbody2D.velocity.x, moveInput.y * runSpeed);
        rigidbody2D.velocity = verticalVelocity;
        rigidbody2D.gravityScale = 0f;
    }

    private void FlipSprite()
    {
        bool playerHasHorizintalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizintalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);
        }        
    }

    private void Die()
    {
        if (collider2D.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            isAlive = false;
            animator.SetTrigger("Dying");            
        }
    }
}
