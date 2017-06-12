using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public SceneAsset[] Scenes;
        public SceneAsset GameOverScene;
        public int Points { get; set; }
        public int Lifes { get; set; }
        public Text PointText;
        public Text LifesText;

        // Use this for initialization
        void Start()
        {
            SceneManager.LoadScene(Scenes[0].name, LoadSceneMode.Additive);
            Points = 0;
            Lifes = 5;
        }

        // Update is called once per frame
        void Update()
        {
            PointText.text = "Punkte: " + Points;
            LifesText.text = "Leben: " + Lifes;
        }

        public void RemoveLife()
        {
            Lifes -= 1;
            if (Lifes == 0)
            {
                SceneManager.UnloadSceneAsync(Scenes[0].name);
                SceneManager.LoadScene(GameOverScene.name,LoadSceneMode.Additive);
            }
        }
    }
}
