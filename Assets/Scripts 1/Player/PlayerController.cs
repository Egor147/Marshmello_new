using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float JumpPower, PushXSpeed, PushZSpeed, RotationAngle, BoostInSlipper, RunJumpPowerRatio;
    public float Speed;
    [SerializeField] private GameObject DeadMenu;
    private float timer = 0, SSpeed;
    [SerializeField] private Vector3 ScaleWhenSlide;
    public static bool GameOver, Jumping, Pushing;
    private bool Running, NormalScale, Slipper;
    private Vector3 StartScale, Rotate;
    Transform tr;
    Rigidbody rb;
    public static float k = 0f;
    void Start()
    {
        GameOver = false;
        Slipper = false;
        Pushing = false;
        Jumping = false;
        Running = false;
        NormalScale = true;
        tr = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
        StartScale = tr.localScale;
        if(PlayerPrefs.HasKey("XCoord")){
            tr.position = new Vector3(PlayerPrefs.GetFloat("XCoord"),PlayerPrefs.GetFloat("YCoord"),PlayerPrefs.GetFloat("ZCoord"));
        }
        Time.timeScale = 1f;
    }

    void FixedUpdate()
    {
        if (!GameOver){
                if (Input.GetButton("Run")){
                    Move(Speed*2);
                    Running = true;
                }
                else{
                    Running = false;
                    Move(Speed);
                }
                if (NormalScale)
                    if (Input.GetButtonDown("Slide"))
                        Slide();
        } else {
            Dead();
        }
    }

    void Update(){
        if (!GameOver)
            if (!Jumping && !Pushing)
                if (Input.GetButtonDown("Jump")){
                    if (Running)
                        Jump(JumpPower+k+RunJumpPowerRatio);
                    else Jump(JumpPower);
                }
    }

    public void Move(float Speed){
        float inputZ = Input.GetAxis("Horizontal");
        float inputX = 1f;
        if (!Slipper){
            inputX = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(inputX*Speed,rb.velocity.y,inputZ*-Speed);
        }else{
            timer += Time.deltaTime;
            rb.velocity = new Vector3(SSpeed*inputX + BoostInSlipper*timer,rb.velocity.y,inputZ*Speed);
        }
    
        if (inputX<0)
            Rotation((RotationAngle*-inputZ + 180));
        else
            Rotation(RotationAngle*inputZ);
    }

    void Slide(){
        StartCoroutine(Waiting(2));
        tr.localScale = new Vector3(tr.localScale.x*ScaleWhenSlide.x,tr.localScale.y*ScaleWhenSlide.y,tr.localScale.z*ScaleWhenSlide.z);
        NormalScale = false;
    }

    IEnumerator Waiting(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NormalScale = true;
        tr.localScale = StartScale;
    }

    void Jump( float HeightJump){
        Jumping = true;
        rb.velocity = new Vector3(rb.velocity.x, HeightJump, rb.velocity.z);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Ground")){
            Jumping = false;
            k=0;
        }

        else if (other.gameObject.CompareTag("Slippery")){
            Slipper = true;
            SSpeed = rb.velocity.x;
        }
    }
    
    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Slippery")){
            Slipper = false;
            timer = 0;
        }
    }
    void Rotation (float Rotation){
        tr.rotation = Quaternion.AngleAxis(Rotation, Vector3.up);
    }
    void Dead(){
        DeadMenu.SetActive(true);
        DeadMenu.GetComponent<Transform>().Find("Dead").gameObject.SetActive(true);
    }
}

