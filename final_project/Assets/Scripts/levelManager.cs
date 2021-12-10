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
    public GameObject enemyPrefab;
    public GameObject hpItemPrefab;
    public GameObject mpItemPrefab;
    public GameObject atItemPrefab;

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

        StartCoroutine(SpawnItems());
        StartCoroutine(SpawnEnemies());

    }

    IEnumerator SpawnEnemies()
    {

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

                    float zdiff = Mathf.Abs(character.transform.position.z - randTile.position.z);
                    float xdiff = Mathf.Abs(character.transform.position.x - randTile.position.x);

                    if ((zdiff > 10f && zdiff < 30f) && (xdiff > 10f && xdiff < 30f))
                    {
                        valid = true;
                    }
                }

                Vector3 enemyPosition = new Vector3(randTile.position.x, randTile.position.y, randTile.position.z);
                Quaternion enemyRotation = new Quaternion(0f, 0f, 0f, 0f);

                GameObject enemy = Instantiate(enemyPrefab, enemyPosition, enemyRotation) as GameObject;
                enemy.AddComponent<DogKnight>();
                enemies.Add(enemy); // object reference not set to an instance of an object error

                // misc
                enemiesSpawned += 1;
                if (enemiesSpawned >= totalEnemies) break;

                // update spawn rate and spawn speed depending on enemiesDefeated and level

            }
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    IEnumerator SpawnItems() {
        yield return new WaitForSeconds(0);

        for (int i = 0; i < maxItems; i++) {
            /*
            // determine where to spawn, and spawn
            bool valid = false;
            Transform randTile = floorTiles[0];
            while (valid == false)
            {
                int rand = Random.Range(0, floorTiles.Length - 1);
                randTile = floorTiles[rand];

                float zdiff = Mathf.Abs(character.transform.position.z - randTile.position.z);
                float xdiff = Mathf.Abs(character.transform.position.x - randTile.position.x);

                if ((zdiff > 3f && zdiff < 5f) && (xdiff > 3f && xdiff < 5f))
                {
                    valid = true;
                }
            }
            */
            int rand = Random.Range(0, floorTiles.Length - 1);
            Transform randTile = floorTiles[rand];

            int rand2 = Random.Range(0, 2);
            string itemType;
            GameObject itemPrefab;
            switch (rand2) {
                case 0:
                    itemType = "hp";
                    itemPrefab = hpItemPrefab;
                    break;
                case 1:
                    itemType = "mp";
                    itemPrefab = mpItemPrefab;
                    break;
                case 2:
                default:
                    itemType = "at";
                    itemPrefab = atItemPrefab;
                    break;
            }
            Vector3 itemPosition = new Vector3(randTile.position.x, randTile.position.y + 3.0f, randTile.position.z);
            Quaternion itemRotation = new Quaternion(0f, 0f, 0f, 0f);

            //Debug.Log($"position: {itemPosition} rotation: {itemRotation}");
            GameObject item = Instantiate(itemPrefab, itemPosition, itemRotation) as GameObject;
            //item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //item.transform.position = itemPosition;
            itemEffects itemEffects = item.AddComponent<itemEffects>();
            Rigidbody rb = item.AddComponent<Rigidbody>();
            BoxCollider collider = item.AddComponent<BoxCollider>();
            collider.center = itemPosition;
            collider.size = new Vector3(3.0f, 3.0f, 3.0f);
            //Debug.Log("center:" + collider.center);
            //Debug.Log("size:" + collider.size);

            GameObject srContainer = new GameObject("cool gameobject");
            srContainer.AddComponent<SpriteRenderer>();
            srContainer.transform.parent = item.transform;

            itemEffects.type = itemType;
            items.Add(item);
        }
    }
}
