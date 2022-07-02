using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Portal : MonoBehaviour
{
    public Transform salida;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = salida.position;
        position.z = other.transform.position.z;
        other.transform.position = position;
    }

}
