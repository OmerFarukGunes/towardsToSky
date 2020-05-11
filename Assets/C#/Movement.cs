using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    public AudioSource explosion;
    public AudioSource soundDCoin;
    public AudioSource jump1;
    public AudioSource jump2;
    public AudioSource soundCoin;
    public AudioSource bonus;
    public AudioSource decrease;
    public AudioSource fall;
    public int moveSpeed = 675;
    public GameObject character;
    private Rigidbody2D characterBody;
    GameController gameController;
    int coin=0;
    public Text coinText;
    bool gameOver = false;
   public bool isSecurity = true;
    public magnetsUI MagnetsUI;
   public  bool isSpeed = true;
    public GameObject boostEffect;
    public GameObject magnetEffect;
    public GameObject shieldEffect;
    public GameObject crashEffect;
    public GameObject chestEffect;
    public GameObject bombEffect;
    public GameObject x2Effect;
    public GameObject decreaseEffect;
    score scores;
    public int multipleCoin=1;
    void Start()
    {
        characterBody = character.GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        MagnetsUI = GameObject.FindGameObjectWithTag("collect").GetComponent<magnetsUI>();
        scores = GameObject.FindGameObjectWithTag("GameController").GetComponent<score>();
    }
    void Update()
    {
        if(gameOver == false) { 
        if (Input.GetMouseButtonDown(0))
        { //move right
            if (character.transform.position.x >=3.525f) {
                    jump1.Play();
                characterBody.AddForce(new Vector2(-moveSpeed, 0));
                    characterBody.GetComponent<Transform>().rotation = new Quaternion(-20,180,0,0); //sola doğru zıpladı ve yeni resim geldi karakter sola döndü
            }
            else if (character.transform.position.x <= -3.525f)
            {
                    jump2.Play();
                characterBody.AddForce(new Vector2(moveSpeed, 0));
                    characterBody.GetComponent<Transform>().rotation = new Quaternion(0,0,0,0);
                }
        }
        if (characterBody.transform.position.x < -3.529f)
        {
            characterBody.velocity = new Vector2(0, 0);
            characterBody.transform.position = new Vector2(-3.53f, -6.3f); //son konumda yani duvarda karakter durduruldu
        }
        else if (characterBody.transform.position.x > 3.529f)
        {
            characterBody.velocity = new Vector2(0, 0);
            characterBody.transform.position = new Vector2(3.53f, -6.3f);//son konumda yani duvarda karakter durduruldu
            } 
        }
        else
        {
            character.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
            StartCoroutine(bonusesCoroutine(coll)); //collidera birşey çarpınca zamana bağlı değişken yapılabilen fonksiyon çağırıldı.
    }
    IEnumerator bonusesCoroutine(Collider2D coll)
    {
        if (coll.gameObject.tag == "coin")
        {
            coin += 1*multipleCoin;
            soundCoin.Play();
            if (PlayerPrefs.GetInt("x2Score") == 1)
                scores.scores += 1 * multipleCoin;
            else
                scores.scores += 1;
            coinText.text = coin.ToString();
            coll.GetComponent<SpriteRenderer>().enabled = false;
            coll.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(1);
            coll.GetComponent<SpriteRenderer>().enabled = true; // görünmez olan yani toplanan altınlar 2 saniye sonra tekrar görünür olur.
            coll.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if(coll.gameObject.tag == "coinn")
        {
            coin +=2*multipleCoin;
            soundDCoin.Play();
            if (PlayerPrefs.GetInt("x2Score") == 1)
                scores.scores += 2 * multipleCoin;
            else
                scores.scores += 2;
            coinText.text = coin.ToString();
            coll.GetComponent<SpriteRenderer>().enabled = false;
            coll.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(2);
            coll.GetComponent<SpriteRenderer>().enabled = true; // görünmez olan yani toplanan altınlar 2 saniye sonra tekrar görünür olur.
            coll.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if(coll.gameObject.tag == "coinM")
        {
            x2Effect.SetActive(true);
            bonus.Play();
            multipleCoin = 2;
            if (PlayerPrefs.GetInt("x2Score") == 1)
                scores.scores += 3 * multipleCoin;
            else
                scores.scores += 3;
            coinText.text = coin.ToString();
            coll.GetComponent<SpriteRenderer>().enabled = false;
            coll.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(8+ PlayerPrefs.GetInt("timeOfX2"));
            coll.GetComponent<SpriteRenderer>().enabled = true; // görünmez olan yani toplanan altınlar 2 saniye sonra tekrar görünür olur.
            coll.GetComponent<CircleCollider2D>().enabled = true;
            multipleCoin = 1;
            x2Effect.SetActive(false);
        }
        else if(coll.gameObject.tag == "b_coin")
        {
            coin -= 20;
            decrease.Play();
            decreaseEffect.SetActive(true);
            coinText.text = coin.ToString();
            coll.GetComponent<SpriteRenderer>().enabled = false;
            coll.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(2);
            coll.GetComponent<SpriteRenderer>().enabled = true; // görünmez olan yani toplanan altınlar 2 saniye sonra tekrar görünür olur.
            decreaseEffect.SetActive(false);
            coll.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (coll.gameObject.tag == "b_score")
        {
            scores.scores -=20;
            decrease.Play();
            decreaseEffect.SetActive(true);
            coll.GetComponent<SpriteRenderer>().enabled = false;
            coll.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(2);
            coll.GetComponent<SpriteRenderer>().enabled = true; // görünmez olan yani toplanan altınlar 2 saniye sonra tekrar görünür olur.
            decreaseEffect.SetActive(false);
            coll.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if(coll.gameObject.tag == "bomb" && PlayerPrefs.GetInt("savingB") == 0)
        {
            bombEffect.GetComponent<Transform>().position = coll.gameObject.transform.position;
            bombEffect.SetActive(true);
            explosion.Play();
            coll.gameObject.SetActive(false);
            gameOver = true;
            gameController.gameOver();
            character.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (coll.gameObject.tag == "block" && isSecurity &&PlayerPrefs.GetInt("saveS") == 0)
        {
            fall.Play();
            crashEffect.GetComponent<Transform>().position = character.gameObject.transform.position;
            crashEffect.SetActive(true);
            int TotalCoin = PlayerPrefs.GetInt("collectCoin") + coin;
            PlayerPrefs.SetInt("collectCoin",TotalCoin);
            gameOver = true;
            gameController.gameOver(); //eğer bloğa çarparsa gameover fonku çağırıldı.
            character.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
            character.GetComponent<SpriteRenderer>().enabled = true;  //karakter 1 kereliğine ekrana geldi ve gitti ve geldi
        }
        else if(coll.gameObject.tag == "magnet")
        {
            bonus.Play();
            magnetEffect.SetActive(true);
            coll.GetComponent<SpriteRenderer>().enabled = false;
            if (PlayerPrefs.GetInt("x2Score") == 1)
                scores.scores += 2 * multipleCoin;
            else
                scores.scores += 2;
            coll.GetComponent<Collider2D>().enabled = false;
            MagnetsUI.isOkey = true; //magnet scripti aktif edildi.
            yield return new WaitForSeconds(8+PlayerPrefs.GetInt("timeOfMagnet"));
            coll.GetComponent<SpriteRenderer>().enabled = true;
            MagnetsUI.isOkey = false;
            coll.GetComponent<Collider2D>().enabled = true;
            magnetEffect.SetActive(false);
        }
        else if(coll.gameObject.tag== "point")
        {
            if (PlayerPrefs.GetInt("x2Score") == 1)
                scores.scores += 1 * multipleCoin;
            else
                scores.scores += 1;
            coll.GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(2);
            coll.GetComponent<Collider2D>().enabled = true;
        }
        else if(coll.gameObject.tag == "shield")
        {
            bonus.Play();
            shieldEffect.SetActive(true);
            if (PlayerPrefs.GetInt("x2Score") == 1)
                scores.scores += 2 * multipleCoin;
            else
                scores.scores += 2;
            coll.GetComponent<SpriteRenderer>().enabled = false;
            coll.GetComponent<Collider2D>().enabled = false;
            isSecurity = false; //güvenlik açıldı.
            if (PlayerPrefs.GetInt("saveBomb") == 1)
                PlayerPrefs.SetInt("savingB", 1);
            yield return new WaitForSeconds(8+PlayerPrefs.GetInt("timeOfShield"));
                PlayerPrefs.SetInt("savingB", 0);
            coll.GetComponent<SpriteRenderer>().enabled = true;
            isSecurity = true;
            coll.GetComponent<Collider2D>().enabled = true;
            shieldEffect.SetActive(false);
        }
        else if(coll.gameObject.tag == "chest")
        {
            bonus.Play();
            chestEffect.SetActive(true);
            if (PlayerPrefs.GetInt("x2Score") == 1)
                scores.scores += 3*multipleCoin;
            else
                scores.scores += 3;
            coll.GetComponent<SpriteRenderer>().enabled = false; //chesti al
            coll.GetComponent<Collider2D>().enabled = false;
            coin += (40+ PlayerPrefs.GetInt("timeOfChest"))*multipleCoin; //coine 50 ekle ekrana yaz.
            coinText.text = coin.ToString();
            yield return new WaitForSeconds(2);
            coll.GetComponent<SpriteRenderer>().enabled = true;
            coll.GetComponent<Collider2D>().enabled = true;
            chestEffect.SetActive(false);
        }
        else if(coll.gameObject.tag == "speed" &&isSpeed)
        {
            bonus.Play();
            boostEffect.SetActive(true);
            if (PlayerPrefs.GetInt("x2Score") == 1)
                scores.scores += 10 * multipleCoin;
            else
                scores.scores += 10;
            coll.GetComponent<SpriteRenderer>().enabled = false;
            coll.GetComponent<Collider2D>().enabled = false;
            float temp = gameController.velocityOfBackGround;
            gameController.velocityOfBackGround +=10;
            isSpeed = false;
            if (PlayerPrefs.GetInt("savingSpeed") == 1)
                PlayerPrefs.SetInt("saveS", 1);
            for (int i = 0; i < 4; i++)
            {
                gameController.Physics = gameController.midBlocks[i].GetComponent<Rigidbody2D>();
                gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround);
                gameController.Physics = gameController.thorns[i].GetComponent<Rigidbody2D>();
                gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround);
            }
            for (int i = 0; i < 10; i++)
            {
                gameController.Physics = gameController.blocks[i].GetComponent<Rigidbody2D>();
                gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround); //yeni hızlar atanır
                gameController.Physics = gameController.golds[i].GetComponent<Rigidbody2D>();
                gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround);
                gameController.Physics = gameController.bonuses[i].GetComponent<Rigidbody2D>();
                gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround);
            }
            gameController.physic.velocity = new Vector2(0, -gameController.velocityOfBackGround);
            gameController.physic1.velocity = new Vector2(0, -gameController.velocityOfBackGround); //aynı şekilde arkaplan hızıda artar     
            moveSpeed += 500;
            yield return new WaitForSeconds(2 + PlayerPrefs.GetInt("timeOfSpeed"));
            PlayerPrefs.SetInt("saveS", 0);
            coll.GetComponent<SpriteRenderer>().enabled = true;
            coll.GetComponent<Collider2D>().enabled = true;
            isSpeed = true;
            if (gameController.finished){
            gameController.velocityOfBackGround =temp;
                for (int i = 0; i < 4; i++)
              {
                    gameController.Physics = gameController.midBlocks[i].GetComponent<Rigidbody2D>();
                    gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround);
                    gameController.Physics = gameController.thorns[i].GetComponent<Rigidbody2D>();
                    gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround);
            }
                for (int i = 0; i < 10; i++)
            {
                gameController.Physics = gameController.blocks[i].GetComponent<Rigidbody2D>();
                gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround); //yeni hızlar atanır
                gameController.Physics = gameController.golds[i].GetComponent<Rigidbody2D>();
                gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround);
                gameController.Physics = gameController.bonuses[i].GetComponent<Rigidbody2D>();
                gameController.Physics.velocity = new Vector2(0, -gameController.velocityOfBackGround);
            }
            gameController.physic.velocity = new Vector2(0, -gameController.velocityOfBackGround);
            gameController.physic1.velocity = new Vector2(0, -gameController.velocityOfBackGround);
            moveSpeed -= 500;
            }
            boostEffect.SetActive(false);
        }
    }
}