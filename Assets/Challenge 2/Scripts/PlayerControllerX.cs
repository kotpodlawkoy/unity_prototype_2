using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool _allow = true;
    public float timeToReload = 1f;

    void Start ()
    {
        InvokeRepeating ( "AllowSpawn", 0f, timeToReload );
    }
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && _allow)
        {
            SpawnDog ();
            _allow = false;
            CancelInvoke ( "AllowSpawn" );
        }
        else if ( !_allow )
        {
            InvokeRepeating ( "AllowSpawn", timeToReload, 1f );
        }
    }
    void SpawnDog ()
    {
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            _allow = false;
        }
    }
    void AllowSpawn ()
    {
        _allow = true;
    }
}
