using UnityEngine;
using Random = UnityEngine.Random;
public class backGround : MonoBehaviour
{
    public GameObject AL;
    public GameObject AL1;
    public GameObject AL2;
    public GameObject AL3;
    public GameObject AR;
    public GameObject AR1;
    public GameObject AR2;
    public GameObject AR3;
    public GameObject[] ARS;
    public GameObject[] ALS;
    public Rigidbody2D physic;
    float time = 0;
    int randomPos;
    int randomAir;
    int randomXL;
    int randomXR;
    int randomCreate;
    void Start()
    {
        ARS = new GameObject[4];
        ALS = new GameObject[4];
        ARS[0] = Instantiate(AR, new Vector2(9, 12), Quaternion.identity);
        ARS[1] = Instantiate(AR1, new Vector2(9, 12), Quaternion.identity);
        ARS[2] = Instantiate(AR2, new Vector2(9, 12), Quaternion.identity);
        ARS[3] = Instantiate(AR3, new Vector2(9, 12), Quaternion.identity);
        ALS[0] = Instantiate(AL, new Vector2(-9,12), Quaternion.identity);
        ALS[1] = Instantiate(AL1, new Vector2(-9, 12), Quaternion.identity);
        ALS[2] = Instantiate(AL2, new Vector2(-9, 12), Quaternion.identity);
        ALS[3] = Instantiate(AL3, new Vector2(-9, 12), Quaternion.identity);
        physic = ALS[0].GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(-2.5f, 0);
        physic = ALS[1].GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(-1.5f, 0);
        physic = ALS[2].GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(-1, 0);
        physic = ALS[3].GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(-1.25f, 0);
        physic = ARS[0].GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(1.25f, 0);
        physic = ARS[1].GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(2f, 0);
        physic = ARS[2].GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(1.75f, 0);
        physic = ARS[3].GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(1, 0);
        for(int i = 0; i < 4; i++)
        {
            ARS[i].GetComponent<SpriteRenderer>().sortingOrder = 0;
            ALS[i].GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }
    void Update()
    {
         randomPos = Random.Range(0, 2);
         randomAir = Random.Range(0, 4);
         randomXL = Random.Range(2, 8);
         randomXR = Random.Range(-4, 2);
        time += Time.deltaTime;
         randomCreate = Random.Range(5, 20);
        if (time > randomCreate)
        {
          if (randomPos == 0)
        {
                if (ARS[randomAir].GetComponent<Transform>().position.x >= 9)
                    ARS[randomAir].GetComponent<Transform>().position = new Vector2(-9, randomXL);
        }
            else if (randomPos ==1)
            {
                if (ALS[randomAir].GetComponent<Transform>().position.x <= -9)
                    ALS[randomAir].GetComponent<Transform>().position = new Vector2(9, randomXR);
            }
            time = 0;
        }
    }
}