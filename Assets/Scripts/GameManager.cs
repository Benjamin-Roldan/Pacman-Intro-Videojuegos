using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public Fantasma[] fantasmas;
    public Personaje personaje;
    public Transform puntos;

    public int MultFant = 1;
    public int puntuacion;
    public int vidas;
    private void Start()
    {
        NuevaPartida();
    }
    private void Update()
    {
        if (this.vidas <= 0 && Input.anyKeyDown)
        {
            NuevaPartida();
        }
    }
    private void NuevaPartida()
    {
        ModifPuntuacion(0);
        NuevaRonda();
    }
    private void NuevaRonda()
    {
        foreach (Transform punto in puntos)
        {
             punto.gameObject.SetActive(true);
        }
        personaje.gameObject.SetActive(true);
    }
    private void ModifPuntuacion(int puntuacion)
    {
        this.puntuacion = puntuacion;
    }
    public void PuntoComido(Punto punto)
    {
        punto.gameObject.SetActive(false);
        ModifPuntuacion(puntuacion + punto.puntos);

        if (!QuedanPuntos())
        {
            personaje.gameObject.SetActive(false);
            Invoke(nameof(NuevaRonda), 3f);
        }
    }
    
     private bool QuedanPuntos()
    {
        foreach(Transform punto in puntos)
        {
            if (punto.gameObject.activeSelf) {
                return true;
            }
        }
        return false;
    }
}
//Falta:
// - Implementar puntos de poder y frutas
// - Implementar comportamiento general de los dantasmas y prefabs
// - Implementar comportamiento de cada uno de los fantasmas, el que persigue, el que embosca, el erratico y el lento
// - Implementar entrada, salida y estado de los fantasmas
// - UI, vidas y puntuacion
// - Mas niveles
// - Cerrar el proyecto y crear ejecutable