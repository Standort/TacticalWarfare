using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    private InputAction mouseClick;
    [SerializeField]
    private float mouseDragPhyscisSpeed = 10;
    [SerializeField]
    private float mouseDragSpeed = .1f;

    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    private Camera mainCamera;
    private Vector3 velocity = Vector3.zero;
    private bool Pressed = false;
    private float tileOfset = 1.0f;
    private GameObject tempor;
    public GameObject FindClosestTile(GameObject obj)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Tile");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - obj.transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        
        return closest;
    }
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }
    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }
    private void MousePressed(InputAction.CallbackContext context)
    {
       Ray ray =  mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null && (hit.collider.gameObject.CompareTag("Draggable") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable")))
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
                
            }
           

        }
    }
    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while (mouseClick.ReadValue<float>() != 0)
        {
            Pressed = true;
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if(rb != null)
            {
                Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position;
                rb.velocity = direction * mouseDragPhyscisSpeed;
                yield return waitForFixedUpdate;
            }
            else
            {
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, ray.GetPoint(initialDistance), ref velocity, mouseDragSpeed);
                yield return null;
            }
            tempor = FindClosestTile(clickedObject);
        }
        if(mouseClick.ReadValue<float>() == 0 && Pressed == true)
        {
            /*
            //this is where it snaps to the center of a square, tileOfset is the size of the square tiles I use 
            var newPosition = clickedObject.transform.position;
            newPosition.x = Mathf.Round(newPosition.x / tileOfset) * tileOfset;
            newPosition.y = 0;//Mathf.Round(newPosition.y / tileOfset) * tileOfset;
            newPosition.z = Mathf.Round(newPosition.z / tileOfset) * tileOfset;
            clickedObject.transform.position = newPosition; 
            */
            
            var newPosition = clickedObject.transform.position;
            newPosition.x = tempor.transform.position.x;
            newPosition.z = tempor.transform.position.z;
            clickedObject.transform.position = newPosition;
        }

    }
    

}