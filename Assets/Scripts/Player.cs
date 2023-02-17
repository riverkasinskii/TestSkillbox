using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;    
    
    private Vector2 moveInput;

    private new Rigidbody2D rigidbody2D;    
    private Animator animator;
    private Shooter shooter;
        
    private bool isAlive = true;        

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();        
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
        Fire();
    }

    private void Fire()
    {
        if (!isAlive)
        {
            return;
        }  
        if (shooter != null)
        {
            shooter.isFiring = true;
        }        
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

        bool playerHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerHorizontalSpeed);        
    }

    private void RunVertical()
    {
        Vector2 verticalVelocity = new Vector2(rigidbody2D.velocity.x, moveInput.y * runSpeed);
        rigidbody2D.velocity = verticalVelocity;
        rigidbody2D.gravityScale = 0f;
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        
        if (playerHasHorizontalSpeed)
        {            
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);
        }        
    }

    public bool GetAliveState()
    {
        return isAlive = false;
    }        
}
