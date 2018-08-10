using UnityEngine;
using UnityEngine.SceneManagement;

// Class that manage levels.
public class LevelManager : MonoBehaviour
{
	// Load the level.
	public void LoadLevel(string name)
  {
    SceneManager.LoadScene(name);
  } // End of LoadLevel

  // Quit.
  public void QuitRequest()
  {
    Application.Quit();
  } // End of QuitRequest

  // Load the next level.
  public void LoadNextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
  } // End of LoadNextLevel

  // Function will run after brick is destroyed.
  public void BrickDestroyed()
  {
    // If there is no more bricks. 
    if(Brick.counter<1)
    {
      // Reset number of bricks(just in case some minor bug will happen).
      Brick.counter=0;
      // Load the next level.
      LoadNextLevel();
    }
  } // End of BrickDestroyed
} // End of LevelManager