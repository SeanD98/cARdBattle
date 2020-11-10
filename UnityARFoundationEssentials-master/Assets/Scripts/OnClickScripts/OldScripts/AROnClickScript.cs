using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]

public class AROnClickScript : MonoBehaviour
{
    [SerializeField]
    private Text modelClickedText;


    public LayerMask touchableLayers;

    string ModelName;
    private bool onTouchHold = false;

    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject placedPrefab;
    private GameObject placedObject;

    private Vector2 touchPostion = default;
    private Camera arCamera;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.transform.name.Contains("AROne"))
                    {
                        onTouchHold = true;
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
        }

        if (arRaycastManager.Raycast(touchPostion, hits, UnityEngine.XR.ARSubsystems.TrackableType.All)){
            Pose hitPose = hits[0].pose;

            if (onTouchHold)
            {
                placedObject.transform.position = hitPose.position;
                placedObject.transform.rotation = hitPose.rotation;
            }
        }
    }
}
