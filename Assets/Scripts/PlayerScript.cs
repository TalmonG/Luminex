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
    float degrees = 0;
    public int ActiveWeapon=0;
    Weapon CurrentWeaponScript;
    GameObject MousePosObj;

    public int level;

    //Restriction Variables
    public bool canSwitchDimensions = false;
    public bool isNormalDimension = true;

    public bool canGRotate = false;

    void LevelChecker()
    {
        // Level Restrictions
        if (level == -1)
        {
            canSwitchDimensions = false;
        }
        else if (level == 0)
        {
            canSwitchDimensions = false;
        }
        else if (level == 1)
        {
            canSwitchDimensions = true;
        }
        else if (level == 2)
        {
            canSwitchDimensions = true;
        }
        else if (level == 3)
        {
            canSwitchDimensions = true;
        }
        else if (level == 4)
        {
            canSwitchDimensions = true;
        }
        else if (level == 5)
        {
            canSwitchDimensions = true;
        }
        else
        {
            Debug.Log("Level Detectoin Error. Level: " + level + " is being detected.");
            Debug.Log("Likely need to add an incremental system in SceneManagerscript to increment 'level' variable in player script. Hope that helps");
        }
    }

    bool Dimension;
    public int Health;
    int MaxHealth=100;
    public int Oxygen;
    int MaxOxygen=100;
    float oxygenTimer=0;

    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        BulletSpawnPos = transform.GetChild(0).GetChild(1).gameObject;
        Arm = transform.GetChild(0).gameObject;
        FloorCollider = transform.GetChild(2).gameObject;
        Head = transform.GetChild(1).gameObject;
        MousePosObj = GameObject.Find("CursorPosition");

        isNormalDimension = true;

        DontDestroyOnLoad(GameObject.Find("Canvas"));
    }

    // Update is called once per frame
    void Update()
    {
        GlobalReferenceScript.instance.Health.value = Health;
        GlobalReferenceScript.instance.Oxygen.value = Oxygen;

        DetectCrushed();

        if (Dimension)
        {

            oxygenTimer += Time.deltaTime;

            Oxygen = MaxOxygen - (int)oxygenTimer * 2;
        }
        // Dimension Switch
        if (Input.GetKeyDown(KeyCode.LeftShift) && isNormalDimension == true && canSwitchDimensions == true)
        {
            isNormalDimension = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && isNormalDimension == false && canSwitchDimensions == true)
        {
            isNormalDimension = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && canSwitchDimensions == false)
        {
            oxygenTimer = 0;
            Dimension = true;
            LevelChecker();
            //Debug.Log("Checking");
        }

        if ((Input.GetAxis("Mouse ScrollWheel")) > 0)
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
                GlobalReferenceScript.instance.CurrentWeaponSymbol[i].enabled = false;

            }
            else
            {
                transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(true);
                GlobalReferenceScript.instance.CurrentWeaponSymbol[i].enabled = true;

            }
        }

        ArmSprite = Arm.transform.GetChild(ActiveWeapon).gameObject;
        CurrentWeaponScript = ArmSprite.GetComponent<Weapon>();

        if (Input.GetKeyDown(KeyCode.C) && isgrounded && (degrees % 180 == 0))
        {
            rb.gravityScale *= -1;
            degrees = 0;
            Grotate = true;

            i *= -1;

        }

        if (Grotate)
        {
            if (degrees < 180*Time.deltaTime*10)
            {
                transform.Rotate(Vector3.forward*Time.deltaTime*10);
                degrees+=1*Time.deltaTime*Time.deltaTime*100;
                
            }
            else { Grotate = false; degrees = 0; }
        }
       // Debug.Log(degrees);
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
            Arm.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up * FacingDirection);
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

        if (transform.position.x - MousePos.x < 0)
        {

            transform.localScale = (new Vector3(1 * i, 1, 1));
            Arm.transform.localScale = (new Vector3(1 * i, 1 * i, 1));
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

        GetComponent<Animator>().SetInteger("Direction", FacingDirection * GetComponent<Animator>().GetInteger("Velocity"));

        isgrounded = FloorCollider.transform.GetComponent<FloorCollisionScript>().OnFloor;

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.velocity = Vector2.up * speed * 3 * i; GetComponent<Animator>().SetTrigger("OnJump");
        }

        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical");

        Vector3 HorizontalDirection = new Vector3(Horizontal * i, rb.velocity.y, 0);

        rb.velocity = HorizontalDirection;

        MousePosObj.transform.position = MousePos;

        Vector3 TargetCamPos = (MousePosObj.transform.position - transform.position);
        TargetCamPos.x *= FacingDirection;
        TargetCamPos.y /= 2 * i;
        TargetCamPos.x /= 3;
        cam.transform.localPosition = TargetCamPos + (Vector3.forward * -10);

        if (rb.velocity.x > 0) { GetComponent<Animator>().SetInteger("Velocity", 1); }
        else if (rb.velocity.x < 0) { GetComponent<Animator>().SetInteger("Velocity", -1); }
        else { GetComponent<Animator>().SetInteger("Velocity", 0); }

        


    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }


    void DetectCrushed()
    {
        
        RaycastHit2D lefthit = Physics2D.Raycast(transform.position, Vector2.left, 1,LayerMask.GetMask("FloorTilemapLayer"));
        RaycastHit2D righthit = Physics2D.Raycast(transform.position, Vector2.left, 1, LayerMask.GetMask("FloorTilemapLayer"));
        RaycastHit2D downhit = Physics2D.Raycast(transform.position, Vector2.left, 1, LayerMask.GetMask("FloorTilemapLayer"));
        RaycastHit2D uphit = Physics2D.Raycast(transform.position, Vector2.left, 1, LayerMask.GetMask("FloorTilemapLayer"));

       if(downhit.collider !=null && lefthit.collider != null)
        {
            Debug.Log("sadas");
        }
     
        Debug.DrawRay(transform.position, Vector2.left);

    }


}
