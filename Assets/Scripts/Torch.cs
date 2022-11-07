using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Collider2D))]
public class Torch : MonoBehaviour
{
    [SerializeField] Light2D _light;
    public float speed = 1f;
    public float outerRadiusMin = 6, outerRadiusMax = 7;

    private void Start()
    {
        if(_light == null)
            _light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    private void Update()
    {
        _light.pointLightOuterRadius = Random.Range(outerRadiusMin, outerRadiusMax);

        if (_light.intensity <= 0) return;

        _light.intensity -= (speed / 100) * Time.deltaTime;
    }

    private void Reset()
    {
        _light.intensity = 1f;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Reset();
        }
    }
}
