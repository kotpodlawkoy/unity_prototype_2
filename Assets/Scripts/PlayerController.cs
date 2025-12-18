using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float strafeSpeed;
    public float xrange, zrangeTop, zrangeLow;
    private float horizontalInput, verticalInput;
    public GameObject projectile;
    public int playerHealth = 100;
    private float _currentHealth;
    public GameObject BackgroundBar;
    public GameObject HpBar;
    public float PlayerHealth
    {
        get => _currentHealth;

        set
        {
            float backgroundScale = BackgroundBar.transform.localScale.x;
            if ( value > playerHealth || value < 0 )
            {
                _currentHealth = 100;
            }
            else
            {
                _currentHealth = value;
            }
            HpBar.transform.localScale = new Vector3 ( backgroundScale * _currentHealth / playerHealth,
                                                       HpBar.transform.localScale.y,
                                                       HpBar.transform.localScale.z );
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis ( "Vertical" );
        horizontalInput = Input.GetAxis ( "Horizontal" );
        transform.Translate ( Vector3.forward * verticalInput * strafeSpeed * Time.deltaTime );
        transform.Translate ( Vector3.right * horizontalInput * strafeSpeed * Time.deltaTime );
        if ( Input.GetKeyDown ( KeyCode.Space ) )
        {
            Instantiate ( projectile, new Vector3 ( transform.position.x, 0.5f, transform.position.z ), projectile.transform.rotation );
        }
    }
    void LateUpdate ()
    {
        if ( transform.position.x < -1 * xrange )
        {
            transform.position = new Vector3 ( -1 * xrange, transform.position.y, transform.position.z );
        }
        if ( transform.position.x > xrange )
        {
            transform.position = new Vector3 ( xrange, transform.position.y, transform.position.z );
        }
        if ( transform.position.z < zrangeLow )
        {
            transform.position = new Vector3 ( transform.position.x, transform.position.y, zrangeLow );
        }
        if ( transform.position.z > zrangeTop )
        {
            transform.position = new Vector3 ( transform.position.x, transform.position.y, zrangeTop );
        }
    }
}
