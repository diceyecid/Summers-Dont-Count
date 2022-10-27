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
		// Mouse click or Tap
		if( Input.GetMouseButtonDown( 0 ) )
		{
			// raycast a ray to detect model in AR
			List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
			raycastManager.Raycast( Input.mousePosition, hitPoints, TrackableType.AllTypes );

			if( hitPoints.Count > 0 )
			{
				// load piano interaction scene
				SceneManager.LoadScene( "PianoInteraction" );
			}
		}
    }
}
