using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carabine : MonoBehaviour ,IUseWeapon,IAutomaticWeapon, IReloadWeapon
{
    public GameObject _Bullet;
    private Transform _ProjetilePoint;
    public Vector3 mousePos;
    public Vector3 mouseWorld;
    public int ammoClip = 3;
    public int ammoClipMax = 3;
    public float reloadTime = 2.5f;
    private bool reloading = false;
    private Animator _CarabineAnimator;
    private bool canShoot = true;
    private ParticleSystem _CarabineParticle;
    public float delay =0.2f;
    public bool stopShooting = false;
    private GameObject _SFX;


    private WeaponHandler _WeaponHandeler;
    // Start is called before the first frame update
    void Start()
    {
        _ProjetilePoint = gameObject.transform.Find("ProjetilePoint");
        _CarabineAnimator = gameObject.GetComponent<Animator>();
        _CarabineParticle = gameObject.GetComponent<ParticleSystem>();
        _WeaponHandeler = gameObject.GetComponentInParent<WeaponHandler>();
        _CarabineParticle.Stop();
        gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, 0,0);
        _SFX = GameObject.FindGameObjectWithTag("SFX");
    }


    private void OnEnable()
    {
        _CarabineAnimator.enabled = true;
        //gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        _CarabineParticle = gameObject.GetComponent<ParticleSystem>();
        _CarabineParticle.Stop();
    }
    private void OnDisable()
    {
        _CarabineAnimator.enabled = false;
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void UseWeapon()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (ammoClip > 0 && canShoot)
        {
            stopShooting = false;
            StartCoroutine(ShootDelay());
        }
        else if (!reloading)
        {
            ReloadWeapon();
            Debug.Log("No ammo left, reload");

        }
    }
    public void WeaponReloaded()
    {


        ammoClip = ammoClipMax;
        canShoot = true;
        _WeaponHandeler.reloading = false;
       
        _WeaponHandeler.RefreshUI();
        _CarabineParticle.Stop();
        _CarabineAnimator.Play("New State");
        Debug.Log("Weapon Reloaded");
        if (!stopShooting) 
        {
            StartCoroutine(ShootDelay());
        }
    }
    public void ReloadWeapon()
    {
        canShoot = false;
        _CarabineParticle.Play();
        _CarabineAnimator.Play("CarabineReload");
        _WeaponHandeler.reloading = true;
    }
   

    public void ParticleSystemOn()
    {
        _CarabineParticle.Play();


    }
    public void ParticleSystemOff()
    {
        _CarabineParticle.Stop();


    }
    public void StartSeries() 
    {
        stopShooting = false;
        StartCoroutine(ShootDelay());
    }
    public void StopSeries()
    {
        stopShooting = true;
    }
    IEnumerator ShootDelay()
    {
       
        
        float angle;
        
        angle = GetComponentInParent<PlayerController>().GetAngle();
        Instantiate(_Bullet, _ProjetilePoint.position, Quaternion.Euler(0, 0, angle - 180 + Random.Range(-20, 20)));
        _SFX.GetComponent<SFXH>().PlayerShoot();
        ammoClip--;
        _WeaponHandeler.RefreshUI();
        if (ammoClip == 0)
        {
            ReloadWeapon();
         
        }
        yield return new WaitForSeconds(delay);
       
        if (!stopShooting && ammoClip > 0 && canShoot) 
        {
            StartCoroutine(ShootDelay());
        }
       
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
