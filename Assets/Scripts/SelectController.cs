using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SelectController : MonoBehaviour
{
    public GameObject cube;
    public LayerMask layer;
    private Camera _cam;
    private RaycastHit _hit;
    private GameObject _cubeSelection;

    private void Awake() {
        _cam = GetComponent<Camera>();
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
           

            if(Physics.Raycast(ray, out _hit, 1000f,layer ))
                _cubeSelection =Instantiate(cube, new Vector3(_hit.point.x, 1,_hit.point.z), Quaternion.identity);
        }
        if(_cubeSelection){
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out RaycastHit hitDrag, 1000f,layer ));
                _cubeSelection.transform.localScale = new Vector3((_hit.point.x-hitDrag.point.x)*-1,1,_hit.point.z - hitDrag.point.z);
        }

        if(Input.GetMouseButtonUp(0) && _cubeSelection)
            Destroy(_cubeSelection);
        

    }
}
