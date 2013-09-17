using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinding : MonoBehaviour
{
	Dictionary<string, List<Node>> data;

	private void Awake ()
	{
		// Key in the example data in the first place
		data = new Dictionary<string, List<Node>> ();
        data.Add("A", Node.InitList("C,5;D,9"));
        data.Add("B", Node.InitList("F,5;D,7"));
        data.Add("C", Node.InitList("A,5;D,4;H,6;G,5.5;E,1"));
        data.Add("D", Node.InitList("A,9;C,4;B,7"));
        data.Add("E", Node.InitList("C,1;F,0.8"));
        data.Add("F", Node.InitList("G,4;E,0.8;B,5"));
        data.Add("G", Node.InitList("C,5.5;H,2;F,4"));
        data.Add("H", Node.InitList("G,2;C,6"));
	}

	List<TravelingNode> tNodes = new List<TravelingNode> ();
	List<string> traveledNodes = new List<string> ();

	private void CreateTravelNode (string start)
	{
		// Get start point connected nodes first
		List<Node> nodes;
		data.TryGetValue (start, out nodes);
		
		// Make sure we won't get duplicate node 
		if (!traveledNodes.Contains (start))
			traveledNodes.Add (start);
		
		foreach (Node node in nodes) {
			if (traveledNodes.Contains (node.nodeName)) {
				continue;
			}
			
			TravelingNode tNode = TravelingNode.Init (node.nodeName);
			tNode.path = start + node.nodeName;
			tNode.interation++;
			tNode.totalDistance += node.weight;
			tNodes.Add (tNode);
		}
	}

	// A to B shortest path
	private string GetShortestPath (string start, string destination)
	{
		CreateTravelNode (start);
        
		// Once it is done, travel using shortest path
		TravelingNode sdNode = GetShortDistanceNode (tNodes);
		return GetShortestPath (sdNode, destination);
	}
	
	private string GetShortestPath (TravelingNode tNode, string destination)
	{
		if (tNode == null) {
			return GetShortDistanceNode (tNodes, true).path;
		}
		
		// Get start point connected nodes first
		List<Node> nodes;
		data.TryGetValue (tNode.currentNode, out nodes);
	
		// Make sure we won't get duplicate node 
		if (!traveledNodes.Contains (tNode.currentNode))
			traveledNodes.Add (tNode.currentNode);
		
		// If inside there there is a distance data about this node, remove but remember to add in the weignt data
		for (int i = 0; i < tNodes.Count; i++) {
			if (tNodes [i] == tNode) {
				tNodes [i] = null;
			}
		}
		
		foreach (Node node in nodes) {
			if (traveledNodes.Contains (node.nodeName)) {
				continue;
			}

			TravelingNode newTNode = TravelingNode.Init (node.nodeName);
			newTNode.path = tNode.path + node.nodeName;
			newTNode.interation = tNode.interation + 1;
			newTNode.totalDistance += tNode.totalDistance + node.weight;
			
			if (node.nodeName == destination) {
				newTNode.isDone = true;
			}
			
			tNodes.Add (newTNode);
		}

		// Once it is done, travel using shortest path
		TravelingNode sdNode = GetShortDistanceNode (tNodes);
		
		return GetShortestPath (sdNode, destination);
	}

	/// <summary>
	/// Gets the distance node.
	/// </summary>
	/// <param name='tNodes'>
	/// T nodes.
	/// </param>
	/// <param name='includeDoneAsWell'>
	/// Include done as well.
	/// </param>

	private TravelingNode GetDistanceNode (List<TravelingNode> tNodes, bool includeDoneAsWell)
	{
		float distanceValue = Mathf.Infinity;
		TravelingNode chooseNode = null;
    	
		foreach (TravelingNode tNode in tNodes) {
			if (tNode == null) {
				continue;
			}
			if (includeDoneAsWell == false) {
				if (tNode.isDone == true) {
					continue;
				}
			}
			
			if (tNode.totalDistance <= distanceValue) {
				if (tNode.totalDistance < distanceValue) {
					distanceValue = tNode.totalDistance;
					chooseNode = tNode;
				} else if (tNode.totalDistance == distanceValue) {
					if (chooseNode.interation > tNode.interation) {
						chooseNode = tNode;
					} else {
						chooseNode = tNode;
					}
				}
			}
		}
		return chooseNode;
	}

	private TravelingNode GetShortDistanceNode (List<TravelingNode> tNodes, bool includeDoneAsWell = false)
	{
		return GetDistanceNode (tNodes, includeDoneAsWell);
	}

	private string GetLongestPath (string start, string destination)
	{
		throw new System.NotImplementedException ();
	}
	
	private void Start ()
	{
		Debug.Log (GetShortestPath ("A", "B"));
		Debug.Log (GetLongestPath ("A", "B"));
	}

	private void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (Screen.width * 0.5F, Screen.height * 0.5F, 500, 500));
		//GUILayout.Label(GetShortestPath("A", "B"));
		GUILayout.EndArea ();
	}
}

[System.Serializable]
public class Node
{
	public string nodeName;
	public float weight = 0.0F;

	static public Node Init (string nodeName, float weight)
	{
		Node node = new Node ();
		node.nodeName = nodeName;
		node.weight = weight;

		return node;
	}

	static public List<Node> InitList (string rawData)
	{
		string[] processData = rawData.Split (';');

		List<Node> nodeList = new List<Node> ();
		foreach (string cookData in processData) {
			string[] finalData = cookData.Split (',');
			nodeList.Add (Node.Init (finalData [0], float.Parse (finalData [1])));
		}

		return nodeList;
	}

	public Node Clone ()
	{
		Node newNode = new Node ();
		newNode.nodeName = this.nodeName;
		newNode.weight = this.weight;

		return newNode;
	}
}

[System.Serializable]
public class TravelingNode
{
	public string path;
	public string currentNode;
	public float totalDistance;
	public int interation;
	public bool isDone = false;

	static public TravelingNode Init (string currentNode)
	{
		TravelingNode node = new TravelingNode ();
		node.currentNode = currentNode;
		node.totalDistance = 0.0F;
		node.interation = 0;

		return node;
	}
}