using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    [SerializeField] private GameObject crystalImage;

    private void Start()
    {
        // ���������, ���� �� ��� ��������
        if (QuestManager.Instance != null && QuestManager.Instance.hasCrystal)
        {
            if (crystalImage != null)
                crystalImage.SetActive(false);

            gameObject.SetActive(false);
        }
    }

    public void PickUpCrystal()
    {
        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.TakeCrystal();
            Debug.Log("Crystal picked up!");
        }

        if (crystalImage != null)
            crystalImage.SetActive(false);

        gameObject.SetActive(false);
    }
}
