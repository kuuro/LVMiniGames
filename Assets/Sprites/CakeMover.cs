using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CakeMover : MonoBehaviour
{
    public float speed = 5f;  // Speed of the object
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Clicked);
        Run();
    }
    void Run()
    {
        //random speed between 150 and 400
        speed = Random.Range(50, 150);
        rb = GetComponent<Rigidbody2D>();

        // Set a random direction
        movementDirection = Random.insideUnitCircle.normalized;

        // Apply initial force
        rb.velocity = movementDirection * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 reflectDir = Vector2.Reflect(movementDirection, collision.contacts[0].normal);

        // Set the new direction and velocity
        movementDirection = reflectDir.normalized;
        rb.velocity = movementDirection * speed;
    }
    //when clicked, the object will move in a random direction
    private void Clicked()
    {
        if (Game1Manager.instance.isGameActive)
        {
            Debug.Log("Clicked");
            StartCoroutine(Game1Manager.instance.ieEndGame());
        }
    }
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        Run();
    }
}
