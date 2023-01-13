using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour
{

    public GameObject CurrentWeapon;
    public GameObject _Weapon1;
    public GameObject _Weapon2;
    public GameObject _Weapon3;
    public TextMeshProUGUI _Ammo;
    public RawImage _WeaponImage;

    // public GameObject _Weapon;
    public bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {

        //GiveWeapon();
        if (_Weapon1 != null)
        {
            CurrentWeapon = _Weapon1;

        }
    }
    private void FixedUpdate()
    {

    }



    public void SwitchWeapon(InputAction.CallbackContext context)
    {
       // GetComponentInParent<PlayerController>().TakeDamage(1);
        if (context.started && !reloading && CurrentWeapon != null)
        {

            if (CurrentWeapon == _Weapon1)
            {
                if (_Weapon2 != null)
                {
                    _Weapon1.SetActive(false);
                    _Weapon2.SetActive(true);
                    CurrentWeapon = _Weapon2;
                    RefreshUI();
                }

                else if (_Weapon2 == null && _Weapon3 != null)
                {
                    _Weapon1.SetActive(false);
                    _Weapon3.SetActive(true);
                    CurrentWeapon = _Weapon3;
                    RefreshUI();

                }



            }
            else if (CurrentWeapon == _Weapon2)
            {

                if (_Weapon3 != null)
                {
                    _Weapon2.SetActive(false);
                    _Weapon3.SetActive(true);
                    CurrentWeapon = _Weapon3;
                    RefreshUI();
                }

                else if (_Weapon3 == null && _Weapon1 != null)
                {
                    _Weapon2.SetActive(false);
                    _Weapon1.SetActive(true);
                    CurrentWeapon = _Weapon1;
                    RefreshUI();
                }

            }
            else if (CurrentWeapon == _Weapon3 && _Weapon1 != null)
            {

                _Weapon3.SetActive(false);
                _Weapon1.SetActive(true);
                CurrentWeapon = _Weapon1;
                RefreshUI();
            }
        }
    }
    public void UseWeapon(InputAction.CallbackContext context)
    {

        if (CurrentWeapon != null && context.started && !reloading)
        {
            CurrentWeapon.GetComponent<IUseWeapon>().UseWeapon();


        }
        else if (CurrentWeapon != null && CurrentWeapon.GetComponent<IAutomaticWeapon>() != null && context.canceled)
        {
            Debug.Log("StopSeries");
            CurrentWeapon.GetComponent<IAutomaticWeapon>().StopSeries();


        }



    }
    public void ReloadWeapon(InputAction.CallbackContext context)
    {
        if (CurrentWeapon != null && context.started && !reloading && (CurrentWeapon.GetComponent<IReloadWeapon>() != null))
        {
            CurrentWeapon.GetComponent<IReloadWeapon>().ReloadWeapon();

        }

    }
    public void GiveWeapon(GameObject _Weapon)
    {

        //Debug.Log("GaveWeapontoslot1");
        if (_Weapon1 == null)
        {
            reloading = false;
            if (CurrentWeapon != null) CurrentWeapon.SetActive(false);

            var Temp = Instantiate(_Weapon, gameObject.transform.position, Quaternion.Euler(Vector3.zero));

            CurrentWeapon = Temp;
            _Weapon1 = Temp;

            Temp.transform.parent = gameObject.transform;
            Temp.transform.localPosition = new Vector3(-0.532f, 0.043f, 0);
            Temp.transform.localRotation = Quaternion.Euler(Vector3.zero);
            Temp.transform.localScale = new Vector3(1, 1, 1);
            RefreshUI();
        }
        else if (_Weapon2 == null)
        {
            reloading = false;
            if (CurrentWeapon != null) CurrentWeapon.SetActive(false);

            var Temp = Instantiate(_Weapon, new Vector3(-0.532f, 0.043f, 0), Quaternion.Euler(Vector3.zero));
            CurrentWeapon = Temp;
            _Weapon2 = Temp;

            Temp.transform.parent = gameObject.transform;
            Temp.transform.localPosition = new Vector3(-0.532f, 0.043f, 0);
            Temp.transform.localRotation = Quaternion.Euler(Vector3.zero);
            Temp.transform.localScale = new Vector3(1, 1, 1);
            RefreshUI();
        }
        else if (_Weapon3 == null)
        {
            reloading = false;
            if (CurrentWeapon != null) CurrentWeapon.SetActive(false);

            var Temp = Instantiate(_Weapon, new Vector3(-0.532f, 0.043f, 0), Quaternion.Euler(Vector3.zero));
            CurrentWeapon = Temp;
            _Weapon3 = Temp;

            Temp.transform.parent = gameObject.transform;
            Temp.transform.localPosition = new Vector3(-0.532f, 0.043f, 0);
            Temp.transform.localRotation = Quaternion.Euler(Vector3.zero);
            Temp.transform.localScale = new Vector3(1, 1, 1);
            RefreshUI();

        }


    }
    public void RefreshUI()
    {
        _WeaponImage.color = new Vector4(255, 255, 255, 255);
        string temp1 = CurrentWeapon.GetComponent<IUseWeapon>().GetAmmo();
        string temp2 = CurrentWeapon.GetComponent<IUseWeapon>().GetMaxAmmo();
        _Ammo.text = temp1 + " / " + temp2;
        _WeaponImage.texture = CurrentWeapon.GetComponentInChildren<SpriteRenderer>().sprite.texture;


    }
    public void TurnOnUI()
    { 
    
    
    
    }
}
