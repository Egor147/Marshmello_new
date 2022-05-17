using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float XSpeed, ZSpeed, JumpPower, PushXSpeed, PushZSpeed, RotationAngle, BoostInSlipper, RunJumpPowerRatio;
    private float timer = 0, SSpeed;
    [SerializeField] private Vector3 ScaleWhenSlide;
    public static bool GameOver, Jumping, Pushing;
    private bool Running, OnJelly, NormalScale, Slipper;
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
        OnJelly = false;
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
            if (!Pushing){
                if (Input.GetButton("Run")){
                    Move(XSpeed*2, ZSpeed*2);
                    Running = true;
                }
                else{
                    Running = false;
                    Move(XSpeed,ZSpeed);
                }
                if (NormalScale)
                    if (Input.GetButtonDown("Slide"))
                        Slide();
            }else{
                Move(PushXSpeed, PushZSpeed);
            }
        }
    }

    void Update(){
        if (!GameOver)
            if (!Jumping && !Pushing)
                if (Input.GetButtonDown("Jump")){
                    if (Running)
                        Jump(JumpPower+k+RunJumpPowerRatio);
                    else Jump(JumpPower+k);
                }
    }

    public void Move(float HorizontalSpeed, float VerticalSpeed){
        float inputZ = Input.GetAxis("Horizontal");
        float inputX = 1f;
        if (!Slipper){
            inputX = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(inputX*HorizontalSpeed,rb.velocity.y,inputZ*VerticalSpeed);
        }else{
            timer += Time.deltaTime;
            rb.velocity = new Vector3(SSpeed*inputX + BoostInSlipper*timer,rb.velocity.y,inputZ*VerticalSpeed);
        }
        
        Rotate = tr.rotation.eulerAngles +  Vector3.one * RotationAngle*inputZ;
        if (inputX<0)
            Rotation((RotationAngle*-inputZ + 180));
        else
            Rotation(RotationAngle*inputZ);
    }

    void Slide(){
        StartCoroutine(Waiting(2));
        tr.localScale = ScaleWhenSlide;
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
        else if(other.gameObject.CompareTag("Jelly")){
            Jumping = false;
            k = other.gameObject.GetComponent<Jelly>().Ratio;
        }
        else if (other.gameObject.CompareTag("Slippery")){
            Slipper = true;
            SSpeed = rb.velocity.x;
        }
    }
    /*void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Slippery")){
            Slipper = true;
        }
    }*/
    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Slippery")){
            Slipper = false;
            timer = 0;
            //rb.AddForce(new Vector3(-12,0,0),ForceMode.Impulse);
        }
    }
    void Rotation (float Rotation){
        tr.rotation = Quaternion.AngleAxis(Rotation, Vector3.up);;
    }
}
