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
        [SerializeField] private GameObjectBlinking nextBlinking;


        private Queue<String> _currentMessages = new Queue<string>();
        private String _messageBeingDisplayed;
        private bool _isDisplayingMessage;

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

        public void Hide()
        {
            StopAllCoroutines();
            textUi.text = "";
            nextBlinking.Hide();
            textGO.SetActive(false);
        }

        IEnumerator DisplayMessage(String message)
        {
            if (message == null)
            {
                Hide();
                yield break;
            }
            _messageBeingDisplayed = message;
            textUi.text = "";
            nextBlinking.Hide();

            _isDisplayingMessage = true;
            foreach (char c in message)
            {
                textUi.text += c;
                yield return new WaitForSeconds(timeBetweenLetters);
            }

            _isDisplayingMessage = false;
            nextBlinking.Show();
        }


        private void Update()
        {
            if (Time.timeScale == 0f)
                return;
            if (input.Enter)
            {
                if (_isDisplayingMessage)
                {
                    StopAllCoroutines();
                    textUi.text = _messageBeingDisplayed;
                    _isDisplayingMessage = false;
                    nextBlinking.Show();
                    
                }
                else if (HasMoreMessages)
                {
                    StopAllCoroutines();

                    StartCoroutine(DisplayMessage(_currentMessages.Dequeue()));
                }
                else
                {
                    Hide();
                }
            }
        }

        private bool HasMoreMessages => _currentMessages.Count > 0;
    }
}