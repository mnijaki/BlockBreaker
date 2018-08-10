using UnityEngine;

// Class that manage bottom border.
public class BottomBorder : MonoBehaviour
{
  // When something hit bottom border.
  private void OnTriggerEnter2D(Collider2D other)
  {
    // Reset number of bricks(just in case some minor bug will happen).
    Brick.counter=0;
    // Change level.
    GameObject.FindObjectOfType<LevelManager>().LoadLevel("Lose");
  } // End of OnTriggerEnter2D
} // End of BottomBorder