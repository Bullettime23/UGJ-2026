using CodeBase.Player;
using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using System.Collections;
using PixeLadder.EasyTransition;
using PixeLadder.EasyTransition.Effects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace CodeBase.DamageSystem
{
    public class PlayerDestructable : MonoBehaviour, IService
    {
        [SerializeField] private int maxHitPoints;
        [SerializeField] private int lifesLeft = 7;
        public PlayerCheckpoint LastCheckpoint;

        public UnityEvent Die;
        public UnityEvent ChangeHitpoints;
        [SerializeField] private GameObject damageSound;
        private int hitPoints;
        private GameObject damageImpactEffect;

        public bool IsInvincible { get; set; } = false;
        public InputActionMap playerActionMap { get; private set; }
        private IAudioManager _audioManager;
        private ISceneLoader _sceneLoader;
        [SerializeField] private TransitionEffect fadeEffect;

        private void Awake()
        {
            _audioManager = AllServices.Container.Single<IAudioManager>();
            _sceneLoader = AllServices.Container.Single<ISceneLoader>();
            SceneTransitioner.Instance.PlayTransition( null, fadeEffect);
        }

        private void Start()
        {

            hitPoints = maxHitPoints;
            ChangeHitpoints.Invoke();

            playerActionMap = GetComponent<PlayerInput>().actions.FindActionMap("Player");
        }
        public void ApplyDamage(int damage)
        {
            hitPoints -= damage;
            ChangeHitpoints.Invoke();

            PlayPlayerHurtSound();

            if (hitPoints <= 0)
            {
                Kill();
            }
        }

        public void ApplyHealing(int healing)
        {
            if (healing + hitPoints > maxHitPoints)
            {
                hitPoints = maxHitPoints;
            }
            else
            {
                hitPoints += healing;
            }
            ChangeHitpoints.Invoke();

            if (hitPoints <= 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            if (IsInvincible) return; //skip if invincible mode 

            PlayPlayerHurtSound();

            hitPoints = 0;
            Die.Invoke();
            _audioManager.PlayDeathSFX();

            if (LastCheckpoint != null)
            {
                playerActionMap.Disable();
            }
            OnDeath();
        }

        private void OnDeath()
        {
            lifesLeft--;
            if (lifesLeft != 0)
            {

                IEnumerator RespawnTimeout()
                {
                    yield return new WaitForSeconds(0.5f);
                    SceneTransitioner.Instance.PlayTransition( null, fadeEffect);
                    LastCheckpoint.Respawn(this);
                  ;
                }

                StartCoroutine(RespawnTimeout());

                return;
            }

            _sceneLoader.Load("GameOverScreen");
        }

        public int GetHitpoints()
        {
            return hitPoints;
        }

        public int GetMaxHitpoints()
        {
            return maxHitPoints;
        }

        private void PlayPlayerHurtSound()
        {
            if (damageSound != null && damageImpactEffect == null)
            {
                damageImpactEffect = Instantiate(damageSound);
            }
        }
    }
}