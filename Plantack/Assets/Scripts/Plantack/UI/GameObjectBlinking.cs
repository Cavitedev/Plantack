using System.Collections;
using UnityEngine;

public class GameObjectBlinking : MonoBehaviour
{
    [SerializeField, Tooltip("Game object to blink, needs to be a child")]
    private GameObject gameObjectBlinking;

    [SerializeField] private float timeBlink = 0.5f;

    public void Hide()
    {
        StopBlinking();
        gameObjectBlinking.SetActive(false);
    }
    
    

    public void Show()
    {
        StopBlinking();
        StartCoroutine(BlinkObject());
    }


    
    IEnumerator BlinkObject()
    {
        while (true)
        {
            gameObjectBlinking.SetActive(true);
            yield return new WaitForSeconds(timeBlink);
            gameObjectBlinking.SetActive(false);
            yield return new WaitForSeconds(timeBlink);
        }
    }
    
    private void StopBlinking()
    {
        StopAllCoroutines();
    }



}