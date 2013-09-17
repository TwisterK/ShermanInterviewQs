using UnityEngine;
using System.Collections;

public class GraphCalculation : MonoBehaviour 
{
	private float ratio;
	private string txtStart = "3";
	private string txtDesti = "5";
	private string answer = string.Empty;
	
	private float GetRatio()
	{
		if ( ratio == 0.0F )
		{
			float result = Mathf.Sqrt ( Mathf.Pow ( 3F, 2F ) + Mathf.Pow ( 5F, 2F ) );
			ratio = 29F / result;
		}
		
		return ratio;
	}
	
	private void Start()
	{
		Debug.Log ( GetAnswer ( 3F, 5F ) );
		Debug.Log ( GetAnswer ( 3F, 4F ) );
		Debug.Log ( GetAnswer ( 6F, 1F ) );
		Debug.Log ( GetAnswer ( 3F, 4F ) );
		Debug.Log ( GetAnswer ( 2F, 7F ) );
	}
	
	private void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (Screen.width * 0.5F, Screen.height * 0.5F, 500, 500));
		GUILayout.Label ( "X" );
		txtStart = GUILayout.TextField ( txtStart, 1 );
		GUILayout.Label ( "Y" );
		txtDesti = GUILayout.TextField ( txtDesti, 1 );
		if ( GUILayout.Button ( "Calculate" ) )
		{
			answer = GetAnswer ( float.Parse ( txtStart ), float.Parse ( txtDesti ) );
		}
		GUILayout.Label ( answer );
		GUILayout.EndArea ();
	}

	private string GetAnswer (float par1, float par2)
	{
		return "Answer for (" + par1 + "," + par2 + ") is " + Mathf.Sqrt ( Mathf.Pow ( par1, 2F ) + Mathf.Pow ( par2, 2F ) ) * GetRatio ();
	}
}
