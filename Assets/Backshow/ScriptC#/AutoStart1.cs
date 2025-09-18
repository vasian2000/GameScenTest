using UnityEngine;
using Naninovel;


public class AutoStartNaninovel : MonoBehaviour
{
    [SerializeField] private string scriptName = "TestScript"; // ��� �������, ������� ����� ���������
    [SerializeField] private float delay = 5f; // �������� ����� ��������

    private async void Start()
    {
        // ��� ��������� �����
        await UniTask.Delay(System.TimeSpan.FromSeconds(delay));

        // ��������� ��������
        var player = Engine.GetService<IScriptPlayer>();
       
    }
}
