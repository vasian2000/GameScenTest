using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public bool Blocked { get; private set; } = false;

    private Card firstCard = null;
    private Card secondCard = null;

    private int pairsFound = 0;
    private int totalPairs = 6; // у тебя всего 6 пар

    public void CardRevealed(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
            Blocked = true;

            // Проверяем совпадение
            if (firstCard.id == secondCard.id)
            {
                firstCard.SetMatched();
                secondCard.SetMatched();
                pairsFound++;

                firstCard = null;
                secondCard = null;
                Blocked = false;

                // Проверка на победу
                if (pairsFound >= totalPairs)
                {
                    Debug.Log("Все пары найдены! Загружаем сцену Map...");
                    SceneManager.LoadScene("Map");
                }
            }
            else
            {
                // Не совпали → перевернуть обратно
                StartCoroutine(HideCards());
            }
        }
    }

    private System.Collections.IEnumerator HideCards()
    {
        yield return new WaitForSeconds(1f);

        if (firstCard != null) firstCard.ShowBack();
        if (secondCard != null) secondCard.ShowBack();

        firstCard = null;
        secondCard = null;
        Blocked = false;
    }
}
