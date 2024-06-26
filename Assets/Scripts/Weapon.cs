using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Animator animator;
    public GameObject Bullet;
    GameObject BulletSpawnPos;
    Quaternion Angle;
    Vector3 MousePos;
    Vector3 TargetPos;
    Camera camera;
    public bool CanFire = true;
    public bool isReloading=false;
    GameObject canvas, CurrentWeaponTxtObj, AmmoTxtObj;
    GameObject Player;
    TextMeshProUGUI CurrentWeaponText, AmmoText;
    public int ReserveAmmo, MagAmmo, CurrentWeapon;
    int[] BurstAmmount= new int[4] {1,3,6,1};
    string[] WeaponNames= new string[4] {"Pistol","Battle Rifle","Shotgun","Grenade-Launcher"};
    public int[,] Ammo = { {10,10 },{12,24 },{36,360 },{5,10 } };
    int[,] MaxAmmoValue = { { 10, 100 }, { 12, 120 },{36,360 }, { 5, 20 } };
    float[,] RateOfFire = { {0.3f,0 },{0.5f,0.1f },{1.3f,0 }, { 1.3f, 0 } };
    float[] AccuracyValue = {1 , 0.1f , 15 , 1};
    int[] AmmoPerBullet = {1,3,6 , 1};
    PlayerScript playerScript;
    bool isNewGame;
    

    public void Fire()
    {

        if (CanFire && !isReloading && Ammo[CurrentWeapon,0]>0)
        {
            CanFire = false;

            
            StartCoroutine(Shoot());

                
        }
    }

    void EnableFire()
    {
        CanFire=true;
    }

    void ResetTrigger(string Trigger)
    {
        if (Trigger == "Fire")
        {
            animator.ResetTrigger("Fire");
            //Debug.Log("dsfdsf");
           // CanFire = true;
        }
    }

    void ReloadFinished()
    {
        isReloading=false;

        int ReloadAmount = MaxAmmoValue[CurrentWeapon, 0] - Ammo[CurrentWeapon, 0];

        Ammo[CurrentWeapon, 0] += Ammo[CurrentWeapon, 1];
        Ammo[CurrentWeapon, 1] -= ReloadAmount;

        Ammo[CurrentWeapon, 0] = Mathf.Clamp(Ammo[CurrentWeapon, 0], 0, MaxAmmoValue[CurrentWeapon, 0]);
        Ammo[CurrentWeapon, 1] = Mathf.Clamp(Ammo[CurrentWeapon, 1], 0, Ammo[CurrentWeapon, 1]);
    }
    
    public void Reload()
    {
        if (Ammo[CurrentWeapon, 1] > 0 && MaxAmmoValue[CurrentWeapon, 0]- Ammo[CurrentWeapon, 0]!=0)
        {
            if (isReloading == false)
            {
                animator.SetTrigger("OnReload");

                isReloading=true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        BulletSpawnPos = transform.GetChild(0).gameObject;
        camera = Camera.main;

        canvas=GameObject.Find("Canvas");
        CurrentWeaponTxtObj=canvas.transform.GetChild(0).gameObject;
        AmmoTxtObj=canvas.transform.GetChild(1).gameObject;
        CurrentWeaponText=GlobalReferenceScript.instance.CurrentWeaponText;
        AmmoText = GlobalReferenceScript.instance.AmmoCounter;

        Player = transform.parent.transform.parent.gameObject;
        
        playerScript = Player.GetComponent<PlayerScript>();

        CurrentWeapon = playerScript.ActiveWeapon;

        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentWeaponText.text =  WeaponNames[CurrentWeapon];
        AmmoText.text = (Ammo[CurrentWeapon, 1 ] / AmmoPerBullet[CurrentWeapon]).ToString()+" / " + (Ammo[CurrentWeapon, 0] / AmmoPerBullet[CurrentWeapon]).ToString();

        SaveWeaponPrefs();

       

    }

    IEnumerator Shoot()
    {

        for (int x = 0; x < BurstAmmount[CurrentWeapon]; x++)
        {
            /*
            MousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            TargetPos = MousePos - BulletSpawnPos.transform.position;

            Angle = Quaternion.LookRotation(Vector3.forward, TargetPos);
            Angle.eulerAngles += Vector3.forward * 90;
            */


            Vector3 Accuracy = new Vector3 { };
            Accuracy.z = Random.Range(-AccuracyValue[CurrentWeapon], AccuracyValue[CurrentWeapon]);

            Angle.eulerAngles= Accuracy+playerScript.LookRotation.eulerAngles;

            Instantiate(Bullet, BulletSpawnPos.transform.position, Angle);

            Ammo[CurrentWeapon,0]--;

            animator.SetTrigger("Fire");

            yield return new WaitForSeconds(RateOfFire[CurrentWeapon,1]);

        }

        
        yield return new WaitForSeconds(RateOfFire[CurrentWeapon, 0]);
        CanFire = true;

        yield return null;
    }

    IEnumerator Reloads()
    {
        yield return null;
    }

    private void OnEnable()
    {
        CanFire = true;
        isReloading = false;
        if (playerScript != null)
        {
            CurrentWeapon = playerScript.ActiveWeapon;
        }
    }


  void SaveWeaponPrefs()
    {
        //SET PISTOL AMMO
        PlayerPrefs.SetInt("PistolAmmo", Ammo[0,0]);
        PlayerPrefs.SetInt("ReservePistolAmmo",Ammo[0,1]);

        //SET PISTOL AMMO
        PlayerPrefs.SetInt("RifleAmmo", Ammo[1,0]);
        PlayerPrefs.SetInt("ReserveRifleAmmo", Ammo[1,1]);

        //SET PISTOL AMMO
        PlayerPrefs.SetInt("ShotgunAmmo", Ammo[2,0]);
        PlayerPrefs.SetInt("ReserveShotgunAmmo", Ammo[2,1]);

        //SET PISTOL AMMO
        PlayerPrefs.SetInt("GLAmmo", Ammo[3,0]);
        PlayerPrefs.SetInt("ReserveGLAmmo", Ammo[3,1]);




    }

    void SetWeaponPrefs()
    {
        // PlayerPrefs.

        if (!isNewGame)
        {
            Ammo[0, 0]= PlayerPrefs.GetInt("PistolAmmo");
            Ammo[0, 1]=PlayerPrefs.GetInt("ReservePistolAmmo" );

            //SET PISTOL AMMO
            Ammo[1, 0] = PlayerPrefs.GetInt("RifleAmmo" );
            Ammo[1, 1] = PlayerPrefs.GetInt("ReserveRifleAmmo");

            //SET PISTOL AMMO
            Ammo[2, 0] = PlayerPrefs.GetInt("ShotgunAmmo");
            Ammo[2, 1] = PlayerPrefs.GetInt("ReserveShotgunAmmo");

            //SET PISTOL AMMO
            Ammo[3, 0] = PlayerPrefs.GetInt("GLAmmo");
            Ammo[3, 1] = PlayerPrefs.GetInt("ReserveGLAmmo");

        }


    }

}
