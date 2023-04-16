using System;
using System.Collections;
using EidolonJobTest.Extentions;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace EidolonJobTest.RequestsSender
{
    public class LogRequestSender : IRequestSender
    {
        private CoroutineRunner _coroutineRunner;
        
        [Inject]
        private void Construct(CoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        public void Send(string uri, string message, Action<TransactionResult> transactionComplete)
        {
            _coroutineRunner.StartCoroutine(SendYield(uri, message, transactionComplete));
        }

        private IEnumerator SendYield(string uri, string message, Action<TransactionResult> transactionComplete)
        {
            bool isSuccess = Random.Range(0, 2) == 0;
            float interference = Random.Range(.1f, .9f);
            yield return new WaitForSeconds(interference);

            if (isSuccess)
            {
                transactionComplete?.Invoke(new TransactionResult(true,String.Empty));
                message.LogEditor(Color.cyan);
            }
            else
            {
                transactionComplete?.Invoke(new TransactionResult(false,"unknown"));
            }
        }
    }
}
