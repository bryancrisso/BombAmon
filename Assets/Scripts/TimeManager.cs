using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public AmonMovement amonMovement;
    public MissileSpawner missileSpawner;
    public float timeToWait = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StatsManager");
    }

    IEnumerator StatsManager()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeToWait);
            BoostStats();
        }
    }

    void BoostStats()
    {
        amonMovement.speed += 0.5f;
        missileSpawner.missileSpawnRate += 0.5f;
    }
}