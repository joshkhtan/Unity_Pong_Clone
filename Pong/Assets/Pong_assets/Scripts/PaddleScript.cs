using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField]    // Allow variable to be edited by inspector
    bool isPlayerTwo;   // Variable to affirm player input
    [SerializeField]
    float speed = 0.2f; // Speed variable of paddle per frame
    Transform myTransform;  // reference to the object's transform (change of position via user input)

    int direction = 0;  // Holds the state of the paddle. 0=still, 1=up, -1=down
    float previousPositionY;    // Store paddle's position on y-axis every frame to compare to next frame position to determine direction of movement

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        previousPositionY = myTransform.position.y;
    }

    // FixedUpdate is called once per physics tick/frame
    // is fixed to the physics engine clock, runs with same frequency regardless of device or framerate
    void FixedUpdate()
    {
       // Handle behavior for player 2's paddle
       if (isPlayerTwo)
        {
            if (Input.GetKey("o"))
                MoveUp();
            else if (Input.GetKey("l"))
                MoveDown();
        }

        // Handle behavior for player 1's paddle
        else
        {
            if (Input.GetKey("q"))
                MoveUp();
            else if(Input.GetKey("a"))
                MoveDown();
        }

        // Update the direction of movement of paddle every frame
        if (previousPositionY > myTransform.position.y)
            direction = -1;
        else if (previousPositionY < myTransform.position.y)
            direction = 1;
        else
            direction = 0;
    }

    // MoveUp function
    // Moves the player's paddle up by amount relative to speed variable along y axis
    void MoveUp()
    {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + speed);
    }

    // MoveDown function
    // Moves the player's paddle down by amount relative to speed variable along y axis
    void MoveDown()
    {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y - speed);
    }

    // LateUpdate function
    // Holds the paddle's y-axis position to compare with next frame to determine direction of movement
    void LateUpdate()
    {
        previousPositionY = myTransform.position.y; 
    }

    // OnCollisionExit2D function
    // built-in MonoBehaviour method that runs automatically when a collider within the GameObject the script is attached to comes into contact with another collider.
    private void OnCollisionExit2D(Collision2D other)
    {
        float adjust = 5 * direction;
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x, other.rigidbody.velocity.y + adjust);
    }
}
