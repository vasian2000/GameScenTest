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

        // Если указано имя, ищем по имени
        if (CanvasName != null && !string.IsNullOrEmpty(CanvasName))
            canvasObject = GameObject.Find(CanvasName);

        // Если не нашли по имени, ищем по тегу
        if (canvasObject == null)
            canvasObject = GameObject.FindGameObjectWithTag("MainCanvas");

        // Если все еще не нашли, ищем любой активный Canvas
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