using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    // имя сцены, которую нужно загрузить
    public string sceneName;

    // метод для привязки к кнопке
    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
