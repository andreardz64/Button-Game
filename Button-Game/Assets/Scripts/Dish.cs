using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dish : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Canvas GameOver;
    public float life;
    private Color characterColor;
    public Text Score;
    public int points;

    void Start()
    {
        points = 0;
        speed = 7f;
        GameOver.enabled = false;
        life = 5;
        characterColor = gameObject.GetComponent<SpriteRenderer>().color;
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        Score.text = "Score: " + points;

        if (Input.GetKeyDown("space"))
        {
            speed = speed * -1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("garbage"))
        {
            TakeDamage();
        }
        if (collision.gameObject.tag == ("food"))
        {
            AddPoints();
        }

    }

    public void TakeDamage()
    {
        StartCoroutine(RestoreColor());
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        life = life - 1;
        if (life <= 0) Die();
    }

    public void AddPoints()
    {
        points += 100;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
        GameOver.enabled = true;
        Time.timeScale = 0;
    }

    public IEnumerator RestoreColor()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().color = characterColor;
    }



}
