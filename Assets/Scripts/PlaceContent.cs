using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceContent : MonoBehaviour
{
	public ARRaycastManager raycastManager;
	public GraphicRaycaster raycaster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if( Input.GetMouseButtonDown( 0 ) )
		{
			List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
			raycastManager.Raycast( Input.mousePosition, hitPoints, TrackableType.Planes );

			if( hitPoints.Count > 0 )
			{
				Pose pose = hitPoints[0].pose;
				transform.rotation = pose.rotation;
				transform.position = pose.position;
			}
		}
    }
}
