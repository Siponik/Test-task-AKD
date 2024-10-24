using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool isOpen = false;
    public void Interact()
    {
        Debug.Log("interact the door");
        isOpen = !isOpen;
        _animator.SetBool("IsOpen", isOpen);
    }
}
