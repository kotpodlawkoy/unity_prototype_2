using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range ( minSpeed, maxSpeed );
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate ( Vector3.forward * speed * Time.deltaTime );
    }
}
