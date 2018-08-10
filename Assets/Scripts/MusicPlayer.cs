using UnityEngine;

// Class that handle background music in the game.
public class MusicPlayer : MonoBehaviour
{
  // Single static instance of MusicPlayer (Singelton pattern).
  private static MusicPlayer instance = null;

  // Function called before 'Start()', just after prefab is instantiated.
  private void Awake()
  {
    // If there is instance of game music.
    if(instance!=null)
    {
      // Destroy game music player (just in case some minor bug will happen).
      Destroy(this.gameObject);
    }
    // If there is no instance of game music.
    else
    {
      // Save instance.
      instance=this;
      // Make sure that music will not stop after loading another scene.
      GameObject.DontDestroyOnLoad(this.gameObject);
    }
  } // End of Awake
} // End of MusicPlayer