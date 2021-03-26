using System;
using System.Collections.Generic;
using System.Text;

namespace AblyCloudAdapter.Services.DataStreamClient
{
    public interface IDataStreamClient
    {
        void InitializeConncetion(StreamConnectionSettings settings, Func<object> messageReceivedHandler);
    }
}
