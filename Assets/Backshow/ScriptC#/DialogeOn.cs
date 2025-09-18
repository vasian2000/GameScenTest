using UnityEngine;
using Naninovel;
using System.Collections;

public class NaniDialogNoMenu : MonoBehaviour
{
    [SerializeField] private string scriptName = "Dialog";
    [SerializeField] private string startLabel = "GirlStart";
    [SerializeField] private GameObject mainCanvas; // теперь сам объект канваса

    public void StartDialog()
    {
        StartCoroutine(StartDialogCoroutine());
    }

    private IEnumerator StartDialogCoroutine()
    {
        // Ждём инициализации движка Naninovel
        while (!Engine.Initialized)
            yield return null;

        // Выключаем твой Canvas-объект перед диалогом
        if (mainCanvas != null)
            mainCanvas.SetActive(false);

        // Выключаем Naninovel Title UI (меню)
        var uiManager = Engine.GetService<IUIManager>();
        var titleUI = uiManager.GetUI<Naninovel.UI.ITitleUI>();
        if (titleUI != null)
            (titleUI as MonoBehaviour).gameObject.SetActive(false);

        // Запускаем диалог
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.PreloadAndPlayAsync(scriptName, label: startLabel).Forget();
    }

    // Метод для закрытия диалога из Naninovel (вызывается expr:)
    public void EndDialog()
    {
        StartCoroutine(EndDialogCoroutine());

    }

    private IEnumerator EndDialogCoroutine()
    {
        while (!Engine.Initialized)
            yield return null;

        // Останавливаем скрипт Naninovel
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.Stop();

        // Включаем обратно твой Canvas-объект
        if (mainCanvas != null)
            mainCanvas.SetActive(true);

        // Можно вернуть Title UI, если нужно
        var uiManager = Engine.GetService<IUIManager>();
        var titleUI = uiManager.GetUI<Naninovel.UI.ITitleUI>();
        if (titleUI != null)
            (titleUI as MonoBehaviour).gameObject.SetActive(true);
    }
}