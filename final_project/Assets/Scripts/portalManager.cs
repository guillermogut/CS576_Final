using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalManager : MonoBehaviour
{

    public int level;

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
                SceneManager.LoadScene("Floor2");
            }
            else if (level == 2)
            {
                SceneManager.LoadScene("Floor3");
            }
            else if (level == 3)
            {
                SceneManager.LoadScene("Floor4");
            }
            else if (level == 4)
            {
                SceneManager.LoadScene("Floor5");
            }
            else if (level == 5)
            {
                SceneManager.LoadScene("Floor6");
            }
            else if (level == 6)
            {
                SceneManager.LoadScene("Floor7");
            }
            else if (level == 7)
            {
                SceneManager.LoadScene("Boss");
            }
            else if (level == 8)
            {
                SceneManager.LoadScene("EndMenu");
            }
        }
    }

}
