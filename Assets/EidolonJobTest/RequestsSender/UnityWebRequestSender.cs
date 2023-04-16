using System;
using System.Collections;
using UnityEngine.Networking;
using Zenject;

namespace EidolonJobTest.RequestsSender
{
    public class UnityWebRequestSender : IRequestSender
    {
        private const int TRANSACTION_TIMEOUT = 10;

        private CoroutineRunner _coroutineRunner;

        [Inject]
        private void Construct(CoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Send(string uri, string message, Action<TransactionResult> transactionComplete)
        {
            _coroutineRunner.StartCoroutine(SendYield(uri,message,transactionComplete));
        }

        private IEnumerator SendYield(string uri, string message, Action<TransactionResult> transactionComplete)
        {
            UnityWebRequest unityWebRequest = UnityWebRequest.Post(uri,message);
            unityWebRequest.timeout = TRANSACTION_TIMEOUT;
            yield return unityWebRequest;
            if (unityWebRequest.result==UnityWebRequest.Result.Success)
                transactionComplete.Invoke(new TransactionResult(true,String.Empty));
            else
                transactionComplete.Invoke(new TransactionResult(false,unityWebRequest.error));
            
        }
    }
}
