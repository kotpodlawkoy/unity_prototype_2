using UnityEngine;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    struct Pool
    {
        public GameObject prefab;
        public string name;
        public int amount;
    }
    [System.Serializable]
    class PoolStat
    {
        public Pool pool;
        public int currentAmount;
        public int number;
    }
    [SerializeField] private List < PoolStat > poolStats;
    [SerializeField] private List < List < GameObject > > objects;
    [SerializeField] Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake ()
    {
        objects = new List < List < GameObject > > ();
        foreach ( PoolStat pool in poolStats )
        {
            objects.Add ( new List < GameObject > () );
            for ( int i = 0; i < pool.pool.amount; i ++ )
            {
                GameObject newObject = Instantiate ( pool.pool.prefab, startPos, pool.pool.prefab.transform.rotation );
                newObject.SetActive ( false );
                objects [ pool.number ].Add ( newObject );
            }
        }
    }
    
    void Start()
    {
        
    }

    public void DeactivatePoolObject ( GameObject someObject )
    {
        someObject.SetActive ( false );
        someObject.transform.position = startPos;
    }

    public GameObject ActivatePoolObject ( GameObject someObject,
                              Vector3 somePosistion,
                              Quaternion someRotation )
    {
        PoolStat curPoolStat = poolStats.Find ( p => p.pool.name == someObject.name );
        GameObject someOutObject = objects [ curPoolStat.number ] [ curPoolStat.currentAmount ];
        curPoolStat.currentAmount = ( curPoolStat.currentAmount + 1 ) % curPoolStat.pool.amount;
        someOutObject.transform.position = somePosistion;
        someOutObject.transform.rotation = someRotation;
        someOutObject.SetActive ( true );
        return someOutObject;
    }
}
