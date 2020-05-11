using UnityEngine;
public class magnetsUI : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOkey;
    private Vector2 target;
    private Vector2 position;
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("character").transform.position; //karakterin pozisyonu her daim alındı.
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (isOkey)
        {
            if (col.gameObject.tag == "coin")
            {
                position = col.gameObject.transform.position;
                col.gameObject.transform.position = Vector2.MoveTowards(position, target,(10f+ PlayerPrefs.GetInt("timeOfMagnetPower")) * Time.deltaTime); //belli bir hızda altın kümesi karaktere doğru gitti      
            }
            if (col.gameObject.tag == "chest" && PlayerPrefs.GetInt("collectDGold") == 1 && PlayerPrefs.GetInt("collectBGold")==1)
            {
                position = col.gameObject.transform.position;
                col.gameObject.transform.position = Vector2.MoveTowards(position, target, (10f + PlayerPrefs.GetInt("timeOfMagnetPower")) * Time.deltaTime);
            }
        }
    }
}