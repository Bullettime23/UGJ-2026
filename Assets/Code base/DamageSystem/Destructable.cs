using LevGamekit.Infrastructure.ServiceLocator;
using UnityEngine;
using UnityEngine.Events;

public class Destructable : MonoBehaviour, IService
{
    [SerializeField] private int maxHitPoints;

    public UnityEvent Die;
    public UnityEvent ChangeHitpoints;
    [SerializeField] private GameObject damageSound;
    private int hitPoints;
    private GameObject damageImpactEffect;

    private void Start()
    {
        hitPoints = maxHitPoints;
        ChangeHitpoints.Invoke();
    }
    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;
        ChangeHitpoints.Invoke();

        PlayPlayerHurtSound();

        if(hitPoints <= 0)
        {
            Kill();
        }
    }

    public void ApplyHealing(int healing)
    {
        if (healing + hitPoints > maxHitPoints) {
            hitPoints = maxHitPoints;
        } else
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
        PlayPlayerHurtSound();

        hitPoints = 0;
        Die.Invoke();
        print("Player died");
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
