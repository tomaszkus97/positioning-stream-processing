using System;
using System.Collections.Generic;
using System.Text;
using AblyCloudAdapter.Contracts;

namespace AblyCloudAdapter.Services.DataStreamClient
{
    public interface IDataStreamClient
    {
        void InitializeConncetion(StreamConnectionSettings settings, Func<VehiclePositionEvent> messageReceivedHandler);
    }
}
