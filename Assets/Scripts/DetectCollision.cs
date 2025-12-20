using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int animalHealth;
    private float currentHealth;
    private ObjectPooling pool;
    public int animalDamage;
    public int playerDamage;
    
    public GameObject BackgroundBar;
    public GameObject HpBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake ()
    {
        pool = GameObject.Find ( "Object Pool" ).GetComponent < ObjectPooling > ();
    }
    void Start()
    {
       currentHealth = animalHealth; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter ( Collider other )
    {
        float backgroundScale = BackgroundBar.transform.localScale.x;
        if ( other.gameObject.CompareTag ( "Projectile" ) )
        {
            if ( ( currentHealth - playerDamage ) <= 0 )
            {
                pool.DeactivatePoolObject ( gameObject );
            }
            else
            {
                currentHealth -= playerDamage;
                HpBar.transform.localScale = new Vector3 ( backgroundScale * currentHealth / animalHealth,
                                                           HpBar.transform.localScale.y,
                                                           HpBar.transform.localScale.z );
            }
            pool.DeactivatePoolObject ( other.gameObject );
        }

        if ( other.gameObject.CompareTag ( "Player" ) )
        {
            PlayerController playerController = other.gameObject.GetComponent < PlayerController > (); 
            float? hp = playerController.PlayerHealth;
            if ( hp == null )
            {
                Debug.LogError ( "hp == null, ERROR" );
            }
            if ( ( hp - animalDamage ) <= 0 )
            {
                pool.DeactivatePoolObject ( other.gameObject );
            }
            else
            {
                playerController.PlayerHealth -= animalDamage;
            }
            pool.DeactivatePoolObject ( gameObject );
        }
    }
}
