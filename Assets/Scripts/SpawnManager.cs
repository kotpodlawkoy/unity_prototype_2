using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float topBorder, leftBorder, rightBorder, bottomBorder;
    public float topIndent;
    public float startDelay = 2f, spawnInterval = 10f, maxSpawnTime;
    private static System.Random rand = new ();
    private ObjectPooling pool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake ()
    {
        pool = GameObject.Find ( "Object Pool" ).GetComponent < ObjectPooling > ();
    }
    void Start()
    {
        
        InvokeRepeating ( "SpawnRandomAnimal", startDelay, spawnInterval );
    }

    // Update is called once per frame
    void Update()
    {
        //spawnInterval = GetNewSpawnPos ();
    }

    void SpawnRandomAnimal ()
    {
        int animalType = Random.Range ( 0, animalPrefabs.Length );
        float animalX = Random.Range ( 0, 2 * ( topBorder - bottomBorder ) + rightBorder - leftBorder );
        Quaternion negQua = Quaternion.Euler( 0f, -90f, 0f);
        Quaternion posQua = Quaternion.Euler( 0f, 90f, 0f);
        if ( animalX < topBorder - bottomBorder )
        {
            pool.ActivatePoolObject ( animalPrefabs [ animalType ],
                          new Vector3 ( leftBorder,
                                        animalPrefabs [ animalType ].transform.position.y,
                                        bottomBorder + animalX / topIndent ),
                          animalPrefabs [ animalType ].transform.rotation * negQua ); 
        }
        else if ( animalX < topBorder - bottomBorder + rightBorder - leftBorder )
        {
            pool.ActivatePoolObject ( animalPrefabs [ animalType ],
                          new Vector3 ( leftBorder + animalX - topBorder + bottomBorder,
                                        animalPrefabs [ animalType ].transform.position.y,
                                        topBorder ),
                          animalPrefabs [ animalType ].transform.rotation ); 
        }
        else
        {
            pool.ActivatePoolObject ( animalPrefabs [ animalType ],
                          new Vector3 ( rightBorder,
                                        animalPrefabs [ animalType ].transform.position.y,
                                        bottomBorder + ( animalX - topBorder + bottomBorder - rightBorder + leftBorder ) / topIndent ),
                          animalPrefabs [ animalType ].transform.rotation * posQua ); 
        }
        CancelInvoke ( "SpawnRandomAnimal" );
        spawnInterval = BetaDistribution () * maxSpawnTime;
        InvokeRepeating ( "SpawnRandomAnimal", spawnInterval, spawnInterval );
    }

    float BetaDistribution ()
    {
        float alpha = 2f, beta = 3f;
        float  x, y; 
        do
        {
            x = Mathf.Pow ( ( float ) rand.NextDouble (), 1f / alpha );
            y = Mathf.Pow ( ( float ) rand.NextDouble (), 1f / beta );
            
        }
        while ( x + y > 1f );
        return ( x / ( x + y ) );

    }
}
