using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{

    public float speed = 5;
    public int minTimeToDestroy = 8;
    public int maxTimeToDestroy = 15;
    public Transform explosionPoint;

    System.Random random = new System.Random();
    private Rigidbody2D rb2d;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2 (0, -speed);
        rb2d.velocity = movement;
        StartCoroutine("MissileTimer");
    }

    IEnumerator MissileTimer()
    {
        float timeToDestroy = (random.Next(minTimeToDestroy, maxTimeToDestroy))/10f;
        yield return new WaitForSeconds(timeToDestroy);
        GetComponent<SpriteRenderer>().enabled = false;
        Vector3 explosionLocation = explosionPoint.position;
        GameObject explosionInstantiation = Instantiate(explosion, explosionLocation, transform.rotation);
        Destroy(explosionInstantiation,0.7f);
        Destroy(gameObject);
    }

}