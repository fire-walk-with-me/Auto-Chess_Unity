using UnityEngine;
using System.Collections;

namespace commanastationwww.eternaltemple{
public class HideSelf : MonoBehaviour {
	
	//This script is to be assigned to an individual object that needs to be hidden.
	//If you need to hide several objects as one piece, please use "HideGroup" and "HidablePart" scripts.
	
	private int collisionEntriesCounter = 0;	//counter of entries and exits to the trigger. Allows to have multiple triggers (colliders)

	private Material mat;
	private float currentAlpha;	
	
	public bool hidable = true;
	public float hidingSpeed = 3f;
	public float minAlpha = 0f;
	public float maxAlpha = 1f;

		
	void Start () {
		
	mat = GetComponent<Renderer>().material;
	currentAlpha = mat.GetFloat("_Cutoff");
	
	}
	
	//A coroutine that unhides object (changes "alpha cutoff" value of the material)
	IEnumerator unideInterpolation()
	{				
		
		while (currentAlpha > minAlpha)
			{
				currentAlpha -= hidingSpeed * Time.deltaTime;					
				mat.SetFloat("_Cutoff", currentAlpha);				
				yield return null;
			}
				
	}
	
	//A coroutine that hides object 
	IEnumerator hideInterpolation()
	{		
					
		while (currentAlpha < maxAlpha)
			{
				currentAlpha += hidingSpeed * Time.deltaTime;				
				mat.SetFloat("_Cutoff", currentAlpha);				
				yield return null;
			}	
					
	}
	
			
	void OnTriggerEnter(Collider other)
		{	
			if (hidable == false) return;
			
			if (other.gameObject.tag == "MainCamera")
				collisionEntriesCounter++;	
				StopAllCoroutines();
				StartCoroutine (hideInterpolation());	
		}
				
	void OnTriggerExit(Collider other)
		{				
			if (hidable == false) return;
			
			if (other.gameObject.tag == "MainCamera")
				collisionEntriesCounter--;
			
			if (collisionEntriesCounter > 0)
						{
							return;
						}	
						
				StopAllCoroutines();	
				StartCoroutine (unideInterpolation());
				
				collisionEntriesCounter = 0;					
		}
				
			void Update () {
		}

}
}

