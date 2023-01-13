using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, ITakeDamage
{
    public GameObject _deathScreeen;
    private Transform Weapon;
    public Vector3 mousePos;
    public Vector3 mouseWorld;
    public Vector3 Position;
    private float angle;
    private Rigidbody2D _RB;
    private CatInputActions catInputsActions;
    private InputAction movement;
    public int life = 5;
    public int maxLife = 5;
    public float movementSpeed = 10;
    private Animator _PlayerAnim;
    public bool dashing;
    public GameObject _Timer;
    public float dashCooldown = 2f;
    private bool DashOnCD = false;
    public Sprite _Life1;
    public Sprite _Life2;
    public Sprite _Life3;
    public Sprite _Life4;
    public Sprite _Life5;
    public Sprite _CurrentLife;
    public RawImage _Lifebar;
    private bool protectedd = false;
    public static bool GameIsPause = false;
    public GameObject pauseMenu;
    private GameObject _SFX;
    private bool dead = false;
    // public InputAction inputs;

    private void Awake()
    {
        catInputsActions = new CatInputActions();
    }
    private void OnEnable()
    {
        movement = catInputsActions.TopDown.Movement;
        movement.Enable();
        //inputs.Enable();
        catInputsActions.TopDown.UseWeapon.started += GetComponentInChildren<WeaponHandler>().UseWeapon;
        catInputsActions.TopDown.UseWeapon.canceled += GetComponentInChildren<WeaponHandler>().UseWeapon;
        catInputsActions.TopDown.UseWeapon.Enable();

        catInputsActions.TopDown.ReloadWeapon.started += GetComponentInChildren<WeaponHandler>().ReloadWeapon;
        catInputsActions.TopDown.ReloadWeapon.Enable();

        catInputsActions.TopDown.SwitchWeapons.started += GetComponentInChildren<WeaponHandler>().SwitchWeapon;
        catInputsActions.TopDown.SwitchWeapons.Enable();

        catInputsActions.TopDown.Dash.started += Dash;
        catInputsActions.TopDown.Dash.Enable();

        catInputsActions.TopDown.Pause.started += Pause;
        catInputsActions.TopDown.Pause.Enable();

    }
    void Start()
    {
        Time.timeScale = 1;
        _SFX = GameObject.FindGameObjectWithTag("SFX");
        _CurrentLife = _Life1;
        _PlayerAnim = gameObject.GetComponent<Animator>();
        Weapon = gameObject.transform.Find("WeaponSlot");
        _RB = gameObject.GetComponent<Rigidbody2D>();
        


    }
    private void OnDisable()
    {
        movement.Disable();
        catInputsActions.TopDown.UseWeapon.Disable();
        catInputsActions.TopDown.ReloadWeapon.Disable();
        catInputsActions.TopDown.SwitchWeapons.Disable();
        catInputsActions.TopDown.Pause.Disable();
        catInputsActions.TopDown.Dash.Disable();
    }


    void Update()
    {
        GetAngle();
        if (angle < 92 && angle > -82)
        {
            Weapon.transform.localScale = new Vector3(1, -1, 1);

        }
        else
        {
            Weapon.transform.localScale = new Vector3(1, 1, 1);

        }
        


        //Weapon.transform.rotation = Weapon.transform.LookAt(new Transform(MousePos.x, MousePos.y, 0));
    }

    private void FixedUpdate()
    {


        if (!dashing)
        {
            _RB.velocity = movement.ReadValue<Vector2>() * movementSpeed;
            _PlayerAnim.SetFloat("Speed", _RB.velocity.x);
            _PlayerAnim.SetFloat("SpeedHorizontal", Mathf.Abs(_RB.velocity.y));
        }



    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started && !DashOnCD)
        {
            DashOnCD = true;
            //_RB.velocity = movement.ReadValue<Vector2>() * movementSpeed;
            _PlayerAnim.Play("PlayerDash");
            _SFX.GetComponent<SFXH>().PlayerDashSFX();

        }


    }
    public float GetAngle()
    {

        mouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - Weapon.transform.position;


        mouseWorld.Normalize();
        angle = Mathf.Atan2(mouseWorld.y, mouseWorld.x) * Mathf.Rad2Deg;

        Weapon.transform.rotation = Quaternion.Euler(0, 0, angle - 180);

        return angle;
    }
    public void TakeDamage(int damage = 1)
    {
       

        if (!protectedd)
        {
            Protected();
            _PlayerAnim.Play("TakeDamage", 2);
            life -= damage;
            _SFX.GetComponent<SFXH>().PlayerDeathSFX();
            if (life <= 0)
            {

                catInputsActions.TopDown.UseWeapon.Disable();
                catInputsActions.TopDown.ReloadWeapon.Disable();
                catInputsActions.TopDown.SwitchWeapons.Disable();
                catInputsActions.TopDown.Pause.Disable();
                catInputsActions.TopDown.Dash.Disable();
                _deathScreeen.SetActive(true);
                Time.timeScale = 0;

            }
            if (life == 5)
            {
                _CurrentLife = _Life1;
                _Lifebar.texture = _CurrentLife.texture;

            }
            else if (life == 4)
            {
                _CurrentLife = _Life2;
                _Lifebar.texture = _CurrentLife.texture;
            }
            else if (life == 3)
            {
                _CurrentLife = _Life3;
                _Lifebar.texture = _CurrentLife.texture;

            }
            else if (life == 2)
            {
                _CurrentLife = _Life4;
                _Lifebar.texture = _CurrentLife.texture;

            }
            else if (life == 1)
            {
                _CurrentLife = _Life5;
                _Lifebar.texture = _CurrentLife.texture;

            }
        }
       


    }

    public void Pause(InputAction.CallbackContext context) 
    {
        if (GameIsPause)
        {
            Resume();
        }
        else 
        {
            PauseTrigger();
        }
    }
    public void Resume() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPause = false;
    }
    private void PauseTrigger() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPause = true;
    }

    public void NewGame() 
    {
        SceneManager.LoadScene(1);
    }
    public void Quit() 
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //public void PauseButton 


    public void DashStart()
    {
        dashing = true;
        gameObject.layer = 10;
        _RB.velocity = new Vector2(0, 0);

        if (movement.ReadValue<Vector2>() == new Vector2(0, 0))
        {
            if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {

                _RB.velocity = new Vector2(1 * movementSpeed * 2, 0);


            }
            else if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {

                _RB.velocity = new Vector2(-1 * movementSpeed * 2, 0);


            }
        }
        else
        {

            _RB.velocity = movement.ReadValue<Vector2>() * movementSpeed * 2;
        }

    }
    public void DashEnd()
    {
        dashing = false;
        gameObject.layer = 6;
        _RB.velocity = new Vector2(0, 0);
        StartCoroutine(DashCD());
        ;

    }

    IEnumerator DashCD()
    {
        _Timer.SetActive(true);
        yield return new WaitForSeconds(dashCooldown);

        _Timer.SetActive(false);
        DashOnCD = false;


    }
    public void FlipLeft()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;



    }
    public void FlipRight()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = false;



    }

    public void Protected()
    {
        if (!protectedd)
        { 
            _PlayerAnim.Play("Protection",1);
            protectedd = true;
            StartCoroutine(ProtectionTime());
        }

    }

    IEnumerator ProtectionTime()
    {
        gameObject.layer=10;
        yield return new WaitForSeconds(2);
        _PlayerAnim.Play("New State", 1);
        gameObject.GetComponent<SpriteRenderer>().color = new Vector4(255, 255, 255, 255);
        gameObject.layer = 6;
        protectedd = false;
    }
}


