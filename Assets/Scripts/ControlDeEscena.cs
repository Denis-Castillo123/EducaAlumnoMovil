using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeEscena : MonoBehaviour
{
    public float duracionEscenaActual = 2f;
    public CanvasGroup canvasGroup;

    void Start()
{
    canvasGroup = GetComponent<CanvasGroup>();
    if (canvasGroup == null)
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    canvasGroup.alpha = 1f;

    // Invoca la función para desvanecer el Canvas después de un tiempo
    Invoke("DesvanecerCanvas", duracionEscenaActual);
}

    void DesvanecerCanvas()
{
    // Inicia una rutina para desvanecer gradualmente el Canvas
    StartCoroutine(DesvanecerCanvasCoroutine());
}

   System.Collections.IEnumerator DesvanecerCanvasCoroutine()
    {
        // Duración del efecto de desvanecimiento (en segundos)
        float duracionDesvanecimiento = 1f;

        // Valor inicial y final de la opacidad
        float alphaInicial = canvasGroup.alpha;
        float alphaFinal = 0f;

        // Tiempo transcurrido
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionDesvanecimiento)
        {
            // Calcula la interpolación lineal entre alphaInicial y alphaFinal
            canvasGroup.alpha = Mathf.Lerp(alphaInicial, alphaFinal, tiempoPasado / duracionDesvanecimiento);

            // Incrementa el tiempo transcurrido
            tiempoPasado += Time.deltaTime;

            // Espera al siguiente frame
            yield return null;
        }

        // Asegúrate de que la opacidad sea exactamente alphaFinal al final
        canvasGroup.alpha = alphaFinal;

        // Carga la siguiente escena después de desvanecer el Canvas
        SceneManager.LoadScene("Historia_P1");
    }
}

