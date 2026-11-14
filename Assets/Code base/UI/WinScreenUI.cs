using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using UnityEngine;

namespace CodeBase.UI {
    public class WinScreenUI : MonoBehaviour
    {
        [SerializeField] private string m_LevelName;
        private ISceneLoader m_SceneLoader;
        void Start()
        {
            m_SceneLoader = AllServices.Container.Single<ISceneLoader>();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void LoadLevel()
        {
            Debug.Log("Click");
            m_SceneLoader.Load(m_LevelName);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}