using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbage : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifetime;

    void Start()
    {
        lifetime = 6;
        StartCoroutine(DestroyObject());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Destroy(gameObject);
        }
    }


    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
