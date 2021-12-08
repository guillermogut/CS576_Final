using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class txt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject container;
    float alphaStart;
    void Start()
    {
        //Debug.Log("parent-" + transform.parent.name);
        transform.localPosition = new Vector3(0, 0, 0);
        alphaStart = gameObject.GetComponent<TextMeshProUGUI>().alpha;
        StartCoroutine("disappear");
    }
    
    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y+ transform.position.y*.001f, transform.position.z);
        gameObject.GetComponent<TextMeshProUGUI>().alpha -= .005f;
    }

    IEnumerator disappear()
    {
        yield return new WaitForSeconds(2f);
        Destroy(container);
    }
}
