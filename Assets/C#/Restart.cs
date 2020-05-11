using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    public GameObject progressBar;
    public AudioSource music;
     public GameObject image;
    public AudioSource audioButton;
    public Sprite[] sound;
 
    public void restartGame()
    {
        audioButton.Play();
        StartCoroutine(loadScreen());
    }
    public void quit()
    {
        Application.Quit();
    }
    public void market()
    {
        audioButton.Play();
        SceneManager.LoadScene("market");
    }
    public void goToMain()
    {
        audioButton.Play();
        SceneManager.LoadScene("main");
    }
    public void Mute()
    {
        if (PlayerPrefs.GetInt("mute") != 1)
        {
            PlayerPrefs.SetInt("mute", 1);
            this.GetComponent<Image>().sprite = sound[0];
        }
        else if(PlayerPrefs.GetInt("mute") == 1) {
            PlayerPrefs.SetInt("mute", 0);
            this.GetComponent<Image>().sprite = sound[1];
        }

    }
     IEnumerator loadScreen()
    {
        music.Stop();
        image.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.6f);
        progressBar.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        AsyncOperation async = SceneManager.LoadSceneAsync("map_Infinty");
        while (!async.isDone)
        {
            progressBar.GetComponent<Slider>().value = async.progress;
            yield return null;
        }
    }
}