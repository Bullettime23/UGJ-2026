using CodeBase.InventorySystem;
using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.InteractionSystem
{
    /// <summary>
    /// В конце каждого уровня будет 3 ключа
    /// Каждый ключ открывает выход с уровня и один из замков главного выхода
    /// Когда игрок подбирает ключ, он помещается в инвентарь
    /// Ключи отображаются на экране
    /// Игрок использует ключи на выходе
    /// Использованный ключ убирается из инвентаря, как и замок открытый замок на главном выходе
    /// Состояние ключей и замков должно отмечаться в PlayerPrefs
    /// 
    /// </summary>
    public class ExitDoorInteractible : MonoBehaviour, IInteractible
    {
        private const int INITIAL_LOCKS_AMOUNT = 3;

        private const string PREFS_LOCKS_KEY = "amountOfExitLocks";
        public UnityEvent OnInteract;

        [SerializeField]
        private string
            m_NoKeysText = "Find all the keys and escape!",
            m_HasKeysText = "Open locks",
            m_NoLocksText = "Escape the circus!";

        [SerializeField] private Lock m_LockPrefab;
        [SerializeField] private Transform[] m_LocksSpawnPoints;

        [SerializeField] private string m_FinishScene;

        private List<Lock> m_LocksOnTheDoor;
        private IInventory m_PlayerInventory;
        private ISceneLoader m_SceneLoader;

        private void Start()
        {
            m_PlayerInventory = AllServices.Container.Single<IInventory>();
            m_SceneLoader = AllServices.Container.Single<ISceneLoader>();

            CreateLocks();
        }

        #region Locks functions
        private void CreateLocks()
        {
            m_LocksOnTheDoor = new List<Lock>();

            //int locksAmount = PlayerPrefs.GetInt(PREFS_LOCKS_KEY, 3);

            for (int i = 0; i < INITIAL_LOCKS_AMOUNT; i++)
            {
                Lock nextLock = Instantiate(m_LockPrefab, transform);
                nextLock.transform.position = m_LocksSpawnPoints[i].position;

                m_LocksOnTheDoor.Add(nextLock);
            }
        }

        private void OpenTheLastLock()
        {
            Lock lastLock = m_LocksOnTheDoor[m_LocksOnTheDoor.Count - 1];

            lastLock.OpenLock();

            m_LocksOnTheDoor.Remove(lastLock);


            // Reduce locks number in memory;

            //int locksAmount = PlayerPrefs.GetInt(PREFS_LOCKS_KEY, 3);

            //locksAmount--;

            //PlayerPrefs.SetInt(PREFS_LOCKS_KEY, locksAmount);
        }
        #endregion

        public string GetDescription()
        {
            // Check if there're any locks
            if (m_LocksOnTheDoor.Count > 0)
            {
                if (m_PlayerInventory.CurrentAmount == 0)
                {
                    return m_NoKeysText;
                }

                return m_HasKeysText;
            }
            // Check if the player holds any keys

            return m_NoLocksText;
        }

        public void Interact()
        {
            OnInteract.Invoke();

            // Check if there're any locks
            if (m_LocksOnTheDoor.Count > 0)
            {
                // Check if the player has any keys
                if (m_PlayerInventory.CurrentAmount == 0)
                {
                    // Make closed sound?
                    return;
                }

                OpenTheLastLock();
                m_PlayerInventory.DragKeysFromInventory(1);

                return;
            }

            // Finish the game
            m_SceneLoader.Load(m_FinishScene);
        }
    }
}