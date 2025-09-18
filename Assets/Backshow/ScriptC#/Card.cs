using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int id; // номер картинки/пары
    public GameManager manager;
    public Button button;
    public Image frontImage; // лицевая сторона
    public Image backImage;  // рубашка

    private bool isRevealed = false;
    private bool isMatched = false;

    void Start()
    {
        button.onClick.AddListener(OnClick);
        ShowBack();
    }

    public void OnClick()
    {
        if (isMatched || isRevealed || manager.Blocked) return;

        ShowFront();
        manager.CardRevealed(this);
    }

    public void ShowFront()
    {
        frontImage.enabled = true;
        backImage.enabled = false;
        isRevealed = true;
    }

    public void ShowBack()
    {
        if (isMatched) return; // совпавшие остаются открытыми

        frontImage.enabled = false;
        backImage.enabled = true;
        isRevealed = false;
    }

    public void SetMatched()
    {
        isMatched = true;
    }
}
