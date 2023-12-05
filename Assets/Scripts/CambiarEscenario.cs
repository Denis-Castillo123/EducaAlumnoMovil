using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenario : MonoBehaviour
{
    public void CambiarAEscenario(string nombreEscenario)
    {
        // // Detener el audio al cambiar de escenario
        // AudioManager.Instance.mainAudioSource.Stop();

        // // Cambiar a otro escenario
        // SceneManager.LoadScene("Historia_P1");
        // SceneManager.LoadScene("Historia_P2");
        // SceneManager.LoadScene("IngresarNombre");
        // SceneManager.LoadScene("MejoresPuntajes");
        // SceneManager.LoadScene("Menu");
        // SceneManager.LoadScene("MenuInicial");
        // SceneManager.LoadScene("MenuNiveles");
        // SceneManager.LoadScene("Reglas");
        // SceneManager.LoadScene("PantallaInicial");


        if (SceneManager.GetActiveScene().name == "Historia_P1" ||
            SceneManager.GetActiveScene().name == "Historia_P2" ||
            SceneManager.GetActiveScene().name == "IngresarNombre" ||
            SceneManager.GetActiveScene().name == "MejoresPuntajes" ||
            SceneManager.GetActiveScene().name == "Menu" ||
            SceneManager.GetActiveScene().name == "MenuInicial" ||
            SceneManager.GetActiveScene().name == "MenuNiveles" ||
            SceneManager.GetActiveScene().name == "Reglas" ||
            SceneManager.GetActiveScene().name == "PantallaInicial")
        {
            SceneManager.LoadScene(nombreEscenario);
        }else{
            AudioManager.Instance.mainAudioSource.Stop();
        }
        
    }
}
