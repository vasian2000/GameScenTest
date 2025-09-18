using UnityEngine;
using Naninovel;
using System.Collections;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public bool hasCrystal = false;
    public int crystalOwner = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(InitializeWhenReady());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator InitializeWhenReady()
    {
        // Ждём инициализации Naninovel
        while (!Engine.Initialized || Engine.GetService<ICustomVariableManager>() == null)
            yield return null;

        // Инициализируем переменные с правильным форматом
        var vars = Engine.GetService<ICustomVariableManager>();
        if (!vars.VariableExists("hasCrystal"))
            vars.SetVariableValue("hasCrystal", "False");
        if (!vars.VariableExists("crystalResolved"))
            vars.SetVariableValue("crystalResolved", "False");
        if (!vars.VariableExists("crystalOwner"))
            vars.SetVariableValue("crystalOwner", "0");

        SyncWithNaninovel();
        Debug.Log("[QuestManager] Initialized and synced with Naninovel");
    }

    public void TakeCrystal()
    {
        hasCrystal = true;
        SyncWithNaninovel();
    }

    public void GiveCrystal(int owner)
    {
        crystalOwner = owner;
        hasCrystal = false;
        SyncWithNaninovel();
    }

    public static void GiveCrystalStatic(string ownerStr)
    {
        if (Instance != null && int.TryParse(ownerStr, out int owner))
            Instance.GiveCrystal(owner);
    }

    public static void TakeCrystalStatic()
    {
        Instance?.TakeCrystal();
    }

    private void SyncWithNaninovel()
    {
        if (!Engine.Initialized) return;

        var vars = Engine.GetService<ICustomVariableManager>();
        if (vars == null) return;

        // Используем правильный регистр для Naninovel: "True"/"False"
        vars.SetVariableValue("hasCrystal", hasCrystal ? "True" : "False");
        vars.SetVariableValue("crystalResolved", (crystalOwner != 0) ? "True" : "False");
        vars.SetVariableValue("crystalOwner", crystalOwner.ToString());

        Debug.Log($"[QuestManager] Synced -> hasCrystal={hasCrystal}, owner={crystalOwner}");
    }
}