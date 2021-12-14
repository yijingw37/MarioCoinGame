using TMPro;
using UnityEngine;

/// <summary>
/// Displays the score in whatever text component is store in the same game object as this
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// There will only ever be one ScoreKeeper object, so we just store it in
    /// a static field so we don't have to call FindObjectOfType(), which is expensive.
    /// </summary>
    public static ScoreManager Singleton;

    public AudioClip winSound;

    /// <summary>
    /// Add points to the score
    /// </summary>
    /// <param name="points">Number of points to add to the score; can be positive or negative</param>
    public static void ScorePoints(int points)
    {
        Singleton.ScorePointsInternal(points);

        if (Singleton.Score == Singleton.winningScore) {
            Singleton.Win();
        }
    }

    public static void Lose()
    {
        Singleton.SetLose();
    }

    private int winningScore;

    /// <summary>
    /// Current score
    /// </summary>
    public int Score;

    /// <summary>
    /// Text component for displaying the score
    /// </summary>
    private TMP_Text scoreDisplay;

    /// <summary>
    /// Initialize Singleton and ScoreDisplay.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        Singleton = this;
        scoreDisplay = GetComponent<TMP_Text>();
        winningScore = FindObjectsOfType<Coin>().Length;
        // Initialize the display
        ScorePointsInternal(0);
    }

    /// <summary>
    /// Internal, non-static, version of ScorePoints
    /// </summary>
    /// <param name="delta"></param>
    private void ScorePointsInternal(int delta)
    {
        Score += delta;
        scoreDisplay.text = Score.ToString();
    }

    private void Win() {
        GameObject obj = GameObject.Find("AudioPlayer");
        AudioSource aud = obj.GetComponent<AudioSource>();
        aud.PlayOneShot(winSound);
        scoreDisplay.text = "You have won!!";
        Time.timeScale = 0;
    }

    private void SetLose() {
        scoreDisplay.text = "You have lost!!";
    }
}
