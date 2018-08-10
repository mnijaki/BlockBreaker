using UnityEngine;

// Class that manage ball.
public class Ball : MonoBehaviour
{
  // Information if game has started.
  public bool started;
  // Paddle.
  private Paddle paddle;
  // Starting offset of the ball(Vector from paddle to the ball).
  private Vector3 offset;

  // Initialization.
  private void Start()
  {
    // Set started flag to false.
    this.started=false;
    // Set paddle.
    this.paddle=GameObject.FindObjectOfType<Paddle>();
    // Get starting offset.
    this.offset=this.transform.position-this.paddle.transform.position;    
  } // End of Start

  // Update (called once per frame).
  private void Update()
  {
    // If game has not started.
    if(!this.started)
    {
      // Actualize offset of the ball.
      this.transform.position=this.paddle.transform.position+this.offset;      
      // If user presed left mouse button.
      if(Input.GetMouseButtonDown(0))
      {
        // Actualize information that game has started.
        this.started=true;
        // If auto play.
        if(FindObjectOfType<Paddle>().auto_play)
        {
          // Set starting velocity of the ball.
          this.GetComponent<Rigidbody2D>().velocity=new Vector2(-5.0F,20.0F);
        }
        // If normal play.
        else
        {
          // Set starting velocity of the ball.
          this.GetComponent<Rigidbody2D>().velocity=new Vector2(-5.0F,10.0F);
        }
      }
    }
	} // End of Update

  // When something collide with ball.
  private void OnCollisionEnter2D(Collision2D other)
  {
    // If game has started.
    if(this.started)
    {
      // Play ball bounce.
      this.GetComponent<AudioSource>().Play();
    }
  } // End of OnCollisionEnter2D

  // When something collide with ball.
  private void OnCollisionExit2D(Collision2D other)
  {
    // If game has started.
    if(this.started)
    {
      // Change ball velocity (will ensure that ball will not fall into bouncing loop).
      this.GetComponent<Rigidbody2D>().velocity+=new Vector2(Random.Range(0.0F,0.3F),Random.Range(0.0F,0.3F));
    }
  } // End of OnCollisionExit2D
} // End of Ball