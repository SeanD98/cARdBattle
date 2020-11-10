using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARFourOnClickMethod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public LayerMask touchableLayers;

    void Update()
    {
        var camera = Camera.main;

        int count = Input.touchCount;
        for (int i = 0; i < count; i++)
        {
            var touch = Input.GetTouch(i);

            var ray = camera.ScreenPointToRay(touch.position);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchableLayers))
            {
                // Pur the actions you want to perform to respond to the touch here.
                Debug.LogFormat("Object {0} got touched!", hit.collider.gameObject.name);
            }
        }
    }
}
