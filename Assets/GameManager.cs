using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawndistance;
    public float gameTimer;
    public Text gameText;
    public GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            SpawnEnemy();

        }
       
    }
    void SpawnEnemy()
    {
        float randomAngle = Random.Range(0, Mathf.PI * 2.0f);

      GameObject enemyObject=Instantiate(enemyPrefab);
        enemyObject.transform.SetParent(this.transform);
        enemyObject.transform.position = new Vector3(Mathf.Cos(randomAngle)*spawndistance,2,Mathf.Sin(randomAngle)*spawndistance);

        EnemyController enemyController = enemyObject.GetComponent<EnemyController>();
        enemyController.onEnemyDestroyed = () =>
        {
            OnEnemyDestroyed();
        };
        enemyController.onWrongEnemy = () =>
        {
            OnWrongEnemy();
        };
    }
    public void OnWrongEnemy()
    {
        Debug.Log("Wrong Enemy");
        Time.timeScale = 0;
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
    

    }
    public void OnEnemyDestroyed()
    {
        Time.timeScale = 0;
        Debug.Log("Enemy Destroyed");
    }
    private void Update()
    {
        gameText.text = "Time" + gameTimer;
        gameTimer -= Time.deltaTime;
        if (gameTimer <= 0)
        {
            gameTimer = 0;
            gameText.text = "GameOver";
            
        }
    }


}
