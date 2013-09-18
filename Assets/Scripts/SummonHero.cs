using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SummonHero : MonoBehaviour
{
//	1. Hulk
//	2. Superman
//	3. Batman
//	4. Thing
//	5. Iceman
//	6. Antman
//	7. Daredevil
	
	List<string> availableHeroes = new List<string>();
	Dictionary<char, string> keyMap = new Dictionary<char, string>();
	
	private void Awake()
	{
		// Insert available hero first
		availableHeroes.Add ( "hulk" );
		availableHeroes.Add ( "superman" );
		availableHeroes.Add ( "batman" );
		availableHeroes.Add ( "thing" );
		availableHeroes.Add ( "iceman" );
		availableHeroes.Add ( "antman" );
		availableHeroes.Add ( "daredevil" );
		
		// Insert data for the key map
		keyMap.Add ( '2', "abc" );
		keyMap.Add ( '3', "def" );
		keyMap.Add ( '4', "ghi" );
		keyMap.Add ( '5', "jkl" );
		keyMap.Add ( '6', "mno" );
		keyMap.Add ( '7', "pqrs" );
		keyMap.Add ( '8', "tuv" );
		keyMap.Add ( '9', "wxyz" );
	}
	
	/// <summary>
	/// The summon code.
	/// </summary>
	private string summonCode = string.Empty;
	
	/// <summary>
	/// The answer.
	/// </summary>
	private string answer = string.Empty;
	
	private void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (Screen.width * 0.5F, Screen.height * 0.5F, 500, 500));
		summonCode = GUILayout.TextField ( summonCode, 10 );
		if ( GUILayout.Button ( "Summoning ... " ) )
		{
			try
			{
				answer = SummoningHero ( summonCode );
			}
			catch ( System.Exception e )
			{
				answer = "Error occured, please check your input again.";
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
	/// Filters the heroes.
	/// </summary>
	/// <param name='phoneNumbers'>
	/// Phone numbers.
	/// </param>
	/// <param name='potentialHeroes'>
	/// Potential heroes.
	/// </param>

	public List<string> FilterHeroes (string phoneNumbers, List<string> potentialHeroes)
	{
		List<string> heroClones = new List<string>( potentialHeroes );
		
		// Filter out the impossible hero first based on length
		foreach ( string hero in heroClones )
		{
			if ( hero.Length != phoneNumbers.Length )
			{
				potentialHeroes.Remove ( hero );
			}
		}
		
		return potentialHeroes;
	}
	
	/// <summary>
	/// Summonings the hero.
	/// </summary>
	/// <returns>
	/// The hero.
	/// </returns>
	/// <param name='phoneNumbers'>
	/// Phone numbers.
	/// </param>
	private string SummoningHero (string phoneNumbers)
	{
		List<string> potentialHeroes = new List<string> ( availableHeroes );
		
		string heroName = "You have summoned .... ";
		
		potentialHeroes = FilterHeroes (phoneNumbers, potentialHeroes);
		
		// Check for there hero
		// Get the first number
		for ( int i = 0; i < phoneNumbers.Length; i++ )
		{
			char a = phoneNumbers [ i ];
			
			potentialHeroes = GetPotentialHeroes ( a, i, potentialHeroes );
		}
		
		if ( potentialHeroes.Count == 0 )
		{
			heroName += "chicken?!?!";	
		}
		else
		{
			heroName += potentialHeroes [ 0 ] + "!";
		}
		
		return heroName;
	}
	
	/// <summary>
	/// Gets the potential heroes.
	/// </summary>
	/// <returns>
	/// The potential heroes.
	/// </returns>
	/// <param name='phoneNumber'>
	/// Phone number.
	/// </param>
	/// <param name='characterLoc'>
	/// Character location.
	/// </param>
	/// <param name='potentialHeroes'>
	/// Potential heroes.
	/// </param>
	private List<string> GetPotentialHeroes (char phoneNumber, int characterLoc, List<string> potentialHeroes)
	{
		List<string> heroClones = new List<string>( potentialHeroes );
		
		foreach ( string hero in heroClones )
		{
			if ( keyMap [ phoneNumber ].Contains ( hero [ characterLoc ].ToString() ) )
			{
				// Do nothing
			}
			else
			{
				potentialHeroes.Remove ( hero );
			}
		}
		
		return potentialHeroes;
	}
}
