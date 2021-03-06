using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBar : MonoBehaviour
{
    public GameObject itemToCraft;
    public bool onGround = false;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.GetComponent<GoldBar>())
            {
                if (other.GetComponent<GoldBar>().isGrounded && !isGrounded)
                {
                    Destroy(gameObject);
                    Instantiate(itemToCraft, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject);

                }
            }

        }
    }
}
