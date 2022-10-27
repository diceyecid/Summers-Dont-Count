using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent( typeof( ARRaycastManager ) ) ]
public class ChangeToPianoScene : MonoBehaviour
{
	public ARRaycastManager raycastManager;

    void Awake()
    {
		raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if( Input.GetMouseButtonDown( 0 ) )
		{
			List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
			raycastManager.Raycast( Input.mousePosition, hitPoints, TrackableType.AllTypes );

			if( hitPoints.Count > 0 )
			{
				SceneManager.LoadScene( "PianoInteraction" );
			}
		}

		//if( Input.GetMouseButtonDown( 0 ) )
		//{
			//RaycastHit hit;
			//Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			//if( Physics.Raycast( ray, out hit ) )
			//{
				//if( hit.transform.name == gameObject.transform.name )
				//{
					//Debug.Log( hit.transform.name );
					//SceneManager.LoadScene( "Scenes/PianoInteraction" );
				//}
			//}
		//}
    }
}
