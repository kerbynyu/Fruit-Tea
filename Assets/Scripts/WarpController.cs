using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Cinemachine;
using System;
//using UnityEngine.Rendering.PostProcessing;

public class WarpController : MonoBehaviour
{
    private MovementInput input;
    public Animator anim;
    public float timer = 0;
    [SerializeField] float timerSet;
    public int comboHits;
    public bool isLocked;

    public CinemachineFreeLook cameraFreeLook;
    private CinemachineImpulseSource impulse;
    //private PostProcessVolume postVolume;
    //private PostProcessProfile postProfile;

    [Space]

    public List<Transform> screenTargets = new List<Transform>();
    public Transform target;
    public float warpDuration = .5f;

    [Space]

    public Transform sword;
    public Transform swordHand;
    private Vector3 swordOrigRot;
    private Vector3 swordOrigPos;
    private MeshRenderer swordMesh;

    [Space]
    public Material glowMaterial;

    [Space]

    [Header("Particles")]
    public ParticleSystem blueTrail;
    public ParticleSystem whiteTrail;
    public ParticleSystem swordParticle;

    [Space]

    [Header("Prefabs")]
    public GameObject hitParticle;

    [Space]

    [Header("Canvas")]
    public Image aim;
    public Image lockAim;
    public Vector2 uiOffset;

    public float animTime = 0.6f; //time of animations
    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;

        input = GetComponent<MovementInput>();
        anim = GetComponent<Animator>();
        impulse = cameraFreeLook.GetComponent<CinemachineImpulseSource>();
        //postVolume = Camera.main.GetComponent<PostProcessVolume>();
       // postProfile = postVolume.profile;
        swordOrigRot = sword.localEulerAngles;
        swordOrigPos = sword.localPosition;
        swordMesh = sword.GetComponentInChildren<MeshRenderer>();
        swordMesh.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetFloat("Blend", input.Speed);
        UserInterface();

       // if (!input.canMove)
            //return;

        //if (screenTargets.Count < 1)
            //return;

        
        if (!isLocked)
        {
            if (screenTargets.Count > 0)
            {
                target = screenTargets[targetIndex()];
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            LockInterface(true);
            isLocked = true;
        }

        if (Input.GetMouseButtonUp(1) && input.canMove)
        {
            LockInterface(false);
            isLocked = false;
        }

         //currently this scripts inhibit the player because there are no proper enemies in scene

        /*
        if (!isLocked)
        {
            return;
        }

        */ //this fucks up the ability to use the mouse button for both locking on and attacking


        if (Input.GetMouseButtonUp(0) && timer <= 0.4f && playerManager.fruitForm != 2) 
        {
            switch (comboHits)
            {
                case 0:
                    //anim.SetBool("finalHit", false);
                    FirstHit();
                    break;
                case 1:
                    //anim.SetBool("firstHit", false);
                    SecondHit();
                    break;
                case 2:
                    //anim.SetBool("secondHit", false);
                    FinalHit();
                    break;
                default:
                    comboHits = 0;
                    timer = 0;
                    break;
            }

            if (isLocked == true)
            {
                if(target != null) 
                input.RotateTowards(target);
                input.canMove = false;
                swordParticle.Play();
                swordMesh.enabled = true;
                anim.SetTrigger("slash");
                Warp();
            }




        }

        ///*
        if ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("FirstAttack")) || timer <= 0.2f)
        {
            anim.SetBool("firstHit", false);

        }
        if ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("SecondAttack")) || timer <= 0.2f)
        {
            anim.SetBool("secondHit", false);

        }
        if ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("FinalAttack")) || timer <= 0.2f)
        {
            anim.SetBool("finalHit", false);
            comboHits = 0;
        }


        if((anim.GetBool("firstHit") || anim.GetBool("secondHit") || anim.GetBool("finalHit")) && (anim.GetCurrentAnimatorStateInfo(0).normalizedTime == 0))
        {
            anim.SetBool("firstHit", false);
            anim.SetBool("secondHit", false);
            anim.SetBool("finalHit", false);

        }
        //*/

        /*
        if (Input.GetMouseButtonDown(0))
        {
            comboHits++;
            switch (comboHits)
            {
                case 0:
                    FirstHit();
                    break;
                case 1:
                    SecondHit();
                    break;
                case 2:
                    FinalHit();
                    break;
                default:
                    break;
            }


        anim.Play("FirstAttack");
            Debug.Log("TRUEEE");
            switch (comboHits)
            {
                case 0:
                    FirstHit();
                    break;
                case 1:
                    SecondHit();
                    break;
                case 2:
                    FinalHit();
                    break;
                default:
                    break;
            }


        }*/


        if (timer> 0)
            {
                timer -= Time.deltaTime;
            }
        else
        {
            comboHits = 0;
            timer = 0;
            //anim.SetBool("firstHit", false);
            //anim.SetBool("secondHit", false);
            //anim.SetBool("finalHit", false);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = false;
            }
    }

    void FirstHit()
    {
        Debug.Log("First Hit");
        anim.SetBool("finalHit", false);
        anim.SetBool("firstHit", true);
        
        anim.Play("FirstAttack");
        timer = timerSet;
        comboHits++;

    }
    void SecondHit()
    {
        Debug.Log("Second Hit");
        anim.SetBool("firstHit", false);
        anim.SetBool("secondHit", true);
        //anim.Play("SecondAttack");
        timer = timerSet;
        comboHits++;

    }
    void FinalHit()
    {
        Debug.Log("Third Hit");
        anim.SetBool("secondHit", false);
        anim.SetBool("finalHit", true);
        //anim.Play("FinalAttack");
        //comboHits = 0;
        timer = timerSet;
        //timer = 0;   //FInal hit is false instantly!
    }

    private void UserInterface()
    {
        if (target != null)
        {
            aim.transform.position = Camera.main.WorldToScreenPoint(target.position + (Vector3)uiOffset);
        }

        if (!input.canMove)
            return;

        Color c = screenTargets.Count < 1 ? Color.clear : Color.white;
        aim.color = c;
    }

    void LockInterface(bool state)
    {
        float size = state ? 1 : 2;
        float fade = state ? 1 : 0;
        lockAim.DOFade(fade, .15f);
        lockAim.transform.DOScale(size, .15f).SetEase(Ease.OutBack);
        lockAim.transform.DORotate(Vector3.forward * 180, .15f, RotateMode.FastBeyond360).From();
        aim.transform.DORotate(Vector3.forward * 90, .15f, RotateMode.LocalAxisAdd);
    }

    public void Warp()
    {
        GameObject clone = Instantiate(gameObject, transform.position, transform.rotation);
        Destroy(clone.GetComponent<WarpController>().sword.gameObject);
        Destroy(clone.GetComponent<Animator>());
        Destroy(clone.GetComponent<WarpController>());
        Destroy(clone.GetComponent<MovementInput>());
        Destroy(clone.GetComponent<CharacterController>());

        SkinnedMeshRenderer[] skinMeshList = clone.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer smr in skinMeshList)
        {
            smr.material = glowMaterial;
            smr.material.DOFloat(2, "_AlphaThreshold", 5f).OnComplete(()=>Destroy(clone));
        }

        ShowBody(false);
        anim.speed = 0;

        if (target != null)
        {
            transform.DOMove(target.position, warpDuration).SetEase(Ease.InExpo).OnComplete(() => FinishWarp());
        }
        sword.parent = null;
        sword.DOMove(target.position, warpDuration/1.2f);
        sword.DOLookAt(target.position, .2f, AxisConstraint.None);

        //Particles
        blueTrail.Play();
        whiteTrail.Play();

        //Lens Distortion
        DOVirtual.Float(0, -80, .2f, DistortionAmount);
        DOVirtual.Float(1, 2f, .2f, ScaleAmount);
    }

    void FinishWarp()
    {
        ShowBody(true);

        sword.parent = swordHand;
        sword.localPosition = swordOrigPos;
        sword.localEulerAngles = swordOrigRot;

        SkinnedMeshRenderer[] skinMeshList = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer smr in skinMeshList)
        {
            GlowAmount(30);
            DOVirtual.Float(30, 0, .5f, GlowAmount);
        }

        Instantiate(hitParticle, sword.position, Quaternion.identity);

        target.GetComponentInParent<Animator>().SetTrigger("hit");
        target.parent.DOMove(target.position + transform.forward, .5f);

        StartCoroutine(HideSword());
        StartCoroutine(PlayAnimation());
        StartCoroutine(StopParticles());

        isLocked = false;
        LockInterface(false);
        aim.color = Color.clear;

        //Shake
        impulse.GenerateImpulse(Vector3.right);

        //Lens Distortion
        DOVirtual.Float(-80, 0, .2f, DistortionAmount);
        DOVirtual.Float(2f, 1, .1f, ScaleAmount);
    }

    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(.2f);
        anim.speed = 1;
    }

    IEnumerator StopParticles()
    {
        yield return new WaitForSeconds(.2f);
        blueTrail.Stop();
        whiteTrail.Stop();
    }

    IEnumerator HideSword()
    {
        yield return new WaitForSeconds(.8f);
        swordParticle.Play();

        GameObject swordClone = Instantiate(sword.gameObject, sword.position, sword.rotation);

        swordMesh.enabled = false;

        MeshRenderer swordMR = swordClone.GetComponentInChildren<MeshRenderer>();
        Material[] materials = swordMR.materials;

        for (int i = 0; i < materials.Length; i++)
        {
            Material m = glowMaterial;
            materials[i] = m;
        }

        swordMR.materials = materials;

        for (int i = 0; i < swordMR.materials.Length; i++)
        {
            swordMR.materials[i].DOFloat(1, "_AlphaThreshold", .3f).OnComplete(() => Destroy(swordClone));
        }

        input.canMove = true;
    }


    void ShowBody(bool state)
    {
        SkinnedMeshRenderer[] skinMeshList = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer smr in skinMeshList)
        {
            smr.enabled = state;
        }
    }

    void GlowAmount(float x)
    {
        SkinnedMeshRenderer[] skinMeshList = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer smr in skinMeshList)
        {
            smr.material.SetVector("_FresnelAmount", new Vector4(x, x, x, x));
        }
    }

    void DistortionAmount(float x)
    {
        //postProfile.GetSetting<LensDistortion>().intensity.value = x;
    }
    void ScaleAmount(float x)
    {
        //postProfile.GetSetting<LensDistortion>().scale.value = x;
    }

    public int targetIndex()
    {
        float[] distances = new float[screenTargets.Count];

        for (int i = 0; i < screenTargets.Count; i++)
        {
            distances[i] = Vector2.Distance(Camera.main.WorldToScreenPoint(screenTargets[i].position), new Vector2(Screen.width / 2, Screen.height / 2));
        }

        float minDistance = Mathf.Min(distances);
        int index = 0;

        for (int i = 0; i < distances.Length; i++)
        {
            if (minDistance == distances[i])
                index = i;
        }

        return index;

    }

}
