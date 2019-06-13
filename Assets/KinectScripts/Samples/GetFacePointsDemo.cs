#if !(UNITY_WSA_10_0 && NETFX_CORE)
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Kinect.Face;


public class GetFacePointsDemo : MonoBehaviour 
{
	[Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
	public int playerIndex = 0;

	[Tooltip("Tracked face point.")]
	public HighDetailFacePoints facePoint = HighDetailFacePoints.NoseTip;

	[Tooltip("Transform used to show the selected face point in space.")]
	public Transform facePointTransform;
	
	[Tooltip("GUI-Text to display face-information messages.")]
	public GUIText faceInfoText;

	private KinectManager manager = null;
	private FacetrackingManager faceManager = null;
	//private Kinect2Interface k2interface = null;

	private Vector3[] faceVertices;
	private Dictionary<HighDetailFacePoints, Vector3> dictFacePoints = new Dictionary<HighDetailFacePoints, Vector3> ();


	// returns the face point coordinates or Vector3.zero if not found
	public Vector3 GetFacePoint(HighDetailFacePoints pointType)
	{
		if(dictFacePoints != null && dictFacePoints.ContainsKey(pointType))
		{
			return dictFacePoints[pointType];
		}

		return Vector3.zero;
	}


	void Update () 
	{
		if (!manager) 
		{
			manager = KinectManager.Instance;
		}

		if (!faceManager) 
		{
			faceManager = FacetrackingManager.Instance;
		}

//		// get reference to the Kinect2Interface
//		if(k2interface == null)
//		{
//			manager = KinectManager.Instance;
//			
//			if(manager && manager.IsInitialized())
//			{
//				KinectInterop.SensorData sensorData = manager.GetSensorData();
//				
//				if(sensorData != null && sensorData.sensorInterface != null)
//				{
//					k2interface = (Kinect2Interface)sensorData.sensorInterface;
//				}
//			}
//		}

		// get the face points
		if(manager != null && manager.IsInitialized() && faceManager && faceManager.IsFaceTrackingInitialized())
		{
			long userId = manager.GetUserIdByIndex(playerIndex);
			
			if (faceVertices == null) 
			{
				int iVertCount = faceManager.GetUserFaceVertexCount(userId);

				if (iVertCount > 0) 
				{
					faceVertices = new Vector3[iVertCount];
				}
			}

			if (faceVertices != null) 
			{
				if (faceManager.GetUserFaceVertices(userId, ref faceVertices)) 
				{
					Matrix4x4 kinectToWorld = manager.GetKinectToWorldMatrix();
					HighDetailFacePoints[] facePoints = (HighDetailFacePoints[])System.Enum.GetValues(typeof(HighDetailFacePoints));

					for (int i = 0; i < facePoints.Length; i++) 
					{
						HighDetailFacePoints point = facePoints[i];
						dictFacePoints[point] = kinectToWorld.MultiplyPoint3x4(faceVertices[(int)point]);
					}
				}
			}

		}

		if(faceVertices != null && faceVertices[(int)facePoint] != Vector3.zero)
		{
			Vector3 facePointPos = faceVertices [(int)facePoint];

			if (facePointTransform) 
			{
				facePointTransform.position = facePointPos;
			}

			if(faceInfoText)
			{
				string sStatus = string.Format("{0}: {1}", facePoint, facePointPos);
				faceInfoText.text = sStatus;
			}
		}

	}


}
#endif
