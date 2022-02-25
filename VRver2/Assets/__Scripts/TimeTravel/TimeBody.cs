using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TimeBody : MonoBehaviour {

	bool isRewinding = false;
	public float recordTime = 5f;

	List<PointInTime> pointsInTime;

	Rigidbody rb;

	[Header("XRSetting")]
    public XRNode inputSource;
    private InputDevice device;

	bool pressState;
	bool lookForPress = true;

	public bool ButtonBOOL;
	[SerializeField] BoolManager boolScpt;


	// Use this for initialization
	void Start () 
	{

		device = InputDevices.GetDeviceAtXRNode(inputSource);

		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// device.TryGetFeatureValue(CommonUsages.primaryButton, out pressState);  // a press

		// RewindBool(pressState);

		// RewindBool(Input.GetKey(KeyCode.Return));
		RewindBool(boolScpt.isButtonBOOL);

		// if (Input.GetKeyDown(KeyCode.Return))
		// 	StartRewind();
		// if (Input.GetKeyUp(KeyCode.Return))
		// 	StopRewind();
	}

	void FixedUpdate ()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind ()
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);
		} else
		{
			StopRewind();
			// freeze after click
			DisableRigidBody();
		}
		
	}

	void DisableRigidBody()
	{
		rb.isKinematic = true;
	}

	void Record ()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

	public void StartRewind ()
	{
		isRewinding = true;
		rb.isKinematic = true;
	}

	public void StopRewind ()
	{
		isRewinding = false;
		rb.isKinematic = false;
	}

	public void RewindBool(bool _b)
	{
		isRewinding = _b;
		rb.isKinematic = _b;
	}
}
