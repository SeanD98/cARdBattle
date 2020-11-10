using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    [SerializeField]
    public GameObject[] gameObjectsToInstantiate;

    private GameObject[] spawnedObject;
    private ARRaycastManager _arRaycastManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();
    int touchCounter;

    [SerializeField]
    public string scenename;
    //Input Touches
    private Vector2 touchPosition;

    [SerializeField]
    public GameObject panel;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        Destroy(panel, 4);
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

            if (touch.phase == TouchPhase.Stationary)
            {
                LoadScene(scenename);
            }
        }
        touchPosition = default;
        return false;
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition)){
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
            else if (touchCounter == 4)
            {
                var hitPose = hits[0].pose;
                spawnedObject[2] = Instantiate(gameObjectsToInstantiate[2], hitPose.position, hitPose.rotation);
            }
            else if (touchCounter == 5)
            {
                var hitPose = hits[0].pose;
                spawnedObject[3] = Instantiate(gameObjectsToInstantiate[3], hitPose.position, hitPose.rotation);
            }
            else if (touchCounter == 6)
            {
                var hitPose = hits[0].pose;
                spawnedObject[4] = Instantiate(gameObjectsToInstantiate[4], hitPose.position, hitPose.rotation);
            }
            else if (touchCounter == 7)
            {
                var hitPose = hits[0].pose;
                spawnedObject[5] = Instantiate(gameObjectsToInstantiate[5], hitPose.position, hitPose.rotation);
            }
            else if (touchCounter == 8)
            {
                var hitPose = hits[0].pose;
                spawnedObject[6] = Instantiate(gameObjectsToInstantiate[6], hitPose.position, hitPose.rotation);
            }
            else if (touchCounter == 9)
            {
                var hitPose = hits[0].pose;
                spawnedObject[7] = Instantiate(gameObjectsToInstantiate[7], hitPose.position, hitPose.rotation);
            }
        }
    }
}
