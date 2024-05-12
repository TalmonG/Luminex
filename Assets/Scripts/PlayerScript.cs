using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

    // Referencing
    public DimensionManager dimensionManager;




    int Money;

    public int currentLevel;

    bool isNewGame=true;

    //Restriction Variables
    public bool canSwitchDimensions = true;
    public bool isNormalDimension = true;

    public bool canGRotate = false;

    public void LevelChecker()
    {
        // Level Restrictions
        // StartMenu
        // Retrieve the integer value from PlayerPrefs
        Debug.Log("A" + currentLevel);

        int currentLevelValue = PlayerPrefs.GetInt("currentLevel");
        currentLevel = PlayerPrefs.GetInt("currentLevel");

        Debug.Log("D" + currentLevel);
        //PlayerPrefs.SetInt("currentLevel" ,currentLevel);
        if (currentLevel == -6)
        {
            canSwitchDimensions = true;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // Credits
        else if (currentLevel == -5)
        {
            canSwitchDimensions = false;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // Options_Audio
        else if (currentLevel == -4)
        {
            canSwitchDimensions = false;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // Options_Controls
        else if (currentLevel == -3)
        {
            canSwitchDimensions = false;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // Options_Graphics
        else if (currentLevel == -2)
        {
            canSwitchDimensions = false;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // HUB Level
        else if (currentLevel == -1)
        {
            canSwitchDimensions = true;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // Tutorial
        else if (currentLevel == 0 && canSwitchDimensions == true)
        {
            //canSwitchDimensions = true;
            if (isNormalDimension == true) // if we want normal dimension
            {
                dimensionManager.EnableNormalDimensionTutorial();// Enable Normal
                dimensionManager.DisableInvertedDimensionTutorial();// Disable Inverted
                //isNormalDimension = true;
                Debug.Log("You enabled normal");
            }
            if (isNormalDimension == false)
            {
                dimensionManager.DisableNormalDimensionTutorial();// Enable Normal
                dimensionManager.EnableInvertedDimensionTutorial();// Disable Inverted
                //isNormalDimension = false;
                Debug.Log("You enabled inverted");
            }
            

        }
        // Level 1
        else if (currentLevel == 1)
        {
            canSwitchDimensions = true;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // Level 2
        else if (currentLevel == 2)
        {
            canSwitchDimensions = true;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // Level 3
        else if (currentLevel == 3)
        {
            canSwitchDimensions = true;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // Level 4
        else if (currentLevel == 4)
        {
            canSwitchDimensions = true;
            Debug.Log("canSwitchDimension is set to " + canSwitchDimensions + " for this level");
        }
        // Errors
        else
        {
            Debug.Log("Level Detectoin Error. Level: " + currentLevel + " is being detected.");
            Debug.Log("Likely need to add an incremental system in SceneManagerscript to increment 'currentLevel' variable in player script. Hope that helps");
        }
    }

    bool CantBreathe;
    public int Health;
    int MaxHealth=100;
    public float Oxygen;
    float MaxOxygen=100;
    float oxygenTimer=0;
    int BreathRate;

    

    // Start is called before the first frame update
    void Start()
    {
        dimensionManager = GameObject.FindWithTag("DimensionManager").GetComponent<DimensionManager>();

        //DontDestroyOnLoad(this.gameObject); //-- its adding multiple players to scenes and giving errors
        Debug.Log("Check this error, its causeing player spawning issues, canvas and more");
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        BulletSpawnPos = transform.GetChild(0).GetChild(1).gameObject;
        Arm = transform.GetChild(0).gameObject;
        FloorCollider = transform.GetChild(2).gameObject;
        Head = transform.GetChild(1).gameObject;
        MousePosObj = GameObject.Find("CursorPosition");

        dimensionManager.EnableNormalDimensionTutorial();// Enable Normal
        dimensionManager.DisableInvertedDimensionTutorial();// Disable Inverted
        isNormalDimension = true;



        SetPlayerStats();

        //DontDestroyOnLoad(GameObject.Find("Canvas"));
    }

    // Update is called once per frame
    void Update()
    {
        GlobalReferenceScript.instance.Health.value = Health;
        GlobalReferenceScript.instance.Oxygen.value = Oxygen;


        DetectCrushed();
        //Debug.Log(canSwitchDimensions);
        if (CantBreathe)
        {
            
            oxygenTimer += Time.deltaTime;

            // Oxygen = MaxOxygen - (int)oxygenTimer * 2;

            Oxygen -= Time.deltaTime*3*BreathRate;
        }

        


        // Dimension Switches to Normal
        if (Input.GetKeyDown(KeyCode.LeftShift) && canSwitchDimensions == true && isNormalDimension == false)
        {
            isNormalDimension = true;

            BreathRate = 1;
            Debug.Log("Switched to Normal Dimension");
            CantBreathe = false;
            LevelChecker();
            Debug.Log("VAMOSSSS");

        }
        // Dimension Switches to Inverted
        else if (Input.GetKeyDown(KeyCode.LeftShift) && canSwitchDimensions == true && isNormalDimension == true)
        {
            isNormalDimension = false;

            BreathRate = -1;
            Debug.Log("Switched To Inverted Dimension");
            CantBreathe = true;
            LevelChecker();
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
            if (degrees < 180)
            {
                transform.Rotate(Vector3.forward);
                degrees+=1;
                
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


        SavePlayerStats();


    }
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;

        // Retrieve the integer value from PlayerPrefs
        int isNormalDimensionValue = PlayerPrefs.GetInt("isNormalDimension");

        // Convert the integer value to a boolean
        if (isNormalDimensionValue == 1)
        {
            isNormalDimension = true;
        }
        else
        {
            isNormalDimension = false;
        }

        // Retrieve the integer value from PlayerPrefs
        int canSwitchDimensionsValue = PlayerPrefs.GetInt("canSwitchDimensions");

        Debug.Log("canSwitchDimensionsValue retrieved from PlayerPrefs: " + canSwitchDimensionsValue);

        // Convert the integer value to a boolean
        if (canSwitchDimensionsValue == 1)
        {
            canSwitchDimensions = true;
            Debug.Log("canSwitchDimensions set to true");
        }
        else
        {
            canSwitchDimensions = false;
            Debug.Log("canSwitchDimensions set to false");
        }



    }



    void DetectCrushed()
    {
        
        RaycastHit2D lefthit = Physics2D.Raycast(transform.position, Vector2.left, 1,LayerMask.GetMask("FloorTilemapLayer"));
        RaycastHit2D righthit = Physics2D.Raycast(transform.position, Vector2.left, 1, LayerMask.GetMask("FloorTilemapLayer"));
        RaycastHit2D downhit = Physics2D.Raycast(transform.position, Vector2.left, 1, LayerMask.GetMask("FloorTilemapLayer"));
        RaycastHit2D uphit = Physics2D.Raycast(transform.position, Vector2.left, 1, LayerMask.GetMask("FloorTilemapLayer"));

       if(downhit.collider !=null && lefthit.collider != null)
        {
        }
     
        Debug.DrawRay(transform.position, Vector2.left);

    }



    void SavePlayerStats() 
    {
        //SAVE HEALTH
        PlayerPrefs.SetInt("PlayerHealth",Health);
        PlayerPrefs.SetInt("PlayerMaxHealth", MaxHealth);

        //SAVE OXYGEN
        PlayerPrefs.SetFloat("Oxygen",Oxygen);
        PlayerPrefs.SetFloat("MaxOxygen", MaxOxygen);

        // currentLevel
        PlayerPrefs.SetInt("currentLevel", currentLevel);

        //SAVE DIMENSION
        PlayerPrefs.SetInt("isNormalDimension", (isNormalDimension ? 1 : 0));

        //SAVE canSwitchDimensions
        PlayerPrefs.SetInt("canSwitchDimensions", (canSwitchDimensions ? 1 : 0));

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
            isNormalDimension = (PlayerPrefs.GetInt("isNormalDimension") != 0);

            //SET canSwitchDimensions
            canSwitchDimensions = (PlayerPrefs.GetInt("canSwitchDimensions") != 0);



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
            //isNormalDimension = true;

            //canSwitchDimensions = false;

            //SET MONEY
            Money = 0;
        }
    }

   
}
