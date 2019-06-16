using UnityEngine;
using System.Collections;
using System;
//using Windows.Kinect;

public class CubeGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	[Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
	public int playerIndex = 0;
    private GUIStyle titleStyle = new GUIStyle();
    [Tooltip("GUI-Text to display gesture-listener messages and gesture information.")]
    public GUIText gestureInfo;
    // singleton instance of the class
    private static CubeGestureListener instance = null;

	// internal variables to track if progress message has been displayed
	private bool progressDisplayed;
	private float progressGestureTime;
    private string sGestureText = "not detected any motion";

    // whether the needed gesture has been detected or not
    private bool swipeLeft;
	private bool swipeRight;
	private bool swipeUp;
    private bool RaiseLeftHand;
    private bool RaiseRightHand;
    private bool Tpose;
    private bool LeanLeft;
    private bool LeanRight
        ;
    /// <summary>
    /// Gets the singleton CubeGestureListener instance.
    /// </summary>
    /// <value>The CubeGestureListener instance.</value>
    public static CubeGestureListener Instance
	{
		get
		{
			return instance;
		}
	}
	
	/// <summary>
	/// Determines whether swipe left is detected.
	/// </summary>
	/// <returns><c>true</c> if swipe left is detected; otherwise, <c>false</c>.</returns>
	public bool IsSwipeLeft()
	{
		if(swipeLeft)
		{
			swipeLeft = false;
			return true;
		}
		
		return false;
	}

	/// <summary>
	/// Determines whether swipe right is detected.
	/// </summary>
	/// <returns><c>true</c> if swipe right is detected; otherwise, <c>false</c>.</returns>
	public bool IsSwipeRight()
	{
		if(swipeRight)
		{
			swipeRight = false;
			return true;
		}
		
		return false;
	}

    void Start()
    {
      
        titleStyle.fontSize = 50;
        titleStyle.normal.textColor = new Color(100, 100, 100);
    }

    /// <summary>
    /// Determines whether swipe up is detected.
    /// </summary>
    /// <returns><c>true</c> if swipe up is detected; otherwise, <c>false</c>.</returns>
    public bool IsSwipeUp()
	{
		if(swipeUp)
		{
			swipeUp = false;
            LeanRight = false;
            LeanLeft = false;
            Tpose = false;
            return true;
		}
		
		return false;
	}


    public bool IsRaiseLeftHandp()
    {
        if (RaiseLeftHand)
        {
            RaiseRightHand = false;
            return true;
        }

        return false;
    }
    public bool IsRaiseRightHand()
    {
        if (RaiseRightHand)
        {
            RaiseLeftHand = false;
            return true;
        }

        return false;
    }

    public bool IsTpose()
    {
        if (Tpose)
        {
            return true;
        }

        return false;
    }


    public bool IsLeanLeft()
    {
        if (LeanLeft)
        {
            return true;
        }

        return false;
    }


    public bool IsLeanRight()
    {
        if (LeanRight)
        {
            return true;
        }

        return false;
    }




    /// <summary>
    /// Invoked when a new user is detected. Here you can start gesture tracking by invoking KinectManager.DetectGesture()-function.
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="userIndex">User index</param>
    public void UserDetected(long userId, int userIndex)
	{
		// the gestures are allowed for the primary user only
		KinectManager manager = KinectManager.Instance;
		if(!manager || (userIndex != playerIndex))
			return;
		
		// detect these user specific gestures
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
        manager.DetectGesture(userId, KinectGestures.Gestures.Tpose);
        manager.DetectGesture(userId, KinectGestures.Gestures.LeanLeft);
        manager.DetectGesture(userId, KinectGestures.Gestures.LeanRight);
        manager.DetectGesture(userId, KinectGestures.Gestures.Stop);


	    sGestureText = "change the slides.";
		
	}

	/// <summary>
	/// Invoked when a user gets lost. All tracked gestures for this user are cleared automatically.
	/// </summary>
	/// <param name="userId">User ID</param>
	/// <param name="userIndex">User index</param>
	public void UserLost(long userId, int userIndex)
	{
		// the gestures are allowed for the primary user only
		if(userIndex != playerIndex)
			return;


        sGestureText = string.Empty;
		
	}

	/// <summary>
	/// Invoked when a gesture is in progress.
	/// </summary>
	/// <param name="userId">User ID</param>
	/// <param name="userIndex">User index</param>
	/// <param name="gesture">Gesture type</param>
	/// <param name="progress">Gesture progress [0..1]</param>
	/// <param name="joint">Joint type</param>
	/// <param name="screenPos">Normalized viewport position</param>
	public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectInterop.JointType joint, Vector3 screenPos)
	{
        // the gestures are allowed for the primary user only



        if (userIndex != playerIndex)
			return;

		if((gesture == KinectGestures.Gestures.ZoomOut || gesture == KinectGestures.Gestures.ZoomIn) && progress > 0.5f)
		{
			if(gestureInfo != null)
			{
			    sGestureText = string.Format ("{0} - {1:F0}%", gesture, screenPos.z * 100f);
				gestureInfo.text = sGestureText;
				
				progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
		else if((gesture == KinectGestures.Gestures.Wheel || gesture == KinectGestures.Gestures.LeanLeft || 
		         gesture == KinectGestures.Gestures.LeanRight) && progress > 0.5f)
		{
			if(gestureInfo != null)
			{
				sGestureText = string.Format ("{0} - {1:F0} degrees", gesture, screenPos.z);
				gestureInfo.text = sGestureText;

                if (gesture == KinectGestures.Gestures.LeanLeft)
                {
                    LeanLeft = true;
                } else
                {
                    LeanLeft = false;
                }
                    
                if (gesture == KinectGestures.Gestures.LeanRight)
                {
                    LeanRight = true;
                }else
                {
                    LeanRight = false;
                }


                progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
		else if(gesture == KinectGestures.Gestures.Run && progress > 0.5f)
		{
			if(gestureInfo != null)
			{
				sGestureText = string.Format ("{0} - progress: {1:F0}%", gesture, progress * 100);
				gestureInfo.text = sGestureText;
				
				progressDisplayed = true;
				progressGestureTime = Time.realtimeSinceStartup;
			}
		}
	}

	/// <summary>
	/// Invoked if a gesture is completed.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="userId">User ID</param>
	/// <param name="userIndex">User index</param>
	/// <param name="gesture">Gesture type</param>
	/// <param name="joint">Joint type</param>
	/// <param name="screenPos">Normalized viewport position</param>
	public bool GestureCompleted (long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint, Vector3 screenPos)
	{
		// the gestures are allowed for the primary user only
		if(userIndex != playerIndex)
			return false;

        sGestureText = gesture + " detected";
        Debug.Log( sGestureText);
        

        if (gesture == KinectGestures.Gestures.SwipeLeft)
			swipeLeft = true;
		if(gesture == KinectGestures.Gestures.SwipeRight)
			swipeRight = true;
	    if(gesture == KinectGestures.Gestures.SwipeUp)
			swipeUp = true;
        if(gesture == KinectGestures.Gestures.RaiseLeftHand)
            RaiseLeftHand = true;
        if (gesture == KinectGestures.Gestures.RaiseRightHand)
            RaiseRightHand = true;
        if (gesture == KinectGestures.Gestures.Tpose)
        {
            Tpose = true;
        }

        else
        {
            Tpose = false;
        }
        return true;
	}

	/// <summary>
	/// Invoked if a gesture is cancelled.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="userId">User ID</param>
	/// <param name="userIndex">User index</param>
	/// <param name="gesture">Gesture type</param>
	/// <param name="joint">Joint type</param>
	public bool GestureCancelled (long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint)
	{
		// the gestures are allowed for the primary user only
		if(userIndex != playerIndex)
			return false;
		
		if(progressDisplayed)
		{
			progressDisplayed = false;
			
			if(gestureInfo != null)
			{
				gestureInfo.text = String.Empty;
			}
		}
		
		return true;
	}

	
	void Awake()
	{
		instance = this;
	}

	void Update()
	{
		if(progressDisplayed && ((Time.realtimeSinceStartup - progressGestureTime) > 2f))
		{
			progressDisplayed = false;
			gestureInfo.text = String.Empty;

            Debug.Log("Forced progress to end.");
		}
	}


    private void OnGUI()
    {

        GUIStyle fontStyle = new GUIStyle();
        fontStyle.normal.background = null;    //…Ë÷√±≥æ∞ÃÓ≥‰
        fontStyle.normal.textColor = new Color(1, 0, 0);   //…Ë÷√◊÷ÃÂ—’…´
        fontStyle.fontSize = 100;       //◊÷
        GUI.Label(new Rect(10, 600, 300, 80), sGestureText, titleStyle);
    }
}
