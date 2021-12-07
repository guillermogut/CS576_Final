using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{

    public GameObject character;
    public int totalEnemies;
    public int maxItems;
    public int level;
    public float spawnSpeed;
    public int spawnSize;
    public GameObject floorFolder;

    private int enemiesSpawned;
    private int enemiesDefeated;
    private List<GameObject> items;
    private List<GameObject> enemies;
    private Transform[] floorTiles;
    private bool levelComplete;
    private bool levelFailed;

    // Start is called before the first frame update
    void Start()
    {
        Initiate();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemiesDefeated == totalEnemies)
        {
            levelComplete = true;
        }

    }

    void Initiate()
    {
        enemies = new List<GameObject>();
        items = new List<GameObject>();
        enemiesSpawned = 0;
        enemiesDefeated = 0;
        levelComplete = false;
        levelFailed = false;
        floorTiles = floorFolder.GetComponentsInChildren<Transform>();
        spawnSpeed = 1f;
        spawnSize = 1;

        StartCoroutine(SpawnEnemies());

    }

    IEnumerator SpawnEnemies()
    {

        GameObject enemyPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube); // have as public variable eventually
        enemyPrefab.transform.localScale = new Vector3(2f, 2f, 2f);
        enemyPrefab.transform.position = new Vector3(100f, 100f, 100f);

        yield return new WaitForSeconds(spawnSpeed);
        while (enemiesSpawned < totalEnemies)
        {
            for (int i = 0; i < spawnSize; i++)
            {

                // determine where to spawn, and spawn
                bool valid = false;
                Transform randTile = floorTiles[0];
                while (valid == false)
                {
                    int rand = Random.Range(0, floorTiles.Length - 1);
                    randTile = floorTiles[rand];

                    if (Mathf.Abs(character.transform.position.z - randTile.position.z) > 10f && Mathf.Abs(character.transform.position.x - randTile.position.x) > 10f)
                    {
                        valid = true;
                    }
                }

                Vector3 enemyPosition = new Vector3(randTile.position.x, randTile.position.y + 10f, randTile.position.z);
                Quaternion enemyRotation = new Quaternion(0f, 0f, 0f, 0f);

                GameObject enemy = Instantiate(enemyPrefab, enemyPosition, enemyRotation) as GameObject;
                enemies.Add(enemy); // object reference not set to an instance of an object error

                // misc
                enemiesSpawned += 1;
                if (enemiesSpawned >= totalEnemies) break;

                // update spawn rate and spawn speed depending on enemiesDefeated and level

            }
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
