using UnityEngine;
using CodeBase.DamageSystem;
using CodeBase.Player;
using LevGamekit.Infrastructure.ServiceLocator;
using LevGamekit.Infrastructure.StateMachine;
using UnityEngine.InputSystem;

namespace PackRush.Services.LevelStates
{
    public class LevelPlayerDeathState : IEnterableState, IExitableState, IService
    {
        private InputActionAsset m_InputAsset;
        private Transform m_Player;


        public void Enter()
        {
            Debug.Log("Player death state ENTER");


            // Reset inventory if any
            // Reset level state

            // Teleport player to the last checkpoint
            m_Player = AllServices.Container.Single<PlayerDestructable>().transform;

            m_InputAsset = m_Player.GetComponent<PlayerInput>().actions;

            m_InputAsset.FindActionMap("Player").Disable();
        }



        public void Exit()
        {
            Debug.Log("Exiting state");
            PlayerCheckpoint checkpoint = AllServices.Container.Single<PlayerCheckpoint>();

            m_Player.position = checkpoint.transform.position;
            m_Player.rotation = checkpoint.transform.rotation;

            m_InputAsset.FindActionMap("Player").Enable();

            // Next state;
            AllServices.Container.Single<ILevelStateSwitcher>().Enter<LevelDefaultState>();
        }
    }
}