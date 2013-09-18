using UnityEngine;
using System.Collections;

public class FrontPage : MonoBehaviour 
{
	void OnGUI()
	{
		GUILayout.BeginArea ( new Rect ( 0, 0, Screen.width, Screen.height ) );
		if ( GUILayout.Button ( "Question 1" ) )
		{
			Application.LoadLevel ( "Question 1" );
		}
		else if ( GUILayout.Button ( "Question 2" ) )
		{
			Application.LoadLevel ( "Question 2" );
		}
		else if ( GUILayout.Button ( "Question 3" ) )
		{
			Application.LoadLevel ( "Question 3" );
		}
		else if ( GUILayout.Button ( "Question 4" ) )
		{
			Application.LoadLevel ( "Question 4" );
		}
		GUILayout.EndArea();
	}
}
