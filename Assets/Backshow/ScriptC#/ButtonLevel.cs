using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    // ��� �����, ������� ����� ���������
    public string sceneName;

    // ����� ��� �������� � ������
    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
