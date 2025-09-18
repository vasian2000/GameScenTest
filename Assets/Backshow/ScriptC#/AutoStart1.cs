using UnityEngine;
using Naninovel;


public class AutoStartNaninovel : MonoBehaviour
{
    [SerializeField] private string scriptName = "TestScript"; // имя скрипта, который нужно запустить
    [SerializeField] private float delay = 5f; // задержка перед запуском

    private async void Start()
    {
        // ждём указанное время
        await UniTask.Delay(System.TimeSpan.FromSeconds(delay));

        // запускаем сценарий
        var player = Engine.GetService<IScriptPlayer>();
       
    }
}
