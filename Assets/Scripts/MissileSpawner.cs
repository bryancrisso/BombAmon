using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{

    public GameObject missile;

    System.Random random = new System.Random();
    public int minXPosition = -90;
    public int maxXPosition = 90;
    float xPosition;

    public float missileSpawnRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawner");
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            xPosition = (random.Next(minXPosition, maxXPosition))/10f;
            Instantiate(missile, new Vector3 (xPosition,6.85f,0), Quaternion.Euler(0f,0f,-90f));
            yield return new WaitForSeconds(1f/missileSpawnRate);
        }
    }
}
