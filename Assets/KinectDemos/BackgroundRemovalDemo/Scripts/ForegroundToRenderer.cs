using UnityEngine;
using System.Collections;

public class ForegroundToRenderer : MonoBehaviour 
{
	private Renderer thisRenderer;

	void Start()
	{
		thisRenderer = GetComponent<Renderer>();

		KinectManager kinectManager = KinectManager.Instance;
		if (kinectManager && kinectManager.IsInitialized ()) 
		{
			Vector3 localScale = transform.localScale;
			localScale.z = localScale.x * kinectManager.GetColorImageHeight () / kinectManager.GetColorImageWidth ();
			localScale.x = -localScale.x;

			transform.localScale = localScale;
		}
	}


	void Update () 
	{
		BackgroundRemovalManager backManager = BackgroundRemovalManager.Instance;

		if(thisRenderer && backManager && backManager.IsBackgroundRemovalInitialized())
		{
			if(thisRenderer.sharedMaterial.mainTexture == null)
			{
				thisRenderer.sharedMaterial.mainTexture = backManager.GetForegroundTex();
			}
		}
	}

}
