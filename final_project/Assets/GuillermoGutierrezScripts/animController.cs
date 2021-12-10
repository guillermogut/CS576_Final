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
    public GameObject rigLayerWeaponFiring;
    /// </summary>
    public GameObject muzzleFlash;
    public bool recoil;
    public GameObject target;
    public GameObject atBar;
    public GameObject playerStatus;

    public float normalAttackSpeed;

    public GameObject rightHandIK;

    public bool isHealing;
    public GameObject healEffect;
    public GameObject healingSound;

    public GameObject hasteEffect;
    public GameObject hasteSound;

    public GameObject protectEffect;
    public GameObject protectSound;

    public List<GameObject> walkingSounds;
    public GameObject walkingSoundObject;

    public GameObject freeLookCam;

    public int abilityNum; // 0 for heal, 1 for haste, 2 for protect
    // Start is called before the first frame update
    void Start()
    {
        recoil = false;
        isHealing = false;
        normalAttackSpeed = 1f;
        WNotReady.transform.position = weapon.transform.position;
        WNotReady.transform.rotation = weapon.transform.rotation;
     
        isWalking = false;
        isRunning = false;
        isIdle = true;
        isAiming = false;

        anim = GetComponent<Animator>();
        popSounds();
    }

    // Update is called once per frame
    void Update()
    {
        if(recoil)
        {
            //rigLayerWeaponFiring.GetComponent<Rig>().weight += .999f *Time.deltaTime;
            rigLayerWeaponFiring.GetComponent<Rig>().weight = Mathf.Lerp(0, 1, .5f);

        }
        else if(!recoil)
        {
            rigLayerWeaponFiring.GetComponent<Rig>().weight -= .9f * Time.deltaTime;
            //rigLayerWeaponFiring.GetComponent<Rig>().weight = Mathf.Lerp(1, 0, .5f);
        }
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
            Debug.Log("reeeee");
            anim.SetBool("idle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isFiring", false);
            rigLayerWeaponAim.GetComponent<Rig>().weight = 1f;
            
        }

        if (player.GetComponent<player>().isFiring)
        {
            
            rigLayerWeaponAim.GetComponent<Rig>().weight = 1;
            anim.SetBool("isFiring",true);
            anim.SetBool("idle",false);
            anim.SetBool("isRunning",false);

        }
        //if(player.GetComponent<player>().isHit)
        //{
        //    anim.SetBool("isFiring", false);
        //    anim.SetBool("idle", false);
        //    anim.SetBool("isRunning", false);
        //    anim.SetBool("pepsi", false);
        //    anim.SetBool("isHit", true);
        //}
        if(player.GetComponent<player>().pepsi)
        {
            //player.GetComponent<player>().isHit = false;
            anim.SetBool("isFiring", false) ;
            anim.SetBool("idle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("pepsi", true);
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
            recoil = false;
            muzzleFlash.SetActive(false);
        }
        else
        {

            recoil = true;
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
    public void playHasteEffect()
    {
        playerStatus.GetComponent<playerStatus>().currentMp = 0;
        hasteSound.GetComponent<AudioSource>().Play();
        hasteEffect.GetComponent<ParticleSystem>().Play();
    }
    public void playProtectEffect()
    {
        playerStatus.GetComponent<playerStatus>().currentMp = 0;
        protectSound.GetComponent<AudioSource>().Play();
        protectEffect.GetComponent<ParticleSystem>().Play();
    }

    public void popSounds()
    {
        for(int i = 0; i< walkingSoundObject.transform.childCount;i++)
        {

            walkingSounds.Add(walkingSoundObject.transform.GetChild(i).gameObject);
        }
    }
    public void stepSound()
    {
        int randoInt = UnityEngine.Random.Range(0,5);

        walkingSounds[randoInt].GetComponent<AudioSource>().Play();


    }
    public void playEffect()
    {
        if(abilityNum == 0)
        {
            playHealEffect();
        }
        else if(abilityNum == 1)
        {
            playHasteEffect();
        }
        else
        {
            playProtectEffect();
        }
    }

    public void freeze()
    {
        player.GetComponent<player>().doingAThing = true;
    }
    public void unfreeze()
    {
        player.GetComponent<player>().doingAThing = false;
    }

    public void setFade()
    {
        freeLookCam.GetComponent<thirdPersonCamera>().fade = true;
    }
    public void resetHit()
    {
        //player.GetComponent<player>().isHit = false;
    }
}
