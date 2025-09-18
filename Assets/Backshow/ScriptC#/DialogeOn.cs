using UnityEngine;
using Naninovel;
using System.Collections;

public class NaniDialogNoMenu : MonoBehaviour
{
    [SerializeField] private string scriptName = "Dialog";
    [SerializeField] private string startLabel = "GirlStart";
    [SerializeField] private GameObject mainCanvas; // ������ ��� ������ �������

    public void StartDialog()
    {
        StartCoroutine(StartDialogCoroutine());
    }

    private IEnumerator StartDialogCoroutine()
    {
        // ��� ������������� ������ Naninovel
        while (!Engine.Initialized)
            yield return null;

        // ��������� ���� Canvas-������ ����� ��������
        if (mainCanvas != null)
            mainCanvas.SetActive(false);

        // ��������� Naninovel Title UI (����)
        var uiManager = Engine.GetService<IUIManager>();
        var titleUI = uiManager.GetUI<Naninovel.UI.ITitleUI>();
        if (titleUI != null)
            (titleUI as MonoBehaviour).gameObject.SetActive(false);

        // ��������� ������
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.PreloadAndPlayAsync(scriptName, label: startLabel).Forget();
    }

    // ����� ��� �������� ������� �� Naninovel (���������� expr:)
    public void EndDialog()
    {
        StartCoroutine(EndDialogCoroutine());

    }

    private IEnumerator EndDialogCoroutine()
    {
        while (!Engine.Initialized)
            yield return null;

        // ������������� ������ Naninovel
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.Stop();

        // �������� ������� ���� Canvas-������
        if (mainCanvas != null)
            mainCanvas.SetActive(true);

        // ����� ������� Title UI, ���� �����
        var uiManager = Engine.GetService<IUIManager>();
        var titleUI = uiManager.GetUI<Naninovel.UI.ITitleUI>();
        if (titleUI != null)
            (titleUI as MonoBehaviour).gameObject.SetActive(true);
    }
}