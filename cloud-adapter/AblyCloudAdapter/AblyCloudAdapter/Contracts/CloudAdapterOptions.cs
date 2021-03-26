using AblyCloudAdapter.Services.DataStreamClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AblyCloudAdapter.Contracts
{
    public class CloudAdapterOptions
    {
        public StreamConnectionSettings StreamConnection { get; set; }
    }
}
