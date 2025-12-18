using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public int damage;
    private int health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter ( Collider other )
    {
        if ( other.gameObject.CompareTag ( "Animal" ) )
        {
            if ( health - damage < 0 )
            {
                Destroy ( gameObject );
            }
            else
            {
                health -= damage;
            }
        }
    }
}
