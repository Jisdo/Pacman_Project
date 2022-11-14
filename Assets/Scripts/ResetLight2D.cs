using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Collider2D))]
public class ResetLight2D : MonoBehaviour
{
    [SerializeField] Light2D light;
    public new Collider2D collider { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }

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