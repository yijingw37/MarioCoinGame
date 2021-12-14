using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Mario>() != null) {
            other.gameObject.GetComponent<Mario>().increaseBullets();
            GameObject obj = GameObject.Find("AudioPlayer");
            AudioSource aud = obj.GetComponent<AudioSource>();
            aud.PlayOneShot(coinSound);
            ScoreManager.ScorePoints(1);
            Destroy(gameObject);
        }
    }
}
