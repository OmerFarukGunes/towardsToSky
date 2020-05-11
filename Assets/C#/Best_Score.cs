using UnityEngine;
using UnityEngine.UI;
public class Best_Score : MonoBehaviour
{
    public AudioSource sound;
    public Text bestScore;
    public Text coin;
     int best;
    int collectCoin;
    public Sprite[] image;
    public Button button;
    public void Start()
    {
        if (PlayerPrefs.GetInt("mute") == 1)
           button.GetComponent<Image>().sprite = image[0];
        else if (PlayerPrefs.GetInt("mute") != 1)
           button.GetComponent<Image>().sprite = image[1];
        if (PlayerPrefs.GetInt("t") >= PlayerPrefs.GetInt("oldScore"))
        {
            best = PlayerPrefs.GetInt("t");
            bestScore.text = best.ToString();
            PlayerPrefs.SetInt("oldScore", best);
        }
        else
        {
            bestScore.text = PlayerPrefs.GetInt("oldScore").ToString();
        }
        if (collectCoin != PlayerPrefs.GetInt("collectCoin"))
        {
            collectCoin = PlayerPrefs.GetInt("collectCoin");
            coin.text = collectCoin.ToString();
        }
    }
    public void Update()
    {
        if (PlayerPrefs.GetInt("mute") == 1)
            sound.mute = true;
        else if (PlayerPrefs.GetInt("mute") == 0)
            sound.mute = false;
    }
}
