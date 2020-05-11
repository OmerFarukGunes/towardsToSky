using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public Text scoreText;
    public int scores=0;
    private float startTime;
    public bool notfinished = true;
    public Text bestText;
    public float t;
    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (notfinished)
        {
        t = Time.time - startTime;  
        t = (int)t;
        t += scores;
        scoreText.text = t.ToString();
        }
        else 
        {
            PlayerPrefs.SetInt("t",((int)t));
        }
    }
} 