using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{
	private ARTrackedImageManager trackedImageManager;

	private void Awake()
	{
		trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
	}

	public void OnEnable()
	{
		trackedImageManager.trackedImagesChanged += OnImageChanged;
	}

	public void OnDisable()
	{
		trackedImageManager.trackedImagesChanged -= OnImageChanged;
	}

	public void OnImageChanged( ARTrackedImagesChangedEventArgs args )
	{
		foreach( var trackedImage in args.added )
		{
			Debug.Log( trackedImage.name );
		}
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
