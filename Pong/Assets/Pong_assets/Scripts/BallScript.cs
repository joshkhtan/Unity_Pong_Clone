using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]    // Tells Unity that this vairable should be changeable via the Inspector window
    float forceValue = 4.5f;    // Adds a force to make the ball move
    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();   // Assign reference to ball's GameObject's rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Reset function
    // Resets the position of the game ball
    public void Reset()
    {
        myBody.velocity = Vector2.zero;
        transform.position = new Vector2(0, 0);
        myBody.AddForce(new Vector2(forceValue * 50, 50));  // Applies force to the ball at the start of the game
        forceValue = forceValue * -1; // Reverses ball starting direction every time game resets.
    }

    // Stop function
    // Public function, causes ball to stop movement
    public void Stop()
    {
        myBody.velocity = Vector2.zero;
    }
}
