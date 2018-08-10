using UnityEngine;

// Class that manage paddle. 
public class Paddle : MonoBehaviour
{
  // Flag for testing.
  public bool auto_play=false;
  // Ball.
  private Ball ball;

  // Initialization.
  private void Start()
  {
    // Get ball.
    this.ball=FindObjectOfType<Ball>();
  } // End of Start

  // Update (called once per frame).
  private void Update()
  {
    // If auto play mode.
    if(this.auto_play)
    {
      // Auto play paddle.
      PaddleAutoPlay();
    }
    // If normal play mode.
    else
    {
      // Move paddle.
      PaddleMove();
    }
  } // End of Update

  // Move paddle.
  private void PaddleMove()
  {
    // Compute mouse position in blocks (16 is number of units of screen width).
    float mouse_pos_in_blokcs = Mathf.Clamp((Input.mousePosition.x/Screen.width)*16.0F,1.5F,14.5F);
    // Actualize paddle position.
    this.transform.position=new Vector3(mouse_pos_in_blokcs,this.transform.position.y,this.transform.position.z);
  } // End of Paddle

  // Auto play paddle for testing purposes.
  private void PaddleAutoPlay()
  {
    // If game has not started then exit.
    if(!this.ball.started)
    {      
      return;     
    }    
    // Actualize paddle position.
    this.transform.position=new Vector3(this.ball.transform.position.x,this.transform.position.y,this.transform.position.z);
  } // End of PaddleAutoPlay
} // End of Paddle