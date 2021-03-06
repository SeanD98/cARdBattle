﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class GhostBattleSceneTrackedImageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] arObjectsToPlace;

    [SerializeField]
    private Text CornerText;

    bool firstTap = false;

    [SerializeField]
    //private Vector3 scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);

    private ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    public LayerMask touchableLayers;

    public GameObject lastSelectedObject;

    string ModelName;
    private bool onTouchHold = false;

    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject placedPrefab;
    private GameObject placedObject;

    private Vector2 touchPostion = default;
    private Camera arCamera;

    //public Vector2 touchPosition;

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
            newARObject.transform.Translate(1000, 1000, 1000);
        }
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            arObjects[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {
        AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);

        Debug.Log($"trackedImage.referenceImage.name: {trackedImage.referenceImage.name}");
    }

    void AssignGameObject(string name, Vector3 newPosition)
    {
        if (arObjectsToPlace != null)
        {
            GameObject goARObject = arObjects[name];
            goARObject.SetActive(true);

            foreach (GameObject arObject in arObjectsToPlace)
            {
                arObject.transform.position = newPosition;
                //goARObject.transform.localScale = scaleFactor;
            }
            foreach (GameObject go in arObjects.Values)
            {
                Debug.Log($"Go in arObjects.Values: {go.name}");
                if (go.name != name)
                {

                }
            }
        }
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
                    if (hitObject.transform.name == "CornerOne")
                    {
                        //Fight Button etc
                        CornerText.text = "Corner One Selected";
                    }
                    if (hitObject.transform.name == "CornerTwo")
                    {
                        //Display remaining health
                        CornerText.text = "Corner Two Selected";
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
        }

        if (arRaycastManager.Raycast(touchPostion, hits, UnityEngine.XR.ARSubsystems.TrackableType.All))
        {
            Pose hitPose = hits[0].pose;

            if (onTouchHold)
            {
                placedObject.transform.position = hitPose.position;
                placedObject.transform.rotation = hitPose.rotation;
            }
        }
    }
}
