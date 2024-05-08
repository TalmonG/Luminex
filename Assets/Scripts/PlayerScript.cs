using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    Camera cam;
    bool isgrounded;
    public GameObject Bullet;
    public Quaternion LookRotation;
    GameObject BulletSpawnPos;
    GameObject Arm;
    GameObject FloorCollider;
    GameObject Head;
    GameObject ArmSprite;
    bool CanFire=true;
    bool Rotating = true;
    Quaternion StartRotation;
    Quaternion EndRotation;
    int i = 1;
    int FacingDirection;
    bool Grotate = false;
    int degrees = 0;
    public int ActiveWeapon=0;
    Weapon CurrentWeaponScript;
    GameObject MousePosObj;
    public bool isNormalDimension = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        BulletSpawnPos = transform.GetChild(0).GetChild(1).gameObject;
        Arm = transform.GetChild(0).gameObject;
        FloorCollider = transform.GetChild(2).gameObject;
        Head = transform.GetChild(1).gameObject;
        MousePosObj = GameObject.Find("CursorPosition");

        isNormalDimension = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Dimension Switch
        if (Input.GetKeyDown(KeyCode.LeftShift) && isNormalDimension == true)
        {
            isNormalDimension = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && isNormalDimension == false)
        {
            isNormalDimension = true;
        }

        if ((Input.GetAxis("Mouse ScrollWheel"))>0)
        {
            ActiveWeapon++;
            ActiveWeapon = Mathf.Clamp(ActiveWeapon, 0, 3);

        }
        if ((Input.GetAxis("Mouse ScrollWheel")) < 0)
        {
            ActiveWeapon--;
            ActiveWeapon = Mathf.Clamp(ActiveWeapon, 0, 3);
        }
       //S Debug.Log(transform.GetChild(0).transform.GetChild(ActiveWeapon).gameObject);

        for (int i = 0; i < transform.GetChild(0).transform.childCount; i++)
        {
            if (i != ActiveWeapon)
            {
                transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(false);
            }
            else { transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(true); }
        }

        ArmSprite = Arm.transform.GetChild(ActiveWeapon).gameObject;
        CurrentWeaponScript = ArmSprite.GetComponent<Weapon>();

        if (Input.GetKeyDown(KeyCode.C)&&isgrounded&&(degrees%180==0))
        {
            rb.gravityScale *= -1;
            degrees = 0;
            Grotate = true;

            i *= -1;

        }

        if (Grotate)
        {
            if (degrees < 180)
            {
                transform.Rotate(Vector3.forward);
                degrees++;
            }
            else {  Grotate = false;degrees = 0; }
        }

        cam.transform.rotation = transform.rotation;


        Vector3 MousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        MousePos.z = 0;

        Vector2 targetpos = MousePos - Arm.transform.position;

        LookRotation = Quaternion.LookRotation(Vector3.forward, targetpos);
        LookRotation.eulerAngles += Vector3.forward * 90;


        if (CurrentWeaponScript.isReloading == false)
        {
            LookRotation = Quaternion.LookRotation(Vector3.forward, targetpos);
            LookRotation.eulerAngles += Vector3.forward * 90;
            Arm.transform.rotation = LookRotation;

        }
        else if (CurrentWeaponScript.isReloading == true)
        {
            Arm.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up*FacingDirection);
        }

        //Head Rotation Bounds

        /*
        if (FacingDirection == 1)
        {
            if ((LookRotation.eulerAngles.z >= 0 && LookRotation.eulerAngles.z < 50) || (LookRotation.eulerAngles.z < 360 && LookRotation.eulerAngles.z > 335))
            {
                Head.transform.rotation = LookRotation;
            }
        }
        else if (FacingDirection == -1)
        {
            if ((LookRotation.eulerAngles.z <= 180 && LookRotation.eulerAngles.z > 130) || (LookRotation.eulerAngles.z > 180 && LookRotation.eulerAngles.z < 205))
            {
                Head.transform.rotation = LookRotation;
            }
        }
        */

        Head.transform.rotation = LookRotation;

        if (Input.GetMouseButton(0))
        {
            
            CurrentWeaponScript.Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CurrentWeaponScript.Reload();
        }

        if (transform.position.x-MousePos.x < 0)
        { 

            transform.localScale=(new Vector3(1*i, 1, 1));
            Arm.transform.localScale = (new Vector3(1*i, 1 * i, 1));
            Head.transform.localScale = (new Vector3(1 * i, 1 * i, 1));
            FacingDirection = 1;
        }
        if (transform.position.x - MousePos.x > 0)
        { 
            transform.localScale = (new Vector3(-1 * i, 1, 1));
            Arm.transform.localScale = (new Vector3(-1 * i, -1 * i, 1));
            Head.transform.localScale = (new Vector3(-1 * i, -1 * i, 1));
            FacingDirection = -1;
        }

        GetComponent<Animator>().SetInteger("Direction", FacingDirection* GetComponent<Animator>().GetInteger("Velocity"));

        isgrounded = FloorCollider.transform.GetComponent<FloorCollisionScript>().OnFloor;

        if (Input.GetKeyDown(KeyCode.Space)&&isgrounded) 
        {
            rb.velocity = Vector2.up *speed*3*i; GetComponent<Animator>().SetTrigger("OnJump");
        }

        float Horizontal = Input.GetAxis("Horizontal")*speed;
        float Vertical = Input.GetAxis("Vertical");
    
        Vector3 HorizontalDirection = new Vector3(Horizontal * i, rb.velocity.y, 0);

        rb.velocity=HorizontalDirection;

        MousePosObj.transform.position = MousePos;

        Vector3 TargetCamPos = (MousePosObj.transform.position-transform.position);
        TargetCamPos.x *= FacingDirection;
        TargetCamPos.y /= 2;
        TargetCamPos.x /= 3;
        cam.transform.localPosition = TargetCamPos+(Vector3.forward*-10);

        if (rb.velocity.x > 0) { GetComponent<Animator>().SetInteger("Velocity", 1); }
        else if (rb.velocity.x<0){ GetComponent<Animator>().SetInteger("Velocity", -1); }
        else { GetComponent<Animator>().SetInteger("Velocity", 0); }

    }

    private void FixedUpdate()
    {
   



        // rb.AddForce(new Vector2(Horizontal,Vertical));

       // if (Horizontal != 0) { rb.AddForce(new Vector2(Horizontal, 0)*0.1f,ForceMode2D.Impulse); }

       // Vector2 TargetPos = rb.position + new Vector2(Horizontal, 0).normalized *Time.fixedDeltaTime*10;
       // TargetPos += Physics2D.gravity * Time.fixedDeltaTime;
       // rb.MovePosition(TargetPos);
        // rb.velocity += Physics2D.gravity * Time.fixedDeltaTime*20;
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
