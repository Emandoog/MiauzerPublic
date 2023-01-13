using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXH : MonoBehaviour
{
    private AudioSource SFX1;
    public AudioClip ShootP;
    public AudioClip PlayerDash;
    public AudioClip PlayerDeath;

    public AudioClip EnemyExplosion;
    public AudioClip StarAttack;
    public AudioClip EnemyDeath;
    public AudioClip BossAttackX;
    public AudioClip BossAttackTracker;
    public AudioClip BossAttackMashingGun;
    public AudioClip BossAttackMark;

    
    void Start()
    {
        SFX1 = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        
    }

    public void PlayerShoot()
    {
        //SFX1.clip = ShootP;
        //SFX1.Play();
        SFX1.PlayOneShot(ShootP);
    }
    public void PlayerDashSFX() 
    {
        
        SFX1.PlayOneShot(PlayerDash);
       
    }
    public void PlayerDeathSFX() 
    {
        SFX1.PlayOneShot(PlayerDeath);
       // SFX1.clip = PlayerDeath;
        //SFX1.Play();
    }
    public void EnemyExplosionSFX() 
    {
        //SFX1.clip = EnemyExplosion;
        SFX1.PlayOneShot(EnemyExplosion);
    }
    public void StarAttackSFX() 
    {
        SFX1.PlayOneShot(StarAttack);
        
    }
    public void EnemyDeathSFX() 
    {
        SFX1.PlayOneShot(EnemyDeath);
        
    }
    public void voidBossAttackXSFX() 
    {
        SFX1.PlayOneShot(BossAttackX);
      
    }
    public void BossAttackTrackerSFX() 
    {
        SFX1.PlayOneShot(BossAttackTracker);
        
    }
    public void BossAttackMashingGunSFX() 
    {
        SFX1.PlayOneShot(BossAttackMashingGun);

        
    }
    public void BossAttackMarkSFX() 
    {
        SFX1.PlayOneShot(BossAttackMark);
      
    }
}
