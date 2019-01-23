using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    [SerializeField]
    int attackingPlayer; // which player scores into this goal
    [SerializeField]
    GameManagerScript gameMan; // this will hold a reference to the game manager script
    [SerializeField]
    ParticleSystem partSys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnCollisionEnter2D function
    // When ball collides with goal, GoalScored() is called in GameManagerScript, pass the player who scored as parameter
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "Ball")
        {
            gameMan.GoalScored(attackingPlayer);
            partSys.transform.position = new Vector2(partSys.transform.position.x, other.transform.position.y);
            partSys.Play();
        }
    }
}
