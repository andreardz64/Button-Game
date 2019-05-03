using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawn;
    public GameObject[] food;
    public GameObject[] garbage;
    private int randomSpawn;
    private int randomFood;
    private int randomGarbage;


    void Start()
    {
        randomSpawn = Random.Range(0, 5);
        randomFood = Random.Range(0, 4);
        randomGarbage = Random.Range(0, 4);
        StartCoroutine(CreateFood());
        StartCoroutine(CreateGarbage());
    }


    public IEnumerator CreateGarbage()
    {
        Instantiate(garbage[randomGarbage], spawn[randomSpawn].GetComponent<Transform>().position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        randomSpawn = Random.Range(0, 5);
        randomGarbage = Random.Range(0, 4);
        StartCoroutine(CreateGarbage());
    }

    public IEnumerator CreateFood()
    {
        Instantiate(food[randomFood], spawn[randomSpawn].GetComponent<Transform>().position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        randomSpawn = Random.Range(0, 5);
        randomFood = Random.Range(0, 4);
        StartCoroutine(CreateFood());
    }

}
