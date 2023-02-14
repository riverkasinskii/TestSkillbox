using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameObject player;

    private new Rigidbody2D rigidbody2D;    

    private void Start()
    {                
        rigidbody2D = GetComponent<Rigidbody2D>();        
    }        

    private void Update()
    {
        
        rigidbody2D.velocity = new Vector2(moveSpeed, 0f);        
        FlipEnemyFacing(); 
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);
    }
}
