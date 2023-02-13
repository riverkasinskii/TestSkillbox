using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;

    private Vector2 moveInput;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
        
    private void Update()
    {
        RunHorizontal();
        RunVertical();
        FlipSprite();
    }

    private void OnMove(InputValue inputValue)
    {
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
}
