using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DragAndDrop : MonoBehaviour
{
   // 157 
    IGCManager igcManager;
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
    public GameObject tile;
    public Material Material1;
    public Material Material2;
    GameObject previousClosest;
    GameObject currentTile;
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
        
        closest.GetComponent<MeshRenderer>().material = Material1;
        print(closest.gameObject.name);
        print(closest.GetComponent<BenchTileScript>().occupied);
        return closest;
    }
    private void changeColorBack(GameObject t)
    {
        t.GetComponent<MeshRenderer>().material = Material2;
      
    }
    private void Awake()
    {
       
        mainCamera = Camera.main;
    }
    private void Start()
    {
      
        previousClosest = tempor;
       // int x = BenchMaker.firstAvailable();
        //print(x);
        //if (x != 0)
        //{
        //    currentTile = BenchMaker.BenchTiles[x -1];
        //} 
       
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
            if(!(hit.collider.gameObject.layer == LayerMask.NameToLayer("UI"))) 
            if (hit.collider != null && hit.collider.gameObject.GetComponentInParent<IGState>().isDraggable  )//((hit.collider.gameObject.CompareTag("Draggable") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable"))))
            {
                currentTile = FindClosestTile(hit.collider.gameObject);
                StartCoroutine(DragUpdate(hit.collider.gameObject));
                
            }
           

        }
    }
    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        clickedObject = clickedObject.transform.parent.gameObject;
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
            if(previousClosest == null)
            {
                changeColorBack(tempor);
                previousClosest = tempor;
            }
           else if(previousClosest != tempor)
            {
                print("new");
               
                changeColorBack(previousClosest);
                previousClosest = tempor;

            }
           
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
            if (tempor.GetComponent<BenchTileScript>().occupied == false)
            {
              //  print(tempor.GetComponent<BenchTileScript>().occupied);
                if(tempor != currentTile)
                {
                    currentTile.GetComponent<BenchTileScript>().occupied = false;
                }
                var newPosition = clickedObject.transform.position;
                newPosition.x = tempor.transform.position.x;
                newPosition.z = tempor.transform.position.z;
                newPosition.y = tempor.transform.position.y;
                clickedObject.transform.position = newPosition;
                //clickedObject
               
                changeColorBack(tempor);
                currentTile = tempor;
                tempor.GetComponent<BenchTileScript>().occupied = true;
                clickedObject.GetComponent<IGChampion>().GetTile(tempor);
            }
            else
            {
                var newPosition = clickedObject.transform.position;
                newPosition.x = currentTile.transform.position.x;
                newPosition.z = currentTile.transform.position.z;
                newPosition.y = currentTile.transform.position.y;
                clickedObject.transform.position = newPosition;
                changeColorBack(tempor);
                currentTile = tempor;
                
                tempor.GetComponent<BenchTileScript>().occupied = true;
                clickedObject.GetComponent<IGChampion>().GetTile(tempor);
            }
           // print(clickedObject.name);
       
          
        }
       

    }
    

}