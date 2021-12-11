using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalManager : MonoBehaviour
{

    public int level;
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name.Contains("grillHitbox"))
        {

            if (level == 1)
            {
                playerProgression progress = character.GetComponent<playerProgression>();
                progress._gameStart = false;
                player player = character.GetComponent<player>();
                player.savePlayerInfo();
                SceneManager.LoadScene("Floor2");
            }
            else if (level == 2)
            {
                player player = character.GetComponent<player>();
                player.savePlayerInfo();
                SceneManager.LoadScene("Floor3");
            }
            else if (level == 3)
            {
                player player = character.GetComponent<player>();
                player.savePlayerInfo();
                SceneManager.LoadScene("Floor4");
            }
            else if (level == 4)
            {
                player player = character.GetComponent<player>();
                player.savePlayerInfo();
                SceneManager.LoadScene("Floor5");
            }
            else if (level == 5)
            {
                player player = character.GetComponent<player>();
                player.savePlayerInfo();
                SceneManager.LoadScene("Floor6");
            }
            else if (level == 6)
            {
                player player = character.GetComponent<player>();
                player.savePlayerInfo();
                SceneManager.LoadScene("Floor7");
            }
            else if (level == 7)
            {
                player player = character.GetComponent<player>();
                player.savePlayerInfo();
                SceneManager.LoadScene("Boss");
            }
            else if (level == 8)
            {
                player player = character.GetComponent<player>();
                player.savePlayerInfo();
                SceneManager.LoadScene("EndMenu");
            }
        }
    }

}