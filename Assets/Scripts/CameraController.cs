using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed, speed, zoomSpeed;
    private float _mult=1f;
    private void Awake() {
        rotateSpeed = 20f;
        speed = 20f;
        zoomSpeed  = 200f;
     }
    private void Update() {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        float rotate=0f;

        if(Input.GetKey(KeyCode.Q))
            rotate = -1f;
        if(Input.GetKey(KeyCode.E))
            rotate = 1f;
        _mult=Input.GetKey(KeyCode.LeftShift) ? 4f : 1f;
        transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime*_mult *rotate, Space.World);
        transform.Translate(new Vector3(hor, 0, ver)*Time.deltaTime*_mult*speed, Space.Self);
        transform.position += transform.up * zoomSpeed*_mult*Time.deltaTime*Input.GetAxis("Mouse ScrollWheel");
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -20f,50f),
            transform.position.z
        );
    }
}
