using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableManager : MonoBehaviour
{
	[SerializeField]
	ARRaycastManager m_RaycastManager;
	List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
	
	[SerializeField]
	GameObject spawnablePrefab;

	Camera arCam;
	GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
		spawnedObject = null;
		arCam = GameObject.Find( "AR Camera" ).GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
		if( Input.touchCount == 0 )
			return;

		// check if ray has hit a plane
		if( m_RaycastManager.Raycast( Input.GetTouch( 0 ).position, m_Hits ) )
		{
			// check if phase is set to Began and there are no spawnedObject
			if( Input.GetTouch( 0 ).phase == TouchPhase.Began && spawnedObject == null )
			{
				Ray ray = new Ray( transform.position, transform.forward );
				RaycastHit hit;

				if( Physics.Raycast( ray, out hit ) )
				{
					if( hit.collider.gameObject.tag == "Spawnable" )
					{
						spawnedObject = hit.collider.gameObject;
					}
					else
					{
						SpawnPrefab( m_Hits[0].pose.position );
					}
				}
			}

			// check if phase is set to Moved and there is spawnedObject
			else if( Input.GetTouch( 0 ).phase == TouchPhase.Moved && spawnedObject != null )
			{
				// move to touch location
				spawnedObject.transform.position = m_Hits[0].pose.position;
			}
			
			// check if phase is set to Ended
			if( Input.GetTouch( 0 ).phase == TouchPhase.Ended )
			{
				spawnedObject = null;
			}
		}
    }

	private void SpawnPrefab( Vector3 spawnPosition )
	{
		spawnedObject = Instantiate( spawnablePrefab, spawnPosition, Quaternion.identity );
	}
}
