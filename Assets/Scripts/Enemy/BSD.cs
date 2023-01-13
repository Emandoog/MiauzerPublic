using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BSD : MonoBehaviour, ITakeDamage
{
    public Transform player;
    public Rigidbody2D slime;
    public GameObject MachineGun;
    public GameObject MachineGun2;
    public GameObject markPlayer;
    public GameObject patternBullet;
    public GameObject XpatternBullet; 
    public GameObject TrackerBullet;
    public GameObject MachineGunMine;

    public GameObject _TrackerLocation;
    public GameObject _XpatternLocation;

    public GameObject _HealthBar2;
    public Slider _HealthBar;
    private GameObject _SFX;

    public int life = 1000;
    public int MaxLife = 1000;
    private int numberOfAttacks = 85;
    private int choosenAttacks;
    public float attackRange = 10f;
    private float speed = 2f;
    private float time;
    private float angel = 10;
    private bool fin = false;
    private Animator _Animator;


    void Start()
    {
        _HealthBar2.SetActive(true);
        // _HealthBar.enabled = true;
        _HealthBar.value = life;
        _HealthBar.maxValue = MaxLife;
        _SFX = GameObject.FindGameObjectWithTag("SFX");
        _Animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        slime = this.GetComponent<Rigidbody2D>();
        StartCoroutine(BOSS());
        //InvokeRepeating("Fire", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int Damage)
    {
        life -= Damage;
        _HealthBar.value =life;
        if (life <= 0)
        {
            Debug.Log("Boss Dead");
            SceneManager.LoadScene(2);
            Destroy(gameObject, 2);

        }

    }
    IEnumerator BOSS()
    {
        yield return new WaitForSeconds(1);
        choosenAttacks = Random.Range(0, numberOfAttacks);
        Debug.Log("BossAttacks");
        Debug.Log(choosenAttacks);

        //StartCoroutine(BoosMachineGunMine());

        if (choosenAttacks <= 15)
        {
            //StartCoroutine(BoosMachineGun());
            _Animator.Play("BossMineAttack");
        }
        else if (choosenAttacks <= 31 && choosenAttacks > 15)
        {
            StartCoroutine(markAttack());
        }
        else if (choosenAttacks <= 47 && choosenAttacks > 31)
        {
            _Animator.Play("BossXPattern");
        }
        else if (choosenAttacks <= 63 && choosenAttacks > 47)
        {
            StartCoroutine(Tracker());
            //StartCoroutine(xAndPlusPatern());
        }
        else if (choosenAttacks > 63 )
        {
            _Animator.Play("BossMachineGunAttack");
        }
        
    }
    IEnumerator BoosMachineGun()
    {
        for (int i = 0; i <= 60; i++)
        {
            yield return new WaitForSeconds(0.1f);
            _SFX.GetComponent<SFXH>().BossAttackMashingGunSFX();
            Instantiate(MachineGun, transform.position, Quaternion.identity);
        }
        StartCoroutine(BOSS());
    }
    IEnumerator markAttack()
    {
        _Animator.Play("BossSpikeAttack");
        //Debug.Log("dzia³a 1/2");
        yield return new WaitForSeconds(0);

        ////Debug.Log("Thorns");
       // for (int i = 0; i < 3; i++) {
        //    yield return new WaitForSeconds(1f);
         //   SpawnThorns();
       // }
        //StartCoroutine(BOSS());
    }
    public void SpawnThorns()
    {

        var randx = Random.Range(-5, 5);
        var randy = Random.Range(-5, 5);
        _SFX.GetComponent<SFXH>().BossAttackMarkSFX();
        var target = new Vector2(player.position.x + randx, player.position.y + randy);

        Instantiate(markPlayer, target, Quaternion.identity);

    }

    IEnumerator xAndPlusPatern()
    {
       
        var TempTransform = _XpatternLocation.transform.position;
        int temp = 0;

        _SFX.GetComponent<SFXH>().voidBossAttackXSFX();

            //yield return new WaitForSeconds(0);
            for (int i = 0; i <= 3; i++)
            {

                SpawnPattern(temp);
                temp++;
           
            }
        
        yield return new WaitForSeconds(1f);
        _SFX.GetComponent<SFXH>().voidBossAttackXSFX();
        for (int aa = 0; aa <= 3; aa++)
            {
                SpawnPattern(temp);
                temp++;
            }

       
        //Debug.Log("StartNewCorutine");
        //StartCoroutine(BOSS());
    }

    public void SpawnXpattern()
    {
    
    
    }
    public void SpawnPattern(int temp)
    {
        var temp2 = Instantiate(XpatternBullet, _XpatternLocation.transform.position, Quaternion.identity);
        temp2.GetComponent<OKwhy>().Direction(temp);
    }
    //public void SpawnPLusPattern(int temp)
    //{
    //    var temp2 = Instantiate(patternBullet, transform.position, Quaternion.identity);
    //    temp2.GetComponent<OKwhy>().Direction(temp);
        
    //}

    IEnumerator Tracker()
    {
        _Animator.Play("BossHomingAttack");
        //Debug.Log("dzia³a 1/2");
        yield return new WaitForSeconds(0);
       
        //StartCoroutine(BOSS());
    }
    public void SpawnTracker()
    {
        //Debug.Log("TrackerAttack");
        _SFX.GetComponent<SFXH>().BossAttackTrackerSFX();
        Instantiate(TrackerBullet, _TrackerLocation.transform.position, Quaternion.Euler( new Vector3(0,0,0)));

    }

    IEnumerator BoosMachineGunMine() 
    {
        yield return new WaitForSeconds(0);
        for (int iii = 0; iii <= 20;iii++) 
        {
            yield return new WaitForSeconds(0.4f);
            _SFX.GetComponent<SFXH>().BossAttackMashingGunSFX();
            Instantiate(MachineGunMine, transform.position, Quaternion.identity);
        }
       // StartCoroutine(BOSS());
    }
    public void NextAttack() 
    {
        _Animator.Play("BossIdle");
        StartCoroutine(BOSS());


    }
   
}
