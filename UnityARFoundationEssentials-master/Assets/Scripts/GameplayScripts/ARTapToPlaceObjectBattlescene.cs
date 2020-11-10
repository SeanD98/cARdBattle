using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObjectBattlescene : MonoBehaviour
{
    [SerializeField]
    public GameObject[] gameObjectsToInstantiate;

    private GameObject[] spawnedObject;
    private ARRaycastManager _arRaycastManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();
    int touchCounter;

    //Input Touches
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        var touch = Input.GetTouch(0);
        if (Input.touchCount > 0)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                touchPosition = Input.GetTouch(0).position;
                touchCounter++;
                return true;
            }
        }
        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.Planes))
        {
            if (touchCounter == 2)
            {
                var hitPose = hits[0].pose;
                spawnedObject[0] = Instantiate(gameObjectsToInstantiate[0], hitPose.position, hitPose.rotation);
            }
            else if (touchCounter == 3)
            {
                var hitPose = hits[0].pose;
                spawnedObject[1] = Instantiate(gameObjectsToInstantiate[1], hitPose.position, hitPose.rotation);
            }
        }
    }
}

