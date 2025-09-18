using Naninovel;
using Naninovel.Async;

[CommandAlias("endDialogCanvas")]
public class EndDialogCanvasCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var dialogScript = UnityEngine.Object.FindObjectOfType<NaniDialogNoMenu>();
        if (dialogScript != null)
            dialogScript.EndDialog();

        return UniTask.CompletedTask;
    }
}