using UnityEngine;
using System.Collections;

/// <summary>
/// Script that allow y axis to rotate
/// </summary>
public class PivotSpinY : MonoBehaviour 
{	
	private const float cosmicConstant = 500F;
	/// <summary>
	/// The color of the planet/sun/moon
	/// </summary>
	public Color color = Color.white;
	
	/// <summary>
	/// The planet transform.
	/// </summary>
	private Transform planetTransform;
	
	/// <summary>
	/// The this transform.
	/// </summary>
	private Transform thisTransform;
	
	/// <summary>
	/// The speed.
	/// </summary>
	private float speed;
	
	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake()
	{
		thisTransform = this.transform;
		
		// Set the planet/sun/moon at random rotation so it start off at different location
		thisTransform.localEulerAngles = new Vector3 ( 0F, Random.Range ( 0F, 360F ), 0F );
		
		// Cache the planet transform for performance sake.
		planetTransform = thisTransform.GetChild ( 0 ).transform;
		
		// Calculate the speed of the planet orbit based on gravity formula
		// Use Sqrt function to emulate the planet orbit 
		speed =  cosmicConstant / Mathf.Sqrt ( Mathf.Abs ( planetTransform.localPosition.z ) );
		
		// Some of the planet will the anti clockwise and some of them will be clock wise
		if ( Random.Range ( 0, 2 ) == 1 )
		{
			speed = -speed;
		}
		
		// Give the planet some color to regconize them.
		GetComponentInChildren<Renderer>().material.SetColor ( "_TintColor", color );
	}
	
	// Update is called once per frame
	void Update () 
	{
		thisTransform.Rotate ( new Vector3 ( 0F, speed, 0F ) * Time.deltaTime );
	}
}
