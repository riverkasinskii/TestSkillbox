using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private GameObject player;
    private new Rigidbody2D rigidbody2D;

    private bool isPlayerState;

    private void Start()
    {                
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }        

    private void Update()
    {
        isPlayerState = player.transform.position.x > transform.position.x;

        MoveEnemy(isPlayerState);
        FlipEnemyFacing();
        PlayerTracking();        
    }

    private void MoveEnemy(bool state)
    {
        if (state)
        {
            rigidbody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);
    }

    private void PlayerTracking()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                 player.transform.position,
                                                 moveSpeed * Time.deltaTime);
    }
        
    
}
