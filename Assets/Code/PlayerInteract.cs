using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _maxDistanceRaycast = 3f;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _handTransform;

    private RaycastHit _hitInfo;
    private Item _item;
    private bool _isHandle = false;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
        DropIt();

    }

    private void DropIt()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && _isHandle)
        {
            _isHandle = false;
            _item.DropIt(_camera.transform.forward);
        }
    }

    private void Interact()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hitInfo, _maxDistanceRaycast))
            {
                if (_hitInfo.transform.TryGetComponent(out Door door))
                {
                    door.Interact();
                }
                if (_hitInfo.transform.TryGetComponent(out Item item) && !_isHandle)
                {
                    _item = item;
                    _item.Take(_handTransform);
                    _isHandle = true;
                }
            }
        }
    }
}
