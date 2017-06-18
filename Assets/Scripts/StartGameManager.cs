using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class StartGameManager : MonoBehaviour
    {
        public SceneAsset GameScene;

        public void OnStartGame()
        {
            SceneManager.LoadScene(GameScene.name,LoadSceneMode.Single);
        }

        public void OnExitGame()
        {
            Application.Quit();
        }
    }
}
