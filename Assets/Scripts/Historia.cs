using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Historia : MonoBehaviour
{
    public void Omitir(){
        SceneManager.LoadScene("MenuInicial");
    }

    public void Siguiente(){
        SceneManager.LoadScene("Historia_P2");
    }

    public void Entendido(){
        SceneManager.LoadScene("MenuInicial");
    }
    
    public void Volver(){
        SceneManager.LoadScene("Historia_P1");
    }

    

    
}
