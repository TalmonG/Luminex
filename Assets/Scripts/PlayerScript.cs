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
    Animator animator;

    bool AddCharge = true;

    GameObject HUD;

    int Money;

    public int level;

    bool isNewGame=true;

    //Restriction Variables
    public bool canSwitchDimensions = true;
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

    bool CantBreathe;
    public float Health;
    float MaxHealth=100;
    public float Oxygen;
    float MaxOxygen=100;
    float oxygenTimer=0;
    public bool death;
    public bool damaged;
    int DimensionCharge;

    float DimensionDeviceChargeRate;

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

        animator = GetComponent<Animator>();

        HUD = GameObject.FindGameObjectWithTag("HUDCanvas");

        death = false;

        isNormalDimension = true;

        SetPlayerStats();

        DontDestroyOnLoad(GameObject.Find("Canvas"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!death)
        {
            GlobalReferenceScript.instance.Health.value = Health;
            GlobalReferenceScript.instance.Oxygen.value = Oxygen;
            GlobalReferenceScript.instance.DimensionChargeAmount.sprite = GlobalReferenceScript.instance.DimensionBubbles[DimensionCharge];



            DetectCrushed();



            if (CantBreathe)
            {

                Oxygen -= (Time.deltaTime * 10);

                Oxygen = Mathf.Clamp(Oxygen, 0, 100);


            }
            else
            {
                Oxygen += (Time.deltaTime * 12);

                Oxygen = Mathf.Clamp(Oxygen, 0, 100);
            }

            if (Oxygen <= 0)
            {
                Health -= Time.deltaTime * 15;
            }

            // Dimension Switch
            if (Input.GetKeyDown(KeyCode.F) && isNormalDimension == true /*&& canSwitchDimensions == true*/)
            {
                if (DimensionCharge > 0)
                {
                    isNormalDimension = false;
                  //  DimensionDeviceChargeRate = 0;
                    DimensionCharge--;
                    CantBreathe = true;
                    LevelChecker();
                }
            }
            else if (Input.GetKeyDown(KeyCode.F) && isNormalDimension == false/* && canSwitchDimensions == true*/)
            {
                isNormalDimension = true;

                AddCharge=true;
                CantBreathe = false;
                LevelChecker();
            }

            if (isNormalDimension)
            {
                //AddCharge = false;

                DimensionDeviceChargeRate += Time.deltaTime/4;

                DimensionCharge = (int)Mathf.Round(DimensionDeviceChargeRate);

                Mathf.Clamp(DimensionDeviceChargeRate, 0, 6);

               // StartCoroutine(ChargingDimensionDevice());
            }
            else
            {
                DimensionDeviceChargeRate = DimensionCharge;
            }

            DimensionCharge=Mathf.Clamp(DimensionCharge,0,6);


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
            // Debug.Log(PlayerPrefs.GetInt("PlayerHealth"));

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

            animator.SetInteger("Direction", FacingDirection * animator.GetInteger("Velocity"));

            isgrounded = FloorCollider.transform.GetComponent<FloorCollisionScript>().OnFloor;

            if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
            {
                rb.velocity = Vector2.up * speed * 3 * i; animator.SetTrigger("OnJump");
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

            if (rb.velocity.x > 0) { animator.SetInteger("Velocity", 1); }
            else if (rb.velocity.x < 0) { animator.SetInteger("Velocity", -1); }
            else { animator.SetInteger("Velocity", 0); }



            if (damaged)
            {
                damaged = false;
                StartCoroutine(Damage());
            }

            if (Health <= 0)
            {
                death = true;
                Death();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                Health = 0;
            }

            SavePlayerStats();
        }
        else { cam.transform.position = transform.position+Vector3.forward*-10; cam.orthographicSize = 3; }

        if (Grotate)
        {
            if (degrees < 180 / 2)
            {
                transform.Rotate(Vector3.forward * 2);
                degrees += 1;

            }
            else { Grotate = false; degrees = 0; }
        }

    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;

        
    }


    void DetectCrushed()
    {
        
        RaycastHit2D lefthit = Physics2D.Raycast(transform.position, Vector2.left, 1,LayerMask.GetMask("FloorTilemapLayer"));
        RaycastHit2D righthit = Physics2D.Raycast(transform.position, Vector2.right, 1, LayerMask.GetMask("FloorTilemapLayer"));
        RaycastHit2D downhit = Physics2D.Raycast(transform.position, Vector2.down, 1, LayerMask.GetMask("FloorTilemapLayer"));
        RaycastHit2D uphit = Physics2D.Raycast(transform.position, Vector2.up, 1, LayerMask.GetMask("FloorTilemapLayer"));

       if(downhit.collider !=null && lefthit.collider != null)
        {
            CantBreathe = true;
        }
     
        Debug.DrawRay(transform.position, Vector2.left);

    }



    void SavePlayerStats() 
    {
        //SAVE HEALTH
        PlayerPrefs.SetFloat("PlayerHealth",Health);
        PlayerPrefs.SetFloat("PlayerMaxHealth", MaxHealth);

        //SAVE OXYGEN
        PlayerPrefs.SetFloat("Oxygen",Oxygen);
        PlayerPrefs.SetFloat("MaxOxygen", MaxOxygen);

        //SAVE DIMENSION
        PlayerPrefs.SetInt("Dimension", (isNormalDimension ? 1 : 0));
        PlayerPrefs.SetInt("DimensionCharge", DimensionCharge);

        //SAVE MONEY
        PlayerPrefs.SetInt("Money", Money);

        PlayerPrefs.Save();


    }

    void SetPlayerStats()
    {

        //CHECKS IF IS A NEW GAME
        if (!isNewGame)
        {
            //SET HEALTH
            Health = PlayerPrefs.GetInt("PlayerHealth");
            MaxHealth = PlayerPrefs.GetInt("PlayerMaxHealth");

            //SET OXYGEN
            Oxygen = PlayerPrefs.GetInt("Oxygen");
            MaxOxygen = PlayerPrefs.GetInt("MaxOxygen");

            //SET Dimension
            isNormalDimension = (PlayerPrefs.GetInt("Dimension") != 0);
            DimensionCharge = PlayerPrefs.GetInt("DimensionCharge");

            //SET MONEY
            Money = PlayerPrefs.GetInt("Money");

        }
        else
        {
            //SET HEALTH TO DEFAULT VALUE
            Health = 100;
            MaxHealth = 100;

            //SET OXYGEN TO DEFALT VALUE
            Oxygen = 100;
            MaxOxygen = 100;

            //SET DIMENSION TO DEFAULT VALUE
            isNormalDimension = true;
            DimensionCharge = 6;

            //SET MONEY
            Money = 0;
        }
    }


    void Death()
    {

        animator.SetBool("Dead", true);
        animator.SetTrigger("Died");


        Destroy(transform.GetChild(0).gameObject);
        Destroy(transform.GetChild(1).gameObject);
        Destroy(transform.GetChild(5).gameObject);

        Destroy(HUD);

       // GetComponent<Collider2D>().enabled = false;
       // GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;



    }


    IEnumerator Damage()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);

        GetComponent<SpriteRenderer>().color = Color.white;

        yield return null;
    }

    IEnumerator ChargingDimensionDevice()
    {
        yield return new WaitForSeconds(5);
        AddCharge=true;
        DimensionCharge++;
        DimensionCharge= Mathf.Clamp(DimensionCharge, 0, 6);
    }

}
