using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorEnemigos : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;
    private float tiempoSiguienteEnemigo;

    // Limitar el número total de enemigos
    [SerializeField] private int limiteEnemigos = 10;
    public int enemigosGenerados = 0;

    // Start is called before the first frame update
    void Start()
    {
        minX = puntos.Min(p => p.position.x);
        maxX = puntos.Max(p => p.position.x);
        minY = puntos.Min(p => p.position.y);
        maxY = puntos.Max(p => p.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        //Condiciones a cumplr de los enemigos, como es la camtidad limite de los enemigos y el 
        //tiempo de spawn
        if (tiempoSiguienteEnemigo >= tiempoEnemigos && enemigosGenerados < limiteEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo();
        }
    }

    //Metodo para la generacion random de los enemigos
    private void CrearEnemigo()
    {
        int numeroEneigos = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEneigos], posicionAleatoria, Quaternion.identity);

        enemigosGenerados++;
    }
}
