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
		availableHeroes.Add ( "hulk" );
		availableHeroes.Add ( "superman" );
		availableHeroes.Add ( "batman" );
		availableHeroes.Add ( "thing" );
		availableHeroes.Add ( "iceman" );
		availableHeroes.Add ( "antman" );
		availableHeroes.Add ( "daredevil" );
		
		keyMap.Add ( '2', "abc" );
		keyMap.Add ( '3', "def" );
		keyMap.Add ( '4', "ghi" );
		keyMap.Add ( '5', "jkl" );
		keyMap.Add ( '6', "mno" );
		keyMap.Add ( '7', "pqrs" );
		keyMap.Add ( '8', "tuv" );
		keyMap.Add ( '9', "wxyz" );
	}
	
	private void Start()
	{
		Debug.Log ( SummoningHero ( "4855" ) );
		Debug.Log ( SummoningHero ( "84464" ) );
		Debug.Log ( SummoningHero ( "234234234" ) );
	}
	
	string summonCode = string.Empty;
	string answer = string.Empty;
	
	private void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (Screen.width * 0.5F, Screen.height * 0.5F, 500, 500));
		summonCode = GUILayout.TextField ( summonCode, 10 );
		if ( GUILayout.Button ( "Summoning ... " ) )
		{
			answer = SummoningHero ( summonCode );
		}
		GUILayout.Label ( answer );
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
		List<string> markedHeroes = new List<string>();
		
		// Filter out the impossible hero first based on length
		foreach ( string hero in potentialHeroes )
		{
			if ( hero.Length != phoneNumbers.Length )
			{
				markedHeroes.Add ( hero );
			}
		}
		
		foreach ( string hero in markedHeroes )
		{
			if ( potentialHeroes.Contains ( hero ) )
			{
				potentialHeroes.Remove ( hero );
			}
		}
		
		return potentialHeroes;
	}

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

	private List<string> GetPotentialHeroes (char phoneNumber, int characterLoc, List<string> potentialHeroes)
	{
		List<string> markedHeroes = new List<string>();
		
		foreach ( string hero in potentialHeroes )
		{
			if ( keyMap [ phoneNumber ].Contains ( hero [ characterLoc ].ToString() ) )
			{
				// Do nothing
			}
			else
			{
				markedHeroes.Add ( hero );
			}
		}
		
		foreach ( string hero in markedHeroes )
		{
			if (potentialHeroes.Contains ( hero ) )
				potentialHeroes.Remove( hero );
		}
		
		return potentialHeroes;
	}
}
