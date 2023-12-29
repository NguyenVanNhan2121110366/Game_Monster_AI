using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatedAssetInput : MonoBehaviour
{

    [SerializeField] public bool isAiming;
    // Start is called before the first frame update
    void Start()
    {
        //this.isAiming = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAim(InputValue value)
    {
        this.isAiming = value.isPressed;
    }

}
