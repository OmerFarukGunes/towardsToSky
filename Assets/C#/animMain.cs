using UnityEngine;
using Random = UnityEngine.Random;
public class animMain : MonoBehaviour
{
    public Sprite[] stay;
    SpriteRenderer sprite;
    int counter;
    float timer;
    public void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        stays();
    }
    void stays()
    {
        timer += Time.deltaTime;
        if (timer > 0.25f)
        {
            counter = Random.Range(0, 4);
            sprite.sprite = stay[counter];
            this.transform.localScale = new Vector2(0.5f, 0.5f);
            timer = 0;
        }
    }
}