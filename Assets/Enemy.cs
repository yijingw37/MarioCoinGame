using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float leftBound;

    public float rightBound;

    private bool dirRight;

    // Start is called before the first frame update
    void Start()
    {
        dirRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }

        if (transform.position.x >= rightBound)
        {
            dirRight = false;
        }

        if (transform.position.x <= leftBound)
        {
            dirRight = true;
        }
    }
}
