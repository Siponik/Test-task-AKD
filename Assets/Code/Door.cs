using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool isOpen = false;
    public void Interact()
    {
        Debug.Log("interact the door");
        _animator.SetBool("IsOpen", !isOpen);
        isOpen = !isOpen;
    }
}
