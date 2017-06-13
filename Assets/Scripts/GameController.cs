using System.Collections;
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
        private int _lifes;
        private int _blockCount;
        private int _currentLevel;
        public Text PointText;
        public Text LifesText;

        // Use this for initialization
        void Start()
        {
            _currentLevel = 0;
            SceneManager.LoadScene(Scenes[_currentLevel].name, LoadSceneMode.Additive);
            Points = 0;
            _lifes = 5;
        }

        // Update is called once per frame
        void Update()
        {
            PointText.text = "Punkte: " + Points;
            LifesText.text = "Leben: " + _lifes;
        }

        public void RemoveLife()
        {
            _lifes -= 1;
            if (_lifes == 0)
            {
                SceneManager.LoadScene(GameOverScene.name);
            }
        }

        public void RegisterBlock()
        {
            _blockCount++;
        }

        public void UnregisterBlock()
        {
            _blockCount--;
            if (_blockCount == 0)
            {
                SceneManager.UnloadSceneAsync(Scenes[_currentLevel].name);
                _currentLevel++;
                _currentLevel = _currentLevel % Scenes.Length;
                StartCoroutine(LoadLevelInASecond());
            }
        }

        private IEnumerator LoadLevelInASecond()
        {
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene(Scenes[_currentLevel].name, LoadSceneMode.Additive);
        }
    }
}
