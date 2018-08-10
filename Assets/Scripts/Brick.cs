using UnityEngine;

// Class that manage brick.
public class Brick : MonoBehaviour
{
  // Array of brick additional sprites(to show damage taken by brick).
  public Sprite[] sprites;
  // Bricks counter.
  public static int counter = 0;
  // Audio clip with sound/effect of destroying.
  public AudioClip crack;
  // Number of hits brick has taken.
  private int hits;
  // Level manager.
  private LevelManager level_manager;
  // Explosion.
  public GameObject explosion;

  // Initialization.
  private void Start()
  {
    // Actualize number of hits.
    this.hits=0;
    // Actualize bricks counter.
    counter++;
    // Get level manager.
    this.level_manager=GameObject.FindObjectOfType<LevelManager>();
  } // End of Start

  // When something collide with brick.
  private void OnCollisionExit2D(Collision2D collision)
  {
    // Play crack sound.
    AudioSource.PlayClipAtPoint(this.crack,this.transform.position);
    // Actualize number of hits.
    this.hits++;
    // If object was hit maximum numer of times.
    if(this.hits>this.sprites.Length)
    {
      // Destroy brick.
      BrickDestroy();
    }
    // If object was not hit maximum numer of times.
    else
    {
      // Change sprite.
      SpriteChange();
    }
  } // End of onCollisionEnter2D

  // Change sprite.
  private void SpriteChange()
  {
    // If there is sprite to load.
    if(this.sprites[this.hits-1])
    {
      this.GetComponent<SpriteRenderer>().sprite=this.sprites[this.hits-1];
    }
    // If there is no sprite.
    else
    {
      Debug.LogError("Brick sprite missing");
    }
  } // End of SpriteChange

  // Destroy brick.
  private void BrickDestroy()
  {
    // Generate explosion.
    Vector3 explosion_pos = this.transform.position;
    explosion_pos.z=-5;
    GameObject explosion=Instantiate(this.explosion,explosion_pos,Quaternion.identity);
    explosion.GetComponent<ParticleSystem>().startColor=this.GetComponent<SpriteRenderer>().color;
    // Actualize counter.
    counter--;
    // Destroy object.
    Destroy(this.gameObject);
    // Send information to level manager that brick was destroyed.
    this.level_manager.BrickDestroyed();
  } // End of BrickDestroy
} // End of Brick