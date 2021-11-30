using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Quando o botão "jogar" do menu principal for precionado, a próxima cena é carregada.
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        //Quando o botão de "sair" do menu principal for precionado, a aplicação fecha.
    }
}