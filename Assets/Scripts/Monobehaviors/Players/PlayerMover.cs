using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _sensetiveX;
    [SerializeField] private float _sensetiveY; 
    
    private float _horizontalInput;
    private float _verticalInput;

    private float _horizontalMouse;
    private float _verticalMouse;

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        _horizontalMouse = Input.GetAxis("Mouse X");
        _verticalMouse = Input.GetAxis("Mouse Y");
        
        transform.Rotate(Vector3.up * _horizontalMouse * _sensetiveX);
        _camera.transform.Rotate(Vector3.left * _verticalMouse * _sensetiveY);
        
        transform.position += 
            (transform.forward * _verticalInput + transform.right * _horizontalInput).normalized * _speed * Time.deltaTime;
    }
}
