using UnityEngine;
using System.Collections;

namespace commanastationwww.eternaltemple{
public class DisableMeshAtRuntime : MonoBehaviour {

//This script disables object's renderer at runtime 

	// Use this for initialization
	void Start ()
	{		
		Renderer rendererComponent = GetComponent<Renderer>();
		
		if (rendererComponent != null)
			{
				rendererComponent.enabled = false;
			}			
	}		
}
}