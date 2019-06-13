using UnityEngine;
using System.Collections;

/// <summary>
/// Background color image is component that displays the color camera feed on GUI texture, usually the scene background.
/// </summary>
public class BackgroundColorImage : MonoBehaviour 
{
	[Tooltip("GUI-texture used to display the color camera feed.")]
	public GUITexture backgroundImage;


	void Update () 
	{
		KinectManager manager = KinectManager.Instance;

		if (manager && manager.IsInitialized()) 
		{
			if (backgroundImage && (backgroundImage.texture == null)) 
			{
				backgroundImage.texture = manager.GetUsersClrTex();
			}
		}	
	}
}
