using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public TextMeshProUGUI scoreText;
    public int score  {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 2.0f, 2.0f) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        int pick = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[pick], new Vector3(4.0f,0.5f, Random.Range(-3.0f, 3.0f)), prefabs[pick].transform.rotation);
    }

    public void UpdateScore(int i)
    {
        score += i;
        scoreText.text = "Score: " + score;
    }

}
