using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ObtenerNombre();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public TMP_InputField playerNameInput;
    public MongoDBManager mongoDBManager;
    private string currentPlayerName;

    // public void SetPlayerName()
    // {
    //     string playerName = playerNameInput.text;
    //     mongoDBManager.RegistrarJugador(playerName);
    //     mongoDBManager.SumarPuntos(playerName,0);
    //     SceneManager.LoadScene("MenuNiveles");
    // }

    public void SetPlayerName()
    {
        currentPlayerName = playerNameInput.text;
        PlayerPrefs.SetString("NombreJugador", currentPlayerName);
        mongoDBManager.RegistrarJugador(currentPlayerName);
        // Otra lógica si es necesario
        SceneManager.LoadScene("MenuNiveles");
    }


    public string ObtenerNombre()
    {
        return PlayerPrefs.GetString("NombreJugador", "");
    }


    public void Volver()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
