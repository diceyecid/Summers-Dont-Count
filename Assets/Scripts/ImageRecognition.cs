using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognition : MonoBehaviour
{
	[SerializeField]
	private GameObject[] placeablePrefabs;
	private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
	private ARTrackedImageManager trackedImageManager;

	private void Awake()
	{
		trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

		foreach( GameObject prefab in placeablePrefabs )
		{
			GameObject newPrefab = Instantiate( prefab, Vector3.zero, Quaternion.identity );
			newPrefab.name = prefab.name;
			newPrefab.SetActive( false );
			spawnedPrefabs.Add( prefab.name, newPrefab );
		}
	}

	private void OnEnable()
	{
		trackedImageManager.trackedImagesChanged += OnImageChanged;
	}

	private void OnDisable()
	{
		trackedImageManager.trackedImagesChanged -= OnImageChanged;
	}

	private void OnImageChanged( ARTrackedImagesChangedEventArgs args )
	{
		foreach( ARTrackedImage trackedImage in args.added )
		{
			UpdateImage( trackedImage );
		}

		foreach( ARTrackedImage trackedImage in args.updated )
		{
			UpdateImage( trackedImage );
		}
		
		foreach( ARTrackedImage trackedImage in args.removed )
		{
			spawnedPrefabs[ trackedImage.name ].SetActive( false );
		}
	}

	private void UpdateImage( ARTrackedImage trackedImage )
	{
		string name = trackedImage.referenceImage.name;
		Vector3 position = trackedImage.transform.position;
		Quaternion rotation = trackedImage.transform.rotation;

		GameObject prefab = spawnedPrefabs[ name ];
		prefab.transform.position = position;
		prefab.transform.rotation = rotation;
		prefab.SetActive( true );

		foreach( GameObject go in spawnedPrefabs.Values )
		{
			if( go.name != name )
			{
				go.SetActive( false );
			}
		}
	}
}
