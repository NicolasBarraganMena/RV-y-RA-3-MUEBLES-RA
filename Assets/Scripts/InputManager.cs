using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject arObject;
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //Si se da click izquierdo del mouse
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            if (raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                Instantiate(arObject, pose.position, pose.rotation);
            }
        }

    }
}
