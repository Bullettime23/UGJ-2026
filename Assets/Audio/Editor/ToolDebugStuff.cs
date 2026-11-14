using CodeBase.DamageSystem;
using UnityEditor;
using UnityEngine;

public class ToolDebugStuff : EditorWindow
{
    
    [MenuItem("Tools/Debug Tools")]
    public static void ShowWindow()
    {
        GetWindow<ToolDebugStuff>("Debug Tools");
    }

    private void OnGUI()
    {
        GUILayout.Label("Player Debug Tools", EditorStyles.boldLabel);

        if (GUILayout.Button("Toggle Invincible Mode", GUILayout.Height(35)))
        {
            ToggleInvincibility();
        }
    }

    
    private void ToggleInvincibility()
    {
        PlayerDestructable player = FindFirstObjectByType<PlayerDestructable>();

        if (player == null)
        {
            Debug.LogWarning("Could not find PlayerDestructable in the scene.");
            return;
        }

        player.IsInvincible = !player.IsInvincible;

        Debug.Log($"Invincibility: {(player.IsInvincible ? "ON" : "OFF")}");
    }
}
