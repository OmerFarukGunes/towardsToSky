using UnityEngine;
public class MarketSystem : MonoBehaviour
{
    public AudioSource click;
    public AudioSource nonClick;
    public void shield()
    {
       
        int costOfShield = PlayerPrefs.GetInt("costOfShield");    
        if (PlayerPrefs.GetInt("collectCoin") >= costOfShield && PlayerPrefs.GetInt("collectCoin") >= 0 &&  PlayerPrefs.GetInt("costOfShield") < 1250)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfShield", (PlayerPrefs.GetInt("timeOfShield") + 2));
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin")-costOfShield));
            PlayerPrefs.SetInt("costOfShield", (PlayerPrefs.GetInt("costOfShield") +250));
            if (PlayerPrefs.GetInt("costOfShield") == 1250)
                PlayerPrefs.SetInt("costOfShield", (PlayerPrefs.GetInt("costOfShield") + 250));
        }
        else if(PlayerPrefs.GetInt("collectCoin") >= costOfShield && PlayerPrefs.GetInt("collectCoin") > 0 && PlayerPrefs.GetInt("costOfShield") == 1500)
        {
            click.Play();
            PlayerPrefs.SetInt("saveBomb", 1);
            PlayerPrefs.SetInt("timeOfShield", (PlayerPrefs.GetInt("timeOfShield") + 1));
            PlayerPrefs.SetInt("costOfShield", (PlayerPrefs.GetInt("costOfShield") + 1000));
        }
        else
            nonClick.Play();
    }
    public void x2()
    {
      
        int costOfx2 = PlayerPrefs.GetInt("costOfX2");
        if (PlayerPrefs.GetInt("collectCoin") >= costOfx2 && PlayerPrefs.GetInt("collectCoin")>=0 && PlayerPrefs.GetInt("costOfX2")< 1250)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfX2", (PlayerPrefs.GetInt("timeOfX2") + 2));
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfx2));
            PlayerPrefs.SetInt("costOfX2", (PlayerPrefs.GetInt("costOfX2") + 250));
            if (PlayerPrefs.GetInt("costOfX2") == 1250)
                PlayerPrefs.SetInt("costOfX2", (PlayerPrefs.GetInt("costOfX2") + 250));
        }
        else if (PlayerPrefs.GetInt("collectCoin") >= costOfx2 && PlayerPrefs.GetInt("collectCoin") > 0 && PlayerPrefs.GetInt("costOfX2") == 1500)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfX2", (PlayerPrefs.GetInt("timeOfX2") + 1));
            PlayerPrefs.SetInt("x2Score", 1);
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfx2));
            PlayerPrefs.SetInt("costOfX2", (PlayerPrefs.GetInt("costOfX2") + 1000));
        }
        else
            nonClick.Play();
    }
    public void magnet()
    {
     
        int costOfMagnet = PlayerPrefs.GetInt("costOfMagnet");
        if (PlayerPrefs.GetInt("collectCoin") >= costOfMagnet && PlayerPrefs.GetInt("collectCoin") >= 0 && PlayerPrefs.GetInt("costOfMagnet") < 1250)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfMagnet", (PlayerPrefs.GetInt("timeOfMagnet") + 2));
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfMagnet));
            PlayerPrefs.SetInt("costOfMagnet", (PlayerPrefs.GetInt("costOfMagnet") + 250));
            if (PlayerPrefs.GetInt("costOfMagnet") == 1250)
                PlayerPrefs.SetInt("costOfMagnet", (PlayerPrefs.GetInt("costOfMagnet") + 250));
        }
        else if (PlayerPrefs.GetInt("collectCoin") >= costOfMagnet && PlayerPrefs.GetInt("collectCoin") > 0 && PlayerPrefs.GetInt("costOfMagnet") == 1500)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfMagnet", (PlayerPrefs.GetInt("timeOfMagnet") + 1));
            PlayerPrefs.SetInt("collectDGold", 1);
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfMagnet));
            PlayerPrefs.SetInt("costOfMagnet", (PlayerPrefs.GetInt("costOfMagnet") + 1000));
        }
        else
            nonClick.Play();
    }
    public void magnetPower()
    {
      
        int costOfMagnetPower = PlayerPrefs.GetInt("costOfMagnetPower");
        if (PlayerPrefs.GetInt("collectCoin") >= costOfMagnetPower && PlayerPrefs.GetInt("collectCoin") >= 0 && PlayerPrefs.GetInt("costOfMagnetPower") < 1250)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfMagnetPower", (PlayerPrefs.GetInt("timeOfMagnetPower") + 5));
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfMagnetPower));
            PlayerPrefs.SetInt("costOfMagnetPower", (PlayerPrefs.GetInt("costOfMagnetPower") + 250));
            if (PlayerPrefs.GetInt("costOfMagnetPower") == 1250)
                PlayerPrefs.SetInt("costOfMagnetPower", (PlayerPrefs.GetInt("costOfMagnetPower") + 250));
        }
        else if (PlayerPrefs.GetInt("collectCoin") >= costOfMagnetPower && PlayerPrefs.GetInt("collectCoin") > 0 && PlayerPrefs.GetInt("costOfMagnetPower") == 1500)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfMagnetPower", (PlayerPrefs.GetInt("timeOfMagnetPower") + 1));
            PlayerPrefs.SetInt("collectBGold", 1);
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfMagnetPower));
            PlayerPrefs.SetInt("costOfMagnetPower", (PlayerPrefs.GetInt("costOfMagnetPower") + 1000));
        }
        else
            nonClick.Play();
    }
    public void speed()
    {
        
        int costOfSpeed = PlayerPrefs.GetInt("costOfSpeed");
        if (PlayerPrefs.GetInt("collectCoin") >= costOfSpeed && PlayerPrefs.GetInt("collectCoin") >= 0 && PlayerPrefs.GetInt("costOfSpeed") < 1250)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfSpeed", (PlayerPrefs.GetInt("timeOfSpeed") + 1));
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfSpeed));
            PlayerPrefs.SetInt("costOfSpeed", (PlayerPrefs.GetInt("costOfSpeed") + 250));
            if (PlayerPrefs.GetInt("costOfSpeed") == 1250)
                PlayerPrefs.SetInt("costOfSpeed", (PlayerPrefs.GetInt("costOfSpeed") + 250));
        }
        else if (PlayerPrefs.GetInt("collectCoin") >= costOfSpeed && PlayerPrefs.GetInt("collectCoin") > 0 && PlayerPrefs.GetInt("costOfSpeed") == 1500)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfSpeed", (PlayerPrefs.GetInt("timeOfSpeed") + 1));
            PlayerPrefs.SetInt("savingSpeed", 1);
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfSpeed));
            PlayerPrefs.SetInt("costOfSpeed", (PlayerPrefs.GetInt("costOfSpeed") + 1000));
        }
        else
            nonClick.Play();
    }
    public void chest()
    {
       
        int costOfChest = PlayerPrefs.GetInt("costOfChest");
        if (PlayerPrefs.GetInt("collectCoin") >= costOfChest && PlayerPrefs.GetInt("collectCoin") >= 0 && PlayerPrefs.GetInt("costOfChest") < 1250)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfChest", (PlayerPrefs.GetInt("timeOfChest") + 5));
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfChest));
            PlayerPrefs.SetInt("costOfChest", (PlayerPrefs.GetInt("costOfChest") + 250));
            if (PlayerPrefs.GetInt("costOfChest") == 1250)
                PlayerPrefs.SetInt("costOfChest", (PlayerPrefs.GetInt("costOfChest") + 250));
        }
        else if (PlayerPrefs.GetInt("collectCoin") >= costOfChest && PlayerPrefs.GetInt("collectCoin") > 0 && PlayerPrefs.GetInt("costOfChest") == 1500)
        {
            click.Play();
            PlayerPrefs.SetInt("timeOfChest", (PlayerPrefs.GetInt("timeOfChest") + 10));
            PlayerPrefs.SetInt("collectCoin", (PlayerPrefs.GetInt("collectCoin") - costOfChest));
            PlayerPrefs.SetInt("costOfChest", (PlayerPrefs.GetInt("costOfChest") + 1000));
        }
        else
            nonClick.Play();
    }
}