using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Camera _camera;

    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _rotateSpeed = 300f;

    private Vector2 _rotation;
    
    private Transform _motorObject;
    private Vector3 _newMoveDirection;
    private Vector2 _direction;
    private Vector3 _velocity;
    private float _yRotation;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _camera = Camera.main;

        _motorObject = transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _direction*= _speed;

        Vector3 move = Quaternion.Euler(0,_camera.transform.eulerAngles.y,0) * new Vector3(_direction.x,0,_direction.y);
        _velocity = new Vector3(move.x, _velocity.y, move.z);
        _controller.Move(_velocity * Time.deltaTime);
    }
    private void Rotation()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        mouseDelta *= _rotateSpeed * Time.deltaTime;

        _yRotation -= mouseDelta.y;
        _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

        _camera.transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
        _motorObject.Rotate(Vector3.up * mouseDelta.x);
    }
}
