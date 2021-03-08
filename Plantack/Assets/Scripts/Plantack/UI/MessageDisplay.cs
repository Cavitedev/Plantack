using System;
using System.Collections;
using System.Collections.Generic;
using Plantack.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Plantack.UI
{
    
    
    public class MessageDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject textGO;
        
        [SerializeField] private Text textUi;
        [SerializeField] private float timeBetweenLetters = 0.1f;
        [SerializeField] private GetInput input;
        
        
        private Queue<String> _currentMessages = new Queue<string>();
        
        public void ShowMessages(String[] messages)
        {
            
            StopAllCoroutines();

            _currentMessages.Clear();
            foreach (string message in messages)
            {
                _currentMessages.Enqueue(message);
            }

            StartCoroutine(DisplayMessage(_currentMessages.Dequeue()));
            textGO.SetActive(true);
        }

        IEnumerator DisplayMessage(String message)
        {
            textUi.text = "";
            foreach (char c in message)
            {
                textUi.text += c;
                yield return new WaitForSeconds(timeBetweenLetters);
            }
        }


        private void Update()
        {
            if (input.Enter)
            {
                if (HasMoreMessages)
                {
                    StopAllCoroutines();

                    StartCoroutine(DisplayMessage(_currentMessages.Dequeue()));
                }
                else
                {
                    textGO.SetActive(false);
                }
            }
        }

        private bool HasMoreMessages => _currentMessages.Count > 0;
    }
}