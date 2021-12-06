using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations.Rigging;
using UnityEngine;

public class animController : MonoBehaviour
{

    public Animator anim;
    public bool isWalking;
    public bool isRunning;
    public bool isIdle;
    public bool isAiming;

    public GameObject weapon;
    /// <weapon ready/ not ready>
    public Transform WReady;
    public Transform WNotReady;

    public GameObject player;
    public GameObject rigLayerWeaponAim;
    /// </summary>
    public GameObject muzzleFlash;

    public GameObject target;
    public GameObject atBar;
    public GameObject playerStatus;

    public float normalAttackSpeed;

    public GameObject rightHandIK;

    public bool isHealing;
    public GameObject healEffect;
    public GameObject healingSound;
    // Start is called before the first frame update
    void Start()
    {
        isHealing = false;
        normalAttackSpeed = 1f;
        WNotReady.transform.position = weapon.transform.position;
        WNotReady.transform.rotation = weapon.transform.rotation;
     
        isWalking = false;
        isRunning = false;
        isIdle = true;
        isAiming = false;

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if(isHealing)
        {
            rightHandIK.GetComponent<TwoBoneIKConstraint>().weight = 0;
        }
        else if(!isHealing)
        {
            rightHandIK.GetComponent<TwoBoneIKConstraint>().weight = 1;
        }
        if (player.GetComponent<player>().isMoving)
        {
            anim.SetBool("isRunning",true);
            anim.SetBool("isFiring",false);
            anim.SetBool("idle", false);
            rigLayerWeaponAim.GetComponent<Rig>().weight = 0;
         
        }
        if (!player.GetComponent<player>().isMoving)
        {
            anim.SetBool("idle",true);
            anim.SetBool("isRunning",false);
            anim.SetBool("isFiring",false);
            rigLayerWeaponAim.GetComponent<Rig>().weight = 0;
            

        }
        if (player.GetComponent<player>().isAiming)
        {
            anim.SetBool("idle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isFiring", false);
            rigLayerWeaponAim.GetComponent<Rig>().weight = 1;
        }

        if (player.GetComponent<player>().isFiring)
        {
            
            rigLayerWeaponAim.GetComponent<Rig>().weight = 1;
            anim.SetBool("isFiring",true);
            anim.SetBool("idle",false);
            anim.SetBool("isRunning",false);

        }
        
      
    }
    public void setIsFiringTrue()
    {
        anim.speed = player.GetComponent<player>().attackSpeed;
        player.GetComponent<player>().enabled = true;
    }
    public void muzzlFlash()
    {
        if(muzzleFlash.activeSelf)
        {
            muzzleFlash.SetActive(false);
        }
        else
        {
            
            
            muzzleFlash.SetActive(true);
            target = player.GetComponent<player>().target;
            target.SendMessage("takeDamage", player.GetComponent<player>().attack);
            playerStatus.GetComponent<playerStatus>().currentAt = 0;
        }
    }
    public void setIsFiringFalse()
    {
        anim.speed = normalAttackSpeed;
        player.GetComponent<player>().enabled = true;
        player.GetComponent<player>().isFiring = false;
    }

    public void playGunshotSound()
    {
        weapon.GetComponent<AudioSource>().Play();
    }

    public void relaxRightIK()
    {
        isHealing = true;
        
    }

    public void tightenRightIk()
    {
        isHealing = false;
        anim.SetBool("isHealing", false);
    }

    public void playHealEffect()
    {
        playerStatus.GetComponent<playerStatus>().currentMp =0;
        healingSound.GetComponent<AudioSource>().Play();
        healEffect.GetComponent<ParticleSystem>().Play();
    }
}
