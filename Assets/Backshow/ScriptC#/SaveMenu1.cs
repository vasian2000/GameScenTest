using UnityEngine;
using Naninovel;
using Naninovel.UI;

public class EscSaveMenu : MonoBehaviour
{
    private ISaveLoadUI saveLoadUI;

    void Start()
    {
        // Получаем сервис UI Naninovel
        saveLoadUI = Engine.GetService<IUIManager>().GetUI<ISaveLoadUI>();
    }

    void Update()
    {
        // Проверяем нажатие ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (saveLoadUI != null)
            {
                // Если меню уже открыто — закрываем, иначе открываем
                if (saveLoadUI.Visible)
                    saveLoadUI.Hide();
                else
                    saveLoadUI.Show();
            }
        }
    }
}
