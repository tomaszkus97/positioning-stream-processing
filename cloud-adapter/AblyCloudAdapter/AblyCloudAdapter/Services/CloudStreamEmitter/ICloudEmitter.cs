using System.Threading.Tasks;

namespace AblyCloudAdapter.Services.CloudStreamEmitter
{
    public interface ICloudEmitter
    {
        Task SendMessage(byte[] message);
    }
}
