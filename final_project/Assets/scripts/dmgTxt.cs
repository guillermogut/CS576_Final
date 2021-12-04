using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dmgTxt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject container;
    public int dmgToShow;
    float alphaStart;
    void Start()
    {
        //Debug.Log("parent-"+transform.parent.name);
        //gameObject.GetComponent<TextMeshProUGUI>().transform.position = gameObject.transform.parent.position;
        gameObject.GetComponent<TextMeshProUGUI>().text = dmgToShow.ToString();
        transform.localPosition = new Vector3(0, 0, 0);
        alphaStart = gameObject.GetComponent<TextMeshProUGUI>().alpha;
        StartCoroutine("disappear");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + transform.position.y * .001f, transform.position.z);
        gameObject.GetComponent<TextMeshProUGUI>().alpha -= .01f;
    }

    IEnumerator disappear()
    {
        yield return new WaitForSeconds(1f);
        Destroy(container);
    }
    void damageTxt(int dmg)
    {
        dmgToShow = dmg;
    }
}
