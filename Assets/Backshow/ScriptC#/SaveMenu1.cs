using UnityEngine;
using Naninovel;
using Naninovel.UI;

public class EscSaveMenu : MonoBehaviour
{
    private ISaveLoadUI saveLoadUI;

    void Start()
    {
        // �������� ������ UI Naninovel
        saveLoadUI = Engine.GetService<IUIManager>().GetUI<ISaveLoadUI>();
    }

    void Update()
    {
        // ��������� ������� ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (saveLoadUI != null)
            {
                // ���� ���� ��� ������� � ���������, ����� ���������
                if (saveLoadUI.Visible)
                    saveLoadUI.Hide();
                else
                    saveLoadUI.Show();
            }
        }
    }
}
