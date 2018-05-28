using Controllers;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneManager : Singleton<SceneManager>
    {
        private CommandController _commandController;
        private GameObject _robot;

        public Command[] Commands;
        public bool IsWork = false;

        public GameObject Robot
        {
            get
            {
                if (_robot == null)
                {
                    _robot = GameObject.FindWithTag("Robot");
                }
                return _robot;
            }
        }
        private void Start()
        {
            _commandController = new CommandController();
            LoadScene();
        }

        public void LoadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
        }
    }
}