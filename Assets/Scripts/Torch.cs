using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Torch : MonoBehaviour
{
    [SerializeField] Light2D _light;
    public float speed = 1f;
    public float protectionRadius;
    public bool infinity = false;
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
        if (infinity) return;

        _light.intensity -= (speed / 100) * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, protectionRadius);
    }
}