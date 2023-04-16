using UnityEngine;

namespace EidolonJobTest.RequestsSender
{
    public class TransactionResult
    {
        private bool _isSuccess;
        private string _reason;

        public bool IsSuccess => _isSuccess;
        public string Reason => _reason;

        public TransactionResult(bool isSuccess, string reason)
        {
            _isSuccess = isSuccess;
            _reason = reason;
        }
    }
}
