using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float projectileLifeTime = 5f;
    [SerializeField] private float firingRate = 0.2f;
    private float xSpeed;

    public bool isFiring;    
        
    private Coroutine firingCoroutine;
    private Player player;
    private AudioPlayer audioPlayer;

    private void Start()
    {
        player = FindObjectOfType<Player>();   
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
        
    private void Update()
    {      
        GetVectorFiring();
        Fire();        
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
           firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }        
    }
    private void GetVectorFiring()
    {
        xSpeed = player.transform.localScale.x * projectileSpeed;
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, 
                                              transform.position, 
                                              transform.rotation);

            Rigidbody2D rigidbody2D = instance.GetComponent<Rigidbody2D>();

            if (rigidbody2D != null)
            {                     
                rigidbody2D.velocity = new Vector2(xSpeed, 0f);                                                                                     
            }

            audioPlayer.PlayShootingClip();

            Destroy(instance, projectileLifeTime);

            yield return new WaitForSeconds(firingRate);
        }
    }       
}
