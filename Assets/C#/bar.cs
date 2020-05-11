using UnityEngine;
using UnityEngine.UI;
public class bar : MonoBehaviour
{
    public Image magnetBar;
    public Image magnetTimer;
    public Image shieldBar;
    public Image shieldTimer;
    public Image boostBar;
    public Image boostTimer;
    public Image x2Bar;
    public Image x2Timer;
    float timeLeftBoost;
    float timeLeftShield;
    float timeLeftMagnet;
    float timeLeftX2;
    Movement movement;
    magnetsUI magnetsUI;
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("character").GetComponent<Movement>();
        magnetsUI = GameObject.FindGameObjectWithTag("collect").GetComponent<magnetsUI>();
        timeLeftX();
        timeLeftS();
        timeLeftM();
        timeLeftB();
    }
    public void timeLeftS()
    {
        timeLeftShield = (8 + PlayerPrefs.GetInt("timeOfShield"));
    }
    public void timeLeftM()
    {
        timeLeftMagnet = (8 + PlayerPrefs.GetInt("timeOfMagnet"));
    }
    public void timeLeftB()
    {
        timeLeftBoost = (2 + PlayerPrefs.GetInt("timeOfSpeed"));
    }
    public void timeLeftX()
    {
        timeLeftX2 = (8+ PlayerPrefs.GetInt("timeOfX2"));
    }
    void Update()
    {
        if(movement.isSecurity == false)
        {
            shieldTimer.GetComponent<Image>().enabled = true;
            shieldBar.GetComponent<Image>().enabled = true;
           if (timeLeftShield > 0)
        {
                timeLeftShield -= Time.deltaTime;
            shieldBar.fillAmount = timeLeftShield / (8 + PlayerPrefs.GetInt("timeOfShield"));
        }
        }
        else{
            shieldTimer.GetComponent<Image>().enabled = false;
            shieldBar.GetComponent<Image>().enabled = false;
            shieldBar.fillAmount = 1;
            timeLeftS();
        }
        if (movement.isSpeed == false)
        {
            boostTimer.GetComponent<Image>().enabled = true;
            boostBar.GetComponent<Image>().enabled = true;
            if (timeLeftBoost > 0)
            {
                timeLeftBoost -= Time.deltaTime;
                boostBar.fillAmount = timeLeftBoost / (2 + PlayerPrefs.GetInt("timeOfSpeed"));
            }
        }
        else
        {
            boostTimer.GetComponent<Image>().enabled = false;
            boostBar.GetComponent<Image>().enabled = false;
            boostBar.fillAmount = 1;
            timeLeftB();
        }
        if (magnetsUI.isOkey)
        {
            magnetTimer.GetComponent<Image>().enabled = true;
            magnetBar.GetComponent<Image>().enabled = true;
            if (timeLeftMagnet > 0)
            {
                timeLeftMagnet -= Time.deltaTime;
                magnetBar.fillAmount = timeLeftMagnet / (8 + PlayerPrefs.GetInt("timeOfMagnet"));
            }
        }
        else
        {
            magnetTimer.GetComponent<Image>().enabled = false;
            magnetBar.GetComponent<Image>().enabled = false;
            magnetBar.fillAmount = 1;
            timeLeftM();
        }
        if(movement.multipleCoin == 2)
        {
            x2Timer.GetComponent<Image>().enabled = true;
            x2Bar.GetComponent<Image>().enabled = true;
            if (timeLeftX2 > 0)
            {
                timeLeftX2 -= Time.deltaTime;
                x2Bar.fillAmount = timeLeftX2 / (8 + PlayerPrefs.GetInt("timeOfX2"));
            }
        }
        else
        {
            x2Timer.GetComponent<Image>().enabled = false;
            x2Bar.GetComponent<Image>().enabled = false;
            x2Bar.fillAmount = 1;
            timeLeftX();
        }
    }
}
