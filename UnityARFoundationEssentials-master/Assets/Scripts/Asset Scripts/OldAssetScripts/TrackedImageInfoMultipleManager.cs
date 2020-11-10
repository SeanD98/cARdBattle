﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageInfoMultipleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject welcomePanel;

    [SerializeField]
    private Button dismissButton;

    [SerializeField]
    private Text imageTrackedText;

    [SerializeField]
    private GameObject[] arObjectsToPlace;

    [SerializeField]
    private Text arTappedText;

    bool firstTap = false;

    [SerializeField]
    //private Vector3 scaleFactor = new Vector3(0.1f,0.1f,0.1f);

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

    void Awake()
    {
        dismissButton.onClick.AddListener(Dismiss);
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();

        
        foreach (GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
            //newARObject.transform.Translate(1000, 1000, 1000);
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

    private void Dismiss() => welcomePanel.SetActive(false);

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
        imageTrackedText.text = trackedImage.referenceImage.name;
        AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position, trackedImage);

        Debug.Log($"trackedImage.referenceImage.name: {trackedImage.referenceImage.name}");
    }

    void AssignGameObject(string name, Vector3 newPosition, ARTrackedImage trackedImage)
    {
        if(arObjectsToPlace != null)
        {
            GameObject goARObject = arObjects[name];
            goARObject.SetActive(true);
            goARObject.transform.position = trackedImage.transform.position;
            //goARObject.transform.localScale = scaleFactor;
            Debug.Log("IMAGE ADDED 8");
            foreach (GameObject go in arObjects.Values)
            {
                Debug.Log($"Go in arObjects.Values: {go.name}");
                if(go.name != name)
                {
                    Debug.Log("IMAGE ADDED 9");
                }
            } 
        }
    }

    void Update()
    {
       /* if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var touchPosition = touch.position;

            if (touch.phase == TouchPhase.Stationary)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.transform.name == "AROne") 
                    {
                        SceneManager.LoadScene("MonsterBattleScene");
                    }
                    if (hitObject.transform.name == "ARTwo")
                    {
                        SceneManager.LoadScene("MonsterBattleScene");
                    }
                    if (hitObject.transform.name == "ARThree")
                    {
                        SceneManager.LoadScene("MonsterBattleScene");
                    }
                    if (hitObject.transform.name == "ARFour")
                    {
                        SceneManager.LoadScene("MonsterBattleScene");
                    }

                    if (hitObject.transform.name == "EnemyAROne")
                    {
                        arTappedText.text = "EnemyAROne tapped!";
                    }
                    if (hitObject.transform.name == "EnemyARTwo")
                    {
                        arTappedText.text = "EnemyARTwo tapped!";
                    }
                    if (hitObject.transform.name == "EnemyARThree")
                    {
                        arTappedText.text = "EnemyARThree tapped!";
                    }
                    if (hitObject.transform.name == "EnemyARFour")
                    {
                        arTappedText.text = "EnemyARFour tapped!";
                    }

                    if (hitObject.transform.name == "EnemyAROne" 
                        && hitObject.transform.name == "AROne")
                    {
                        arTappedText.text = "2 selected";
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
       */ }
    }
//}