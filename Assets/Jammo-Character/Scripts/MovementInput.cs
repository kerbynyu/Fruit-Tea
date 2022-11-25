
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

    public float velocity = 9;
    [Space]

	public float InputX;
	public float InputZ;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;
	public Animator anim;
	public float Speed;
	public float allowPlayerRotation = 0.1f;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;


    private float verticalVel;
    private Vector3 moveVector;
    public bool canMove;


	float timer = 0;
	[SerializeField] float timerSet;
	public int comboHits;

	[SerializeField] float coolDown = 2f;
	private float nextFireTime = 0f;
	float lastClickedTime = 0;
	float maxComboDelay = 1f;
	float animTime = 0.7f;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (!canMove)
            return;

        InputMagnitude ();

		//If you don't need the character grounded then get rid of this part.
		//isGrounded = controller.isGrounded;
		//if (isGrounded) {
		//	verticalVel -= 0;
		//} else {
		//	verticalVel -= .05f * Time.deltaTime;
		//}
		//moveVector = new Vector3 (0, verticalVel, 0);
		//controller.Move (moveVector);

		//Updater


		if (Input.GetMouseButtonUp(0))
		{
			/*
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
			}*/

			OnClick();
		}



		if (Time.time - lastClickedTime > maxComboDelay)
		{
			comboHits = 0;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = false;
		}

		if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("FirstAttack"))
		{
			anim.SetBool("firstHit", false);

		}
		if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("SecondAttack"))
		{
			anim.SetBool("secondHit", false);

		}
		if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("FinalAttack"))
		{
			anim.SetBool("finalHit", false);
			comboHits = 0;
		}

	}

	void FirstHit()
	{
		Debug.Log("First Hit");
		anim.Play("FirstAttack");
		comboHits++;
		timer = timerSet;
	}
	void SecondHit()
	{
		Debug.Log("Second Hit");
		anim.Play("SecondAttack");
		comboHits++;
		timer = timerSet;
	}
	void FinalHit()
	{
		Debug.Log("Third Hit");
		anim.Play("FinalAttack");
		comboHits = 0;
		timer = 0;
	}

	void OnClick()
	{
		lastClickedTime = Time.time;
		comboHits++;
		if (comboHits == 1)
		{
			anim.SetBool("firstHit", true);
		}
		comboHits = Mathf.Clamp(comboHits, 0, 3);

		if (comboHits >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("FirstAttack"))
		{
			anim.SetBool("firstHit", false);
			anim.SetBool("secondHit", true);
		}

		if (comboHits >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("SecondAttack"))
		{
			anim.SetBool("secondHit", false);
			anim.SetBool("finalHit", true);
		}
	}

	void PlayerMoveAndRotation() {
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");
		
		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

		desiredMoveDirection = forward * InputZ + right * InputX;

		if (blockRotationPlayer == false) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * velocity);
		}
	}

    public void RotateToCamera(Transform t)
    {

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

    public void RotateTowards(Transform t)
    {
        transform.rotation = Quaternion.LookRotation(t.position - transform.position);

    }

    void InputMagnitude() {
		//Calculate Input Vectors
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		//anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
		//anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

		//Calculate the Input Magnitude
		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

		//Physically move player
		if (Speed > allowPlayerRotation) {
			//anim.SetFloat ("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation ();
		} else if (Speed < allowPlayerRotation) {
			//anim.SetFloat ("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);
		}
	}
}
