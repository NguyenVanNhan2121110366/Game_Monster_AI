using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(desArrow());
        destroyArrow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator desArrow()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void destroyArrow()
    {
        Destroy(gameObject,3);
    }
}
