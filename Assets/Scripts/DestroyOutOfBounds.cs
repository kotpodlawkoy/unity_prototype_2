using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float lowerConstraint, upperConstraint, leftConstraint, rightConstraint;
    private ObjectPooling pool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool = GameObject.Find ( "Object Pool" ).GetComponent < ObjectPooling > ();
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.z < lowerConstraint || transform.position.z > upperConstraint )
        {
            pool.DeactivatePoolObject ( gameObject );
        }
        if ( transform.position.x < leftConstraint || transform.position.x > rightConstraint )
        {
            pool.DeactivatePoolObject ( gameObject );
        }
    }
}
