using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
     public void Jugar(){
        SceneManager.LoadScene("IngresarNombre");
     }

     public void Reglas(){
        SceneManager.LoadScene("Reglas");
     }

     public void Volver(){
        SceneManager.LoadScene("MenuInicial");
     }

     public void MenuNiveles(){
         SceneManager.LoadScene("MenuNiveles");
     }

     public void Salir(){
          Debug.Log("Salir...");
          Application.Quit();
     }
}
