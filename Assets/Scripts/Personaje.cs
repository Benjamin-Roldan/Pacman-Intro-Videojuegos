using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movimiento))]
public class Personaje : MonoBehaviour
{
    public Animacion muerte;
    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }
    public Movimiento Movimiento { get; private set; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        Movimiento = GetComponent<Movimiento>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            Movimiento.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            Movimiento.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            Movimiento.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            Movimiento.SetDirection(Vector2.right);
        }
        float angle = Mathf.Atan2(Movimiento.direction.y, Movimiento.direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void EstadoInicial()
    {
        enabled = true;
        spriteRenderer.enabled = true;
        collider.enabled = true;
        muerte.enabled = false;
        muerte.spriteRenderer.enabled = false;
        Movimiento.EstadoInicial();
        gameObject.SetActive(true);
    }

    public void Muerte()
    {
        enabled = false;
        spriteRenderer.enabled = false;
        collider.enabled = false;
        Movimiento.enabled = false;
        muerte.enabled = true;
        muerte.spriteRenderer.enabled = true;
        muerte.Restart();
    }

}