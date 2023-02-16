using UnityEngine;

public class Health : MonoBehaviour
{    
    [SerializeField] private int score = 50;
    [SerializeField] private int health = 50;

    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();        

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Player player = GetComponent<Player>();
            if (player != null)
            {
                player.GetAliveState();
            }
            Die();
        }
    }

    private void Die()
    {        
        scoreKeeper.ModifyScore(score);        
        Destroy(gameObject);
    }

    public int GetHealth()
    { 
        return health; 
    }  
}
