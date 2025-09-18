using Naninovel;
using System.Threading.Tasks;

[CommandAlias("giveCrystalToGirl")]
public class GiveCrystalToGirlCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        QuestManager.GiveCrystalStatic("1"); // 1 = ID девушки
        return UniTask.CompletedTask;
    }
}

[CommandAlias("takeCrystal")]
public class TakeCrystalCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        QuestManager.TakeCrystalStatic();
        return UniTask.CompletedTask;
    }
}