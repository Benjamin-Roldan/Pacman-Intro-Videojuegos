using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Punto : MonoBehaviour
{
    public int puntos = 10;

    protected virtual void Comer()
    {
        FindObjectOfType<GameManager>().PuntoComido(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Personaje")) {
        this.gameObject.SetActive(false);
        }
    }
}
