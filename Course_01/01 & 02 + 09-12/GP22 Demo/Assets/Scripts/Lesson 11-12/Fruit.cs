using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Body"))
        {
            PlayerPlatformController ppc = other.GetComponentInParent<PlayerPlatformController>();
            ppc.PickUpFruit();
            Healthbar healthbar = GameObject.Find("Healthbar").GetComponent<Healthbar>();
            healthbar.UpdateUI(1);
            Destroy(gameObject);
        }
    }
}
