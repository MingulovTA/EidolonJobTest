using System;

namespace EidolonJobTest.RequestsSender
{
    public interface IRequestSender
    {
        public void Send(string uri, string message, Action<TransactionResult> transactionComplete);
    }
}
