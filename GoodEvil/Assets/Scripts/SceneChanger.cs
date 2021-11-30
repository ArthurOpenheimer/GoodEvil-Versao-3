using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Change"))
        //Compara se o player colidiu com um objeto com tag "up"
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           //Se o tempo de espera do timer já acabou, carrega a próxima cena  
        }
    }
}