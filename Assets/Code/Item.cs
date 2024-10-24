using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forseDrop = 40;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Take(Transform handTransform)
    {
        transform.SetParent(handTransform);
        transform.position = handTransform.position;
        rb.isKinematic = true;
    }
    public void DropIt(Vector3 direction)
    {
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(direction * forseDrop);
    }
}
