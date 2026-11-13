using CodeBase.InventorySystem;
using LevGamekit.Infrastructure.ServiceLocator;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private RectTransform m_KeysPanel;
    [SerializeField] private TextMeshProUGUI m_KeyAmountText;

    private IInventory m_PlayerInventory;

    private void Start()
    {
        m_PlayerInventory = AllServices.Container.Single<IInventory>();
        m_PlayerInventory.OnKeysAmountChange += UpdateUI;

        ConfigureBasedOnAmount(m_PlayerInventory.CurrentAmount);
    }

    private void OnDestroy()
    {
        m_PlayerInventory.OnKeysAmountChange -= UpdateUI;
    }

    private void UpdateUI(object sender, int nextAmount)
    {
        ConfigureBasedOnAmount(nextAmount);
    }

    private void ConfigureBasedOnAmount(int amount)
    {
        m_KeyAmountText.text = amount.ToString();

        if (amount > 0)
        {
            m_KeysPanel.gameObject.SetActive(true);
            return;
        }

        m_KeysPanel.gameObject.SetActive(false);
    }
}
