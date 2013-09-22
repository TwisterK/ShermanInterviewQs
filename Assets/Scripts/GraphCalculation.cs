using UnityEngine;
using System.Collections;

public class GraphCalculation : MonoBehaviour 
{
	private const int BASE_NUMBER = 8;
	private string position = "3,2";
	private string answer = "Please enter position with this format : X,Y";
	
	private void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (Screen.width * 0.5F, Screen.height * 0.5F, 500F, 500F));
		GUILayout.Label ( "Point : " );
		position = GUILayout.TextField ( position, 3 );
		if ( GUILayout.Button ( "Calculate" ) )
		{
			try
			{
				answer = GetAnswer ( position ).ToString();
			}
			catch ( System.Exception e )
			{
				answer = "Error occured, please check your input again.\nPlease enter position with this format : X,Y";
			}
		}
		GUILayout.Label ( answer );
		
		if ( GUILayout.Button ( "Back to front page" ) )
		{
			Application.LoadLevel ( "FrontPage" );
		}
		
		GUILayout.EndArea ();
	}
	
	/// <summary>
	/// Gets the answer.
	/// </summary>
	/// <returns>
	/// The answer.
	/// </returns>
	/// <param name='position'>
	/// Position.
	/// </param>
	private int GetAnswer ( string position )
	{
		// split the data then process it
		string [] pos = position.Split ( ',' );
		
		// Get the second number and process it
		int baseNumber = int.Parse ( pos [ 1 ] );
		int totalNumber = 0;
		
		// Do a simple calculation by adding two number together depend on the base number
		// For example, if we look for position 5,6
		// It will calculate as total number  = (8x6) + 5 = 53
		totalNumber = BASE_NUMBER * baseNumber + int.Parse ( pos [ 0 ] );
		
		return totalNumber;
	}
}
