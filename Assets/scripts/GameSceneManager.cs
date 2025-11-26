using UnityEngine;                 // basic unity stuff
using UnityEngine.SceneManagement; // scene api

public class GameSceneManager : MonoBehaviour{

    public void QuitGame()
    {
        // exit whole game
        Application.Quit();
    }

    public void LoadGameWinScene( )
    {
        // win screen
        SceneManager.LoadScene("gameWin");
    }

    public void LoadGameOverScene()
    {
        // lose screen
        SceneManager.LoadScene("gameOver");
    }

    public void LoadMainGameScene()
    {
        // main rps thing
        SceneManager.LoadScene("homeScene");
    }

    public void LoadWelcomeScene()
    {
        // start menu
        SceneManager.LoadScene("WelcomeScene");
    }
}
