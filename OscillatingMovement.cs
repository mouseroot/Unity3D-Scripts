using UnityEngine;
using UnityEditor;
using System.Collections;

class OscillatingMovement : MonoBehaviour
{
    [Range(-1.00f,1.00f)]
    public float directionX = 0f;
    [Range(-1.00f,1.00f)]
    public float directionY = 0f;

    private float index = 0f;

    void Update()
    {
        index += Time.deltaTime;
        float x = directionX * Mathf.Cos(1.0f * index);
        float y = directionY * Mathf.Sin(1.0f * index);
        transform.localPosition = new Vector3(transform.position.x + x, transform.position.y + y, 0);
    }
}

