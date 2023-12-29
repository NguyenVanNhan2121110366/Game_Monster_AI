using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int hp = 20;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(transform.GetComponent<Rigidbody>());
        }
        if (other.CompareTag("Dragon"))
        {
            other.GetComponent<HealDragon>().takeDame(this.hp);
            Destroy(transform.GetComponent<Rigidbody>());
        }
    }
}
