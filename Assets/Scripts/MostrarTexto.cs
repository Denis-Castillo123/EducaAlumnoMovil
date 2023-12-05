using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MostrarTexto : MonoBehaviour
{
    public TMP_Text textoAVisualizar;
    public float duracion = 2f;

    void Start()
    {
        // Llama a la función para mostrar el texto al inicio.
        MostrarTextoPorUnTiempo();
    }

    void MostrarTextoPorUnTiempo()
    {
        // Activa el texto.
        textoAVisualizar.enabled = true;

        // Programa la desactivación después de la duración deseada.
        Invoke("OcultarTexto", duracion);
    }

    void OcultarTexto()
    {
        // Desactiva el texto.
        textoAVisualizar.enabled = false;
    }

    public void Volver(){
        SceneManager.LoadScene("MenuNiveles");
    }

    public void Reintentar(){
        SceneManager.LoadScene("Nivel_1");
     }

    public void Nivel2(){
        SceneManager.LoadScene("Nivel_2");
    }


}
