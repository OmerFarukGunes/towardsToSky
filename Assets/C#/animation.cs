using UnityEngine;
public class animation : MonoBehaviour
{
    public Sprite[] move;
    public Sprite oEye;
    public Sprite cEye;
    SpriteRenderer sprite;
    public Sprite[] fall;
    int walkCounter;
    int jumpCounter;
    public GameObject character;
    public Sprite[] jump;
    GameController gameController;
    float walkTimer;
    float jumpTimer;
    int fallCounter;
    float fallTimer;
    int x;
    void Start()
    {
 
        sprite = gameObject.GetComponent<SpriteRenderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void  FixedUpdate()
    {
        walk();
    }
    void walk()
    {
        if (gameController.finished)
        {
            if (character.transform.position.x >3.525f || character.transform.position.x < -3.525f)
            {
                walkTimer += Time.deltaTime;
                if (walkTimer > 0.08f)
                {
                    if (walkCounter != 2)
                    {
                        sprite.sprite = move[walkCounter++];
                    }
                    else if (walkCounter == 2)
                    {
                        x = Random.Range(0,10);
                        if (x == 0)
                            sprite.sprite = cEye;
                        else
                            sprite.sprite = oEye;
                        walkCounter++;
                    }
                    if (walkCounter == move.Length)
                    {
                        walkCounter = 0;
                    }
                    walkTimer = 0;
                }
            }
            else
            {
                jumpTimer += Time.deltaTime;  
                if(character.transform.position.x >= 3.52 && character.transform.position.x<3.525f || character.transform.position.x <= -3.52f && character.transform.position.x >-3.525f)
                {
                    sprite.sprite = jump[0];
                }
                else if (jumpTimer > 0.03f)
                {
                    sprite.sprite = jump[jumpCounter++];
                    if (jumpCounter == jump.Length)
                    {
                        jumpCounter = 0;
                    }
                    jumpTimer = 0;
                }
            }
        }
        else
        {
            character.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -500));
            character.GetComponent<Collider2D>().enabled = false;
            if (fallCounter < 4)
            {
                fallTimer += Time.deltaTime;
                if (fallTimer>0.01f)
                {
                    sprite.sprite = fall[fallCounter++];
                    fallTimer = 0;
                }
            }
        }
    }
}
