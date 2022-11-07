using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ResetLight : MonoBehaviour
{
    [SerializeField] UnityEngine.Rendering.Universal.Light2D light;

    public void Pick()
    {
        light.intensity = 1f;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Pick();
        }
    }
}
