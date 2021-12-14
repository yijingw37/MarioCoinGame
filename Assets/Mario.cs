using UnityEngine;

public class Mario : MonoBehaviour
{
    /// <summary>
    /// Our rigid body component
    /// Used to apply forces so we can move around
    /// </summary>
    private Rigidbody2D rigidBody;

    private bool isGrounded;

    public AudioClip gameOverSound;

    public AudioClip fireSound;

    private int bullets;

    /// <summary>
    /// Prefab for the orbs we will shoot
    /// </summary>
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && bullets>0 && !isGrounded && Time.timeScale!=0)
        {
            bullets--;
            GameObject obj = GameObject.Find("AudioPlayer");
            AudioSource aud = obj.GetComponent<AudioSource>();
            aud.PlayOneShot(fireSound);
            var bullet = Instantiate(BulletPrefab, transform.position + transform.right*0.5f, Quaternion.identity);
            Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.velocity = transform.right * 2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            //rigidBody.AddForce(new Vector2(0f,8f), ForceMode2D.Impulse);
            isGrounded = false;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f,0f);
        transform.position += movement * Time.deltaTime * 5f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (col.collider.GetComponent<Enemy>() != null)
        {
            GameObject obj = GameObject.Find("AudioPlayer");
            AudioSource aud = obj.GetComponent<AudioSource>();
            aud.PlayOneShot(gameOverSound);
            ScoreManager.Lose();
            Time.timeScale = 0;
        }
    }

    public void increaseBullets() {
        bullets++;
    }
}
