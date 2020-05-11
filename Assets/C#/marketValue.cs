using UnityEngine;
using UnityEngine.UI;
public class marketValue : MonoBehaviour
{
    public Text coin;
    public GameObject starMagnet;
    public Text costMagnet;
    public GameObject starShield;
    public Text costShield;
    public GameObject starChest;
    public Text costChest;
    public GameObject starBoost;
    public Text costBoost;
    public GameObject starMagnetPower;
    public Text costMagnetPower;
    public GameObject Shield;
    public GameObject Chest;
    public GameObject Speed;
    public GameObject magnetPower;
    public GameObject magnet;
    public Text costX2;
    public GameObject starX2;
    public GameObject x2;
    public AudioSource sound;
    private void Start()
    {
        if (PlayerPrefs.GetInt("mute") == 1)
            sound.Stop();
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("costOfChest") == 2500)
            Chest.gameObject.GetComponent<Button>().interactable = false;
        if (PlayerPrefs.GetInt("costOfShield") == 2500)
            Shield.gameObject.GetComponent<Button>().interactable = false;
        if (PlayerPrefs.GetInt("costOfSpeed") == 2500)
            Speed.gameObject.GetComponent<Button>().interactable = false;
        if(PlayerPrefs.GetInt("costOfMagnetPower") == 2500)
            magnetPower.gameObject.GetComponent<Button>().interactable = false;
        if (PlayerPrefs.GetInt("costOfMagnet") == 2500)
            magnet.gameObject.GetComponent<Button>().interactable = false;
        if (PlayerPrefs.GetInt("costOfX2") == 2500)
            x2.gameObject.GetComponent<Button>().interactable = false;
        costX2.text= PlayerPrefs.GetInt("costOfX2").ToString();
        coin.text = PlayerPrefs.GetInt("collectCoin").ToString();
        costMagnet.text = PlayerPrefs.GetInt("costOfMagnet").ToString();
        costShield.text = PlayerPrefs.GetInt("costOfShield").ToString();
        costBoost.text = PlayerPrefs.GetInt("costOfSpeed").ToString();
        costChest.text = PlayerPrefs.GetInt("costOfChest").ToString();
        costMagnetPower.text = PlayerPrefs.GetInt("costOfMagnetPower").ToString();
        if (PlayerPrefs.GetInt("timeOfX2") >= 2)
            starX2.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfX2") >= 4)
            starX2.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfX2") >= 6)
            starX2.transform.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfX2") >= 8)
            starX2.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfX2") >= 10)
            starX2.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfX2") >= 11)
            starX2.transform.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnet") >= 2)
            starMagnet.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
         if (PlayerPrefs.GetInt("timeOfMagnet") >= 4)
            starMagnet.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnet") >= 6)
            starMagnet.transform.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnet") >= 8)
            starMagnet.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnet") >= 10)
            starMagnet.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnet") >= 11)
            starMagnet.transform.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfShield") >= 2)
            starShield.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfShield") >= 4)
            starShield.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfShield") >= 6)
            starShield.transform.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfShield") >= 8)
            starShield.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfShield") >= 10)
            starShield.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfShield") >= 11)
            starShield.transform.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfSpeed") >= 1)
            starBoost.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfSpeed") >= 2)
            starBoost.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfSpeed") >= 3)
            starBoost.transform.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfSpeed") >= 4)
            starBoost.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfSpeed") >= 5)
            starBoost.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfSpeed") == 6)
            starBoost.transform.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfChest") >= 5)
            starChest.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfChest") >= 10)
            starChest.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfChest") >= 15)
            starChest.transform.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfChest") >= 20)
            starChest.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfChest") >= 25)
            starChest.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfChest") == 35)
            starChest.transform.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnetPower") >= 5)
            starMagnetPower.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnetPower") >= 10)
            starMagnetPower.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnetPower") >= 15)
            starMagnetPower.transform.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnetPower") >= 20)
            starMagnetPower.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnetPower") >= 25)
            starMagnetPower.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (PlayerPrefs.GetInt("timeOfMagnetPower") >= 26)
            starMagnetPower.transform.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
}