using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int animalHealth;
    private float currentHealth;
    public int animalDamage;
    public int playerDamage;
    
    public GameObject BackgroundBar;
    public GameObject HpBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
                Destroy ( gameObject );
            }
            else
            {
                currentHealth -= playerDamage;
                HpBar.transform.localScale = new Vector3 ( backgroundScale * currentHealth / animalHealth,
                                                           HpBar.transform.localScale.y,
                                                           HpBar.transform.localScale.z );
            }
            Destroy ( other.gameObject );
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
                Destroy ( other.gameObject );
            }
            else
            {
                playerController.PlayerHealth -= animalDamage;
            }
            Destroy ( gameObject );
        }
    }
}
