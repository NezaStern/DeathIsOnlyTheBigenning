using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameManager gm;


    public float playerSpeed = 10f;
    public float bigerTimes = 0.05f;

    public float offset = 0;
    public Vector3 scale;

    public Rigidbody2D rb;
    public GameObject playerObject;

    Vector2 movingSpeed;
    public Vector3 temp;

    Vector2 lastPos;
    Vector2 newPos;

    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //player speed depending on the distance of the mouse
        var dist = Vector2.Distance(rb.transform.position, mousePos);

        //gets mouse position and moves player twoards the mouse pos
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, playerSpeed * dist * Time.deltaTime /2);

        newPos = rb.transform.position;

        //calculate player speed
        var movingSpeed = (newPos - lastPos).magnitude / Time.deltaTime;
        //print(movingSpeed);

        lastPos = rb.transform.position;

        //rotate towards the mouse
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "food")
        {
            //makes player biger in size
            temp = transform.localScale;
            temp.x += bigerTimes;
            temp.y += bigerTimes;
            transform.localScale = temp;

            scale = temp;
            
            //print(scale);

            gm.points++;

            //destroys food on collision
            Destroy(collision.gameObject);
        }
    }
}
