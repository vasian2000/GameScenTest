using Naninovel;
using UnityEngine;
using System.Threading.Tasks;

[CommandAlias("toggleCanvas")]
public class ToggleCanvas : Command
{
    [ParameterAlias("show")]
    public BooleanParameter Show;

    [ParameterAlias("name")]
    public StringParameter CanvasName;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        GameObject canvasObject = null;

        // ���� ������� ���, ���� �� �����
        if (CanvasName != null && !string.IsNullOrEmpty(CanvasName))
            canvasObject = GameObject.Find(CanvasName);

        // ���� �� ����� �� �����, ���� �� ����
        if (canvasObject == null)
            canvasObject = GameObject.FindGameObjectWithTag("MainCanvas");

        // ���� ��� ��� �� �����, ���� ����� �������� Canvas
        if (canvasObject == null)
        {
            var canvas = Object.FindObjectOfType<Canvas>();
            if (canvas != null)
                canvasObject = canvas.gameObject;
        }

        if (canvasObject != null)
            canvasObject.SetActive(Show);
        else
            Debug.LogWarning("Canvas not found!");

        return UniTask.CompletedTask;
    }
}