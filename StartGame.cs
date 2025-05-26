using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartButtonClicked()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
