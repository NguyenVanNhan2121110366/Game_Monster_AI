using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
	public Transform player;
	[SerializeField]private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        this.player=GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=this.player.position+this.pos;
    }
}
