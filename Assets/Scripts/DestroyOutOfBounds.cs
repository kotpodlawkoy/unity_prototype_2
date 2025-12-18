using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float lowerConstraint, upperConstraint, leftConstraint, rightConstraint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.z < lowerConstraint || transform.position.z > upperConstraint )
        {
            Destroy ( gameObject );
        }
        if ( transform.position.x < leftConstraint || transform.position.x > rightConstraint )
        {
            Destroy ( gameObject );
        }
    }
}
