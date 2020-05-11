using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class GameController : MonoBehaviour
{
    Movement movement;
    public AudioSource sound;
    public string[] finishText;
    public Text finishedText;
    public GameObject wall;
    public GameObject wall1;
    public Rigidbody2D physic;
    public Rigidbody2D physic1;
    public float velocityOfBackGround =8;
    public Text finishScore;
    public Text finishGold;
    float size;
    public GameObject block;
    public GameObject t_coin;
    public GameObject triangleCoin;
    public GameObject squareCoin;
    public GameObject chest;
    public GameObject magnet;
    public GameObject shield;
    public GameObject speed;
    public GameObject thorn;
    public GameObject[] thorns;
    public GameObject[] bonuses;
    public GameObject[] golds;
    public Rigidbody2D Physics;
    public GameObject[] midBlocks;
    public GameObject[] blocks;
    public GameObject gold;
    public GameObject bomb;
    public GameObject b_scores;
    public GameObject b_golds;
    public GameObject panel;
    score scores;
    int permissionOkey=0;
    float time = 0;
    int counter = 0;
    public bool finished = true;
    int nonRepeat = 0;
    int counterGold = 0;
    int counterMid = 0;
    int counterThorn = 0;
    bool firstCoin = false;
    int temp = 0;
    float wallx;
    float wally;
    float second=0.45f;
    float L_second =2f;
    float timeObject;
    int randomObject;
    int x; //sol ve sağ için rasgele değer üretildi
    int j;
    int y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("mute") == 1)
            sound.Stop();
            physic = wall.GetComponent<Rigidbody2D>();
        physic1 = wall1.GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(0, -velocityOfBackGround);
        physic1.velocity = new Vector2(0, -velocityOfBackGround);
        size = wall.GetComponent<BoxCollider2D>().size.y;
        movement = GameObject.FindGameObjectWithTag("character").GetComponent<Movement>();
        scores = GameObject.FindGameObjectWithTag("GameController").GetComponent<score>();
        blocks = new GameObject[10];
        bonuses = new GameObject[10];
        golds = new GameObject[10];
        midBlocks = new GameObject[4];
        thorns = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            thorns[i] = Instantiate(thorn, new Vector2(30, 0), Quaternion.identity);
            midBlocks[i] = Instantiate(block, new Vector2(30, 0), Quaternion.identity);
            Physics = thorns[i].AddComponent<Rigidbody2D>();          //bu şekilde rigidbody ekleyebilirsin.
            Physics.gravityScale = 0;
            Physics.velocity = new Vector2(0, -velocityOfBackGround);
            Physics = midBlocks[i].AddComponent<Rigidbody2D>();
            Physics.gravityScale = 0;//yerçekimim 0 olacak.
            Physics.velocity = new Vector2(0, -velocityOfBackGround);
        }
        bonuses[0] = Instantiate(speed, new Vector2(-7, 0), Quaternion.identity);
        bonuses[1] = Instantiate(shield, new Vector2(-7, 0), Quaternion.identity);
        bonuses[2] = Instantiate(magnet, new Vector2(-7, 0), Quaternion.identity);
        bonuses[3] = Instantiate(t_coin, new Vector2(-7, 0), Quaternion.identity);
        bonuses[4] = Instantiate(chest, new Vector2(-7, 0), Quaternion.identity);
        bonuses[5] = Instantiate(triangleCoin, new Vector2(-10, 0), Quaternion.identity);
        bonuses[6] = Instantiate(squareCoin, new Vector2(-7, 0), Quaternion.identity);
        bonuses[7]= Instantiate(bomb, new Vector2(-7, 0), Quaternion.identity);
        bonuses[8] = Instantiate(b_scores, new Vector2(-7, 0), Quaternion.identity);
        bonuses[9] = Instantiate(b_golds, new Vector2(-7, 0), Quaternion.identity);
        for (int i = 0; i < 10; i++)
        { //obje oluşturm haritanın dışında 
            golds[i] = Instantiate(gold, new Vector2(-7, 0), Quaternion.identity);
                blocks[i] = Instantiate(block, new Vector2(30, 0), Quaternion.identity);
                Physics = blocks[i].AddComponent<Rigidbody2D>();          //bu şekilde rigidbody ekleyebilirsin.
             Physics.gravityScale = 0;
             Physics.velocity = new Vector2(0, -velocityOfBackGround);
            Physics = golds[i].AddComponent<Rigidbody2D>();
            Physics.gravityScale = 0;
            Physics.velocity = new Vector2(0, -velocityOfBackGround);
            Physics = bonuses[i].AddComponent<Rigidbody2D>();
            Physics.gravityScale = 0;
            Physics.velocity = new Vector2(0, -velocityOfBackGround);
        }
    }
    void Update()
    {
        if (finished)
        {
            if (permissionOkey == 1)
                permissionOkey = 0;
            //objeler pozisyonlarına atandı.
            if (wall.transform.position.y <= -size)
            {
                wall.transform.position += new Vector3(0, (size * 2) - 19);
            }
            if (wall1.transform.position.y <= -size)
            {
                wall1.transform.position += new Vector3(0, (size * 2) - 19);
            }
            time += Time.deltaTime;
             timeObject = Random.Range(second, L_second);
            //zaman aralığıyla oluşacak tuğlalar.
            if (time > timeObject)
            {
                randomObject = Random.Range(0, 11);
                if (temp >7  && randomObject>7) //ard arda durmadan bonus ve gold çıkması engellendi
                    randomObject = Random.Range(0, 9); 
                temp = randomObject;
                 x = Random.Range(0, 2); //sol ve sağ için rasgele değer üretildi
                 j = Random.Range(0, 12); //2 dizinin 5 farklı objesinden hangisi oluşacak rasgele seçildi.
                if (j == 10)
                    j = 5;
                else if (j == 11)
                    j = 6;
                if (randomObject ==8|| randomObject ==10) //eğer objeler 5 ve 6 ise
                {
                    if (counterGold > 9)
                        counterGold = 0;
                    firstCoin = false;
                        while (counterGold < 4)
                        {
                            y = Random.Range(22, 25);
                            z = Random.Range(-3.5f, 3.46f);
                            if (golds[counterGold].transform.position.y < -10) //stick coinler harita dışında ise
                                golds[counterGold].transform.position = new Vector3(z, y);
                            counterGold++;
                            firstCoin = true;
                        }
                        if (firstCoin == false)
                        {
                            while (counterGold >= 4 && counterGold < 8)
                            {
                                y = Random.Range(22, 25);
                                z = Random.Range(-3.5f, 3.46f);
                                if (golds[counterGold].transform.position.y < -10) //stick coinler harita dışında ise
                                    golds[counterGold].transform.position = new Vector3(z, y);
                                counterGold++;
                                firstCoin = true;
                            }
                        }

                        if (firstCoin == false)
                        {
                            while (counterGold >= 8 && counterGold < 10)
                            {
                                firstCoin = true;
                                y = Random.Range(22, 25);
                                z = Random.Range(-3.5f, 3.46f);
                                if (golds[counterGold].transform.position.y < -10) //stick coinler harita dışında ise
                                    golds[counterGold].transform.position = new Vector3(z, y);
                                counterGold++;
                            }
                            if (counterGold > 9)
                                counterGold = 0;
                        }
                }
                 if (randomObject == 9) //eğer random object 8 ise 
                {
                    if (j == 4) //j 4 ise chest oluştur haritaya taşı.
                    {
                        if (nonRepeat != 4)
                        {
                            if (bonuses[j].transform.position.y <= -11)
                                if (x == 1)
                                {
                                    bonuses[j].transform.rotation = new Quaternion(0, 180, 0, 0);
                                    bonuses[j].transform.position = new Vector2(3.8f, 22);
                                }
                                else
                                {
                                    bonuses[j].transform.rotation = new Quaternion(0, 0, 0, 0);
                                    bonuses[j].transform.position = new Vector2(-3.77f, 22);
                                }
                            nonRepeat = j;
                        }
                        else
                            j = Random.Range(0, 3);
                    }
                    else //0-1-2-3 ise  shield veya magnet oluştur.
                    {
                        if ((j == 0 && velocityOfBackGround != 20) || (j == 1 && movement.isSecurity != false) || (j == 2 && movement.MagnetsUI.isOkey != true))
                        {   //devam eden özellik var ise tekrardan o bonuslardan çıkmicak.
                            if (nonRepeat != j) //ard arda aynı bonus çıkması engellendi.
                            {
                                if (bonuses[j].transform.position.y <= -11)
                                {
                                    permissionOkey = Random.Range(0, 2);
                                    bonuses[j].transform.position = new Vector2(0, 22);
                                nonRepeat = j;
                                }
                            }
                            else
                                j = Random.Range(5, 12);
                        }
                        if (j > 2)
                        {
                            if (j == 10)
                                j = 5;
                            else if (j == 11)
                                j = 6;
                            if (nonRepeat != j) //ard arda bomba veya ortada engel çıkmaması sağlandı.
                            {
                                if (bonuses[j].transform.position.y <= -11)
                                {
                                    bonuses[j].transform.position = new Vector2(0, 22);
                                    nonRepeat = j;
                                    permissionOkey = Random.Range(0,2);
                                }
                            }
                        }
                        else
                        {
                            randomObject = 1;
                           temp = randomObject;
                        }
                    }
                }
                 if(randomObject == 6 ||randomObject ==7)
                {
                    wallx = Random.Range(0.4f, 0.8f);
                    wally = Random.Range(0.3f, 0.4f);
                    if (counterMid > 3)
                        counterMid = 0;
                    if (midBlocks[counterMid].transform.position.y <= -11)
                    {
                        midBlocks[counterMid].transform.localScale = new Vector2(wallx, wally);
                        midBlocks[counterMid].transform.position = new Vector3(0, 22);
                        if (counterGold > 9)
                            counterGold = 0;
                        if (x == 1)
                        {
                            if (golds[counterGold].transform.position.y <= -10)
                                golds[counterGold++].transform.position = new Vector3(-3.5f, 22);
                        }
                        else
                        {
                        if (golds[counterGold].transform.position.y <= -10)
                                golds[counterGold++].transform.position = new Vector3(3.5f, 22);
                        }
                    }
                    else
                        randomObject = 3;
                    counterMid++;
                    if (counterMid > 3)
                        counterMid = 0;
                }
                 if(randomObject ==3 || randomObject == 4)
                {
                    if (scores.t >= 300)
                    {
                        if (counterThorn > 3)
                            counterThorn = 0;
                        if (thorns[counterThorn].transform.position.y <= -11)
                        {
                            if (counterGold > 9)
                                counterGold = 0;
                            if (x == 1)
                            {
                                thorns[counterThorn].transform.position = new Vector3(3.8f, 22);
                                thorns[counterThorn].transform.rotation = new Quaternion(0, 180, 0, 0);
                                if (golds[counterGold].transform.position.y <= -10)
                                    golds[counterGold++].transform.position = new Vector3(-2.5f,22);
                            }
                            else if (x == 0)
                            {
                                thorns[counterThorn].transform.position = new Vector3(-3.8f, 22);
                                if (golds[counterGold].transform.position.y <= -10)
                                    golds[counterGold++].transform.position = new Vector3(2.5f, 22);
                                thorns[counterThorn].transform.rotation = new Quaternion(0, 0, 0, 0);
                            }
                        }
                        else
                            randomObject = 2;
                        counterThorn++;
                        if (counterThorn > 3)
                            counterThorn = 0;
                    }
                    else
                        randomObject = 2;
                }
                if ((randomObject < 3 || (randomObject == 9 && (j != 4 && j !=5)) ||randomObject ==5) && permissionOkey == 0)
                {
                    // bu şekilde x ekseninde engeller yer değieşcek ve her sıfırlanışta farklı yerde olacak.
                     wallx = Random.Range(0.4f, 0.9f);
                     wally = Random.Range(0.3f, 0.4f);
                    if (scores.t >= 400)
                    {
                        if (counterGold > 9)
                            counterGold = 0;
                    }
                    blocks[counter].transform.localScale = new Vector2(wallx, wally);
                    if (x == 1)
                    {
                        if (blocks[counter].transform.position.y <= -11)
                        {
                            blocks[counter].transform.position = new Vector3(3.53f + (wallx / 3), 22);  //sağ bloklar oluşur
                            if (scores.t >= 450)
                                golds[counterGold++].transform.position = new Vector3(-3.5f, 22);
                            counter++;
                        }
                    }
                    else if(x==0)
                    {
                        if (blocks[counter].transform.position.y <= -11)
                        {
                            blocks[counter].transform.position = new Vector3(-3.67f - (wallx / 3), 22); //sol bloklar oluşur
                            if (scores.t >= 400)
                                golds[counterGold++].transform.position = new Vector3(3.5f, 22);
                            counter++;
                        }
                    }
                }
                time = 0;
                if (counter >= blocks.Length) //6 blok oluştuktan sonra
                {
                    counter = 0; //sayaç sıfırlanır. yeni blok oluşmaz başa döner.
                    if (velocityOfBackGround < 12)
                    { //belli bir düzeye kadar daha hızlı artacak.
                        velocityOfBackGround += 0.5f; //hız artar
                        if (second >= 0.3f )
                            second -= 0.02f;
                        if (L_second >= 1.2f)
                            L_second -= 0.05f;
                    }
                    else if (velocityOfBackGround >= 12 &&velocityOfBackGround <20) // hızlanma sınırlandırıldı
                    {
                        velocityOfBackGround += 0.3f;
                        if (second >= 0.2f) //eşyaların geliş zamanıda kısaltıldı.
                            second -= 0.01f;
                        if (L_second >=0.6f)
                            L_second -= 0.01f;
                    }
                    else if (velocityOfBackGround >=20)
                    {
                        velocityOfBackGround += 0.2f;
                        if (second > 0.1f) //eşyaların geliş zamanıda kısaltıldı.
                            second -= 0.005f;
                        if (L_second >0.6f)
                            L_second -= 0.005f;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        Physics = midBlocks[i].GetComponent<Rigidbody2D>();
                        Physics.velocity = new Vector2(0, -velocityOfBackGround);
                        Physics = thorns[i].GetComponent<Rigidbody2D>();
                        Physics.velocity = new Vector2(0, -velocityOfBackGround);
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        Physics = blocks[i].GetComponent<Rigidbody2D>();
                        Physics.velocity = new Vector2(0, -velocityOfBackGround); //yeni hızlar atanır
                        Physics = golds[i].GetComponent<Rigidbody2D>();
                        Physics.velocity = new Vector2(0, -velocityOfBackGround);
                        Physics = bonuses[i].GetComponent<Rigidbody2D>();
                        Physics.velocity = new Vector2(0, -velocityOfBackGround);
                    }
                    physic.velocity = new Vector2(0, -velocityOfBackGround);
                    physic1.velocity = new Vector2(0, -velocityOfBackGround); //aynı şekilde arkaplan hızıda artar     
                    movement.moveSpeed += 30;
                }
            }
        }
    }
    public void gameOver()
    {
        panel.SetActive(true);
        int i = Random.Range(0, 10);
        finishedText.text = finishText[i];
        scores.notfinished = false;
        finished = false;
        finishGold.text = movement.coinText.text;
        finishScore.text = scores.scoreText.text;
        for( i =0;i < 4; i++)
        {
            midBlocks[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            thorns[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        for ( i = 0; i < 10; i++)
        {
            blocks[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            golds[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            bonuses[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            physic.velocity = Vector2.zero;
            physic1.velocity = Vector2.zero; //oyun bitince herşey duruyor.
        }
    }
}