using System.Threading;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public float timer = 10f;
    private int x, y;
    private Transform spawnPosition;
    public GameObject enemyPrefab_Mike;
    public GameObject enemyPrefab_Casta;
    public GameObject enemyPrefab_Espi;
    public GameObject enemyPrefab_Santi;
    public GameObject enemyPrefab_Doc;// nosotros enemigos para que sepa que spawnear
    public Transform spawnPoint1;  
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    public Transform spawnPoint6;// los spawnpoints para los carriles 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            x = Random.Range(1, 6);
            y = Random.Range(1, 5);// numeros random para elegir que enemigo y en que carril
            switch (y)
            {
                case 1:
                    spawnPosition.position = spawnPoint1.position;
                    break;
                case 2:
                    spawnPosition.position = spawnPoint2.position;
                    break;
                case 3:
                    spawnPosition.position = spawnPoint3.position;
                    break;
                case 4:
                    spawnPosition.position = spawnPoint4.position;
                    break;
                case 5:
                    spawnPosition.position = spawnPoint5.position;
                    break;
                case 6:
                    spawnPosition.position = spawnPoint6.position;
                    break;
            }
            switch (x)
            {
                case 1:
                    Instantiate(enemyPrefab_Mike, spawnPosition);
                    break;
                case 2:
                    Instantiate(enemyPrefab_Casta, spawnPosition);
                    break;
                case 3:
                    Instantiate(enemyPrefab_Espi, spawnPosition);
                    break;
                case 4:
                    Instantiate(enemyPrefab_Santi, spawnPosition);
                    break;
                case 5:
                    Instantiate(enemyPrefab_Doc, spawnPosition);
                    break;
            }
            timer = 10f;// reseteo del timer
        }
    }
    
}
