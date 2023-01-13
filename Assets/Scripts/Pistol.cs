using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Pistol : MonoBehaviour, IUseWeapon, IReloadWeapon
{
    public GameObject _Bullet;
    private Transform _ProjetilePoint;
    public Vector3 mousePos;
    public Vector3 mouseWorld;
    public int ammoClip=3;
    public int ammoClipMax=3;
    public float reloadTime = 2.5f;
    private bool reloading = false;
    private Animator _PistolAnimator;
    private bool canShoot = true;
    private GameObject _SFX;

    private WeaponHandler _WeaponHandeler;
    // Start is called before the first frame update
    void Start()
    {
        _ProjetilePoint = gameObject.transform.Find("ProjetilePoint");
        _PistolAnimator = gameObject.GetComponent<Animator>();
        _WeaponHandeler = gameObject.GetComponentInParent<WeaponHandler>();
        _SFX = GameObject.FindGameObjectWithTag("SFX");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UseWeapon()
    {
        if (ammoClip > 0 && canShoot )
        {
            float angle;
            //Debug.Log("Shooty");
            angle = GetComponentInParent<PlayerController>().GetAngle();
            Instantiate(_Bullet, _ProjetilePoint.position, Quaternion.Euler(0, 0, angle - 180));
            _SFX.GetComponent<SFXH>().PlayerShoot();
            ammoClip--;
            _WeaponHandeler.RefreshUI();
            if (ammoClip == 0)
            {
                ReloadWeapon();
            
            }
        }
        else if (!reloading)
        {
            ReloadWeapon();
            //Debug.Log("No ammo left, reload");
        
        }
    }
    public void WeaponReloaded() 
    {

      
        ammoClip = ammoClipMax;
        canShoot = true;
        _WeaponHandeler.reloading = false;
        reloading = false;
        _PistolAnimator.Play("New State");
       // Debug.Log("Weapon Reloaded");
        _WeaponHandeler.RefreshUI();
    }
    public void ReloadWeapon() 
    {
        canShoot = false;
        _PistolAnimator.Play("PistolReloadAnim");
        _WeaponHandeler.reloading = true;
        reloading = true;
    }
    public string GetAmmo()
    {
        return ammoClip.ToString();
    }
    public string GetMaxAmmo()
    {
        return ammoClipMax.ToString();
    }
}
      
   



