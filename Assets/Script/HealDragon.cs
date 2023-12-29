using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDragon : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private AudioClip checkPoint;
    [SerializeField] private AudioSource audio;
    public int heal = 100;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void takeDame(int hp)
    {
        this.heal -= hp;
        if (heal <= 0)
        {
            this.animator.SetTrigger("die");


        }
        else
        {
            this.animator.SetTrigger("damanager");
            this.audio.PlayOneShot(checkPoint, 1.0f);
        }
    }
}
