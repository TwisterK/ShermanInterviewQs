using UnityEngine;
using System.Collections;

public class Question4 : MonoBehaviour {
	private void OnGUI ()
	{
		if ( GUILayout.Button ( "Back to front page" ) )
		{
			Application.LoadLevel ( "FrontPage" );
		}
	}
}
