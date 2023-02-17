using UnityEngine;

public class Health : MonoBehaviour
{    
    [SerializeField] private int score = 50;
    [SerializeField] private int health = 50;

    private ScoreKeeper scoreKeeper;
    private LevelManager levelManager;
    private AudioPlayer audioPlayer;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();        

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            audioPlayer.PlayDamageClip();
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
                levelManager.LoadGameOver();
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
