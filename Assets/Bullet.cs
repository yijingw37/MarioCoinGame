using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip enemySound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.GetComponent<Enemy>() != null)
        {
            GameObject obj = GameObject.Find("AudioPlayer");
            AudioSource aud = obj.GetComponent<AudioSource>();
            aud.PlayOneShot(enemySound);
            Destroy(col.gameObject);
        }
    }
}
