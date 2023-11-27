using UnityEngine;
using System.Collections;

namespace commanastationwww.eternaltemple{
public class HideGroup : MonoBehaviour {
	
	//This script is to be assigned to an object which contains other objects as it's children with "HidablePart" script assigned to them.
	//Script will find children with "HidablePart" and send them a command to hide or unhide when camera's trigger-collider enters this objects trigger-collider
	//Camera has to be tagged as MainCamera and contain a collider component with "isTrigger" turned on
	
	public bool hidable = true; //if set to false, objects will not hide themself from camera
	
	public bool disableParentGeo = true;	//if set to true, it allows to keep this objects geometry visible in editor and hidden at runtime
	
	private int collisionEntriesCounter;	//counter of entries and exits to the trigger. Allows to have multiple triggers (colliders)
	private HidablePart[] hidableGroup; //array to store hidable geo children of this object
	private ParticleSystem[] particlesGroup;	//array to store particle children of this object
	private Renderer rendererComponent; //stores renderer component of this object

    void Start()
		{	
			collisionEntriesCounter = 0;
			
			//Get and store children
			hidableGroup = gameObject.GetComponentsInChildren<HidablePart>();	
			particlesGroup = GetComponentsInChildren<ParticleSystem>();			
			
			//Hide geometry of this object if disableParentGeo is true
			if (disableParentGeo)
			{
				rendererComponent = GetComponent<Renderer>();
				
				if (rendererComponent != null)
					{
						rendererComponent.enabled = false;
					}	
			}
		}
			
	//send "hide" command to children when camera collider enters trigger. Camera has to be tagged as MainCamera
	void OnTriggerEnter(Collider other)
		{	
			if (hidable == false) return;
			if (other.gameObject.tag == "MainCamera")
				{	
					collisionEntriesCounter++;	
					
					foreach (HidablePart part in hidableGroup)
					part.hide();
					
					foreach (ParticleSystem particleChild in particlesGroup)
					particleChild.Stop();
				}		
		}
	
	//send "unhide" command to children when camera collider exits trigger
	void OnTriggerExit(Collider other)
		{			
			if (hidable == false) return;
			if (other.gameObject.tag == "MainCamera")
			{
				collisionEntriesCounter--;
			
					if (collisionEntriesCounter > 0)
						{
							return;
						}			
							
					foreach (HidablePart part in hidableGroup)
					part.unhide();

					foreach (ParticleSystem particleChild in particlesGroup)
					particleChild.Play();		
					
					collisionEntriesCounter = 0;								
			}
		}
		
			void Update () {
				
		}

}
}

