using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmonMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
        if (moveHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
        }

        anim.SetFloat("Speed", speed/3);

        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        rb2d.velocity = movement*speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "explosion")
        {
            Destroy(gameObject);
        }
    }

}
