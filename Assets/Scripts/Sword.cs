using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IUseWeapon
{
    public GameObject _Bullet;
    private Transform _ProjetilePoint;
    public Vector3 mousePos;
    public Vector3 mouseWorld;
    
    public float reloadTime = 2.5f;
    private bool reloading = false;
    private Animator _SwordAnimator;
    public bool canAttack = true;
   

    private WeaponHandler _WeaponHandeler;
    // Start is called before the first frame update
    void Start()
    {
        _ProjetilePoint = gameObject.transform.Find("ProjetilePoint");
        _SwordAnimator = gameObject.GetComponent<Animator>();
       
        _WeaponHandeler = gameObject.GetComponentInParent<WeaponHandler>();
      
        gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UseWeapon()
    {
        if ( canAttack)
        {

            _SwordAnimator.Play("SwordAttack");
            
            
        }
    }



    public void SwordProjectile()
    {

        float angle;
        angle = GetComponentInParent<PlayerController>().GetAngle();
        Instantiate(_Bullet, _ProjetilePoint.position, Quaternion.Euler(0, 0, angle - 180));

    }

    public void AttackStart() 
    {
        canAttack = false;
        _WeaponHandeler.reloading = true;

    }
    public void AttackEnd()
    {
       
        canAttack = true;
        _WeaponHandeler.reloading = false;
       
       

        WeaponFix();
    }

    private void WeaponFix() 
    {
        
        _SwordAnimator.Play("New State");
        canAttack = true;
        _WeaponHandeler.reloading = false;
    }
    public string GetAmmo()
    {
        return "Blood";
    }
    public string GetMaxAmmo()
    {
        return "";
    }

}
