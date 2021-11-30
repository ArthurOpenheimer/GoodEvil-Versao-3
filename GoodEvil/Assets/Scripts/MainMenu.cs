using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Quando o bot�o "jogar" do menu principal for precionado, a pr�xima cena � carregada.
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        //Quando o bot�o de "sair" do menu principal for precionado, a aplica��o fecha.
    }
}