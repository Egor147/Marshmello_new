using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Jump_height, RotationAngle, SlipperSpeed;
    public float Speed;
    [SerializeField] private GameObject DeadMenu;
    private float SSpeed;
    [SerializeField] private Vector3 ScaleWhenSlide;
    public static bool GameOver, Jumping, Slipper;
    private bool NormalScale;
    private Vector3 StartScale, Rotate;
    Transform tr;
    Rigidbody rb;
    public static float k = 0f;
    [SerializeField] private Animator Anim;
    private int _state;

    [SerializeField]  AudioSource Fon;
    public bool On_boat = false;

    public static float JumpPower;
    void Start()
    {
        Cursor.visible = false;
        JumpPower = Jump_height;
        GameOver = false;
        Slipper = false;
        Jumping = false;
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
        if (!GameOver ){
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") || Slipper){
                if (!Jumping)
                    if (!Slipper)
                        if (_state !=2)
                            _state = 1;
                    if (Slipper)
                        if (_state !=2)
                            _state = 3;
                Move(Speed);
            } else if (!Jumping && _state !=2) 
                    _state = 0;
            if (Input.GetButtonDown("Slide") && NormalScale)
                Slide();
            //Anim.SetInteger("state",_state);
        }else if (GameOver) {StartCoroutine(Waiting_for_dead());}
    }

    void Update(){
        if (!GameOver && !On_boat){
            if (!Jumping)
                if (Input.GetButtonDown("Jump")){
                    _state = 2;
                    Jump(JumpPower);
                }

            Anim.SetInteger("state",_state);
            //StartCoroutine(Change_animation(0.5f, 4));
        }
    }

    public void Move(float Speed){
        float inputZ = Input.GetAxis("Horizontal");
        float inputX = 1f;
        if (!Slipper){
            inputX = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(inputX*Speed,rb.velocity.y,inputZ*-Speed);
        }else{
            rb.velocity = new Vector3(SlipperSpeed,rb.velocity.y,inputZ*-Speed);
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

    IEnumerator Waiting_for_dead()
    {
        yield return new WaitForSeconds(0.5f);
        Dead();
    }

    IEnumerator Waiting(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NormalScale = true;
        tr.localScale = StartScale;
    }
    IEnumerator Change_animation(float waitTime, int x)
    {
        yield return new WaitForSeconds(waitTime);
        _state = x;
    }

    void Jump( float HeightJump){
        Jumping = true;
        rb.velocity = new Vector3(rb.velocity.x, HeightJump, rb.velocity.z);
    }

    void OnTriggerEnter(Collider other){
        //if(other.gameObject.CompareTag("Ground")){
        if (Jumping && !other.gameObject.CompareTag("Jelly")){
            _state = 0;
            Jumping = false;
            k=0;
        }

        if (other.gameObject.CompareTag("Boat")){
            //transform.SetParent(other.gameObject.transform);
            On_boat = true;
        }

        if (other.gameObject.CompareTag("Plane")){
            Fon.Stop();
        }
           // _state = 5;
        //}
    }

    void Rotation (float Rotation){
        tr.rotation = Quaternion.AngleAxis(Rotation, Vector3.up);
    }
    void Dead(){
        Cursor.visible = true;
        DeadMenu.SetActive(true);
        DeadMenu.GetComponent<Transform>().Find("Dead").gameObject.SetActive(true);
    }
}

