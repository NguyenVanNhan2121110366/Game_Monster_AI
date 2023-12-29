using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animation;
    [SerializeField] private Rigidbody player;
    [SerializeField] private float pressVertical = 0f;
    [SerializeField] private float pressHorizontal = 0f;
    [SerializeField] private float speedMove;
    [SerializeField] private float thrust = 10f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool isAim = true;
    [SerializeField] private bool isShooting;
    [SerializeField] public GameObject arrowObject;
    [SerializeField] public Transform posArrow;

    private StatedAssetInput _input;
    // Start is called before the first frame update

    void Awake()
    {
        this.player = GetComponent<Rigidbody>();
        this.animation = GetComponent<Animator>();
        this._input = GetComponent<StatedAssetInput>();
        this.isShooting = true;
    }

    void Start()
    {
        this.GravityPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckInput();
        this.MovePlayer();
        this.SetAnimation();
        this.AimShoot();
        this.IsAttack();
    }

    private void CheckInput()
    {
        this.pressVertical = Input.GetAxis("Vertical");
        this.pressHorizontal = Input.GetAxis("Horizontal");
    }

    private void MovePlayer()
    {
        this.player.transform.Translate(Vector3.forward * this.speedMove * Time.deltaTime * this.pressVertical);
        this.player.transform.Rotate(Vector3.up, this.speedMove * this.pressHorizontal);

        if (Input.GetKeyDown(KeyCode.Space) && this.isGrounded == true)
        {
            this.player.AddRelativeForce(Vector3.up * this.thrust, ForceMode.Impulse);
            this.isGrounded = false;
            this.animation.SetBool("Jump", true);
        }
    }

    private void GravityPlayer()
    {
        Physics.gravity *= 5f;
    }

    private void SetAnimation()
    {
        if (this.pressVertical > 0)
        {
            this.animation.SetBool("Move", true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.animation.SetBool("Move", false);
            }
        }

        if (this.pressVertical == 0)
        {
            this.animation.SetBool("Move", false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            this.animation.SetBool("Jump", false);
        }
    }

    private void AimShoot()
    {
        if (Input.GetMouseButtonDown(0) && isAim)
        {
            this.animation.SetBool("IsAim", true);
            this.animation.SetBool("Shooting", true);
            this.isAim = false;
        }

        // if (Input.GetMouseButtonDown(0) && this.pressVertical > 0)
        // {
        //     //this.animation.SetBool("MoveAim", true);
        //     this.animation.SetFloat("Blend",1.0f);
        // }

        if (Input.GetMouseButtonUp(0) && this.pressVertical > 0)
        {
            this.animation.SetBool("MoveAim", false);
        }

        if (Input.GetMouseButtonUp(0) && this.isAim == false)
        {
            this.animation.SetBool("IsAim", false);
            this.isAim = true;
            this.animation.SetBool("Shooting", false);
        }

        // if (Input.GetMouseButtonDown(0) && this.pressVertical == 0)
        // {
        // 	this.animation.SetBool("IdleAim",true);
        // }

        if (Input.GetMouseButtonDown(0) && this.pressVertical == 0)
        {
            this.animation.SetBool("AimMoving", true);
        }

        // if (Input.GetMouseButtonUp(0) && this.pressVertical == 0)
        // {
        //     this.animation.SetFloat("Blend",0.2f);
        // }

        if (Input.GetMouseButtonUp(0) && this.pressVertical == 0)
        {
            
        }

        // if (Input.GetMouseButtonUp(0)&&this.pressVertical==0)
        // {
        //     this.animation.SetBool("Shooting",true);
        // }
    }

    public virtual void shotting()
    {
        Debug.Log("Shoot");
        GameObject isShooting = Instantiate(this.arrowObject, posArrow.position, transform.rotation);
        isShooting.GetComponent<Rigidbody>().AddForce(transform.forward * 50f, ForceMode.Impulse);
    }

    private void IsAttack()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            animation.SetTrigger("isAttack");
        }
    } 
}


