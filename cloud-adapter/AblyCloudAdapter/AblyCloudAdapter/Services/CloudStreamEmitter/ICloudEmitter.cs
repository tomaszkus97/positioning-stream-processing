using System.Threading.Tasks;
using AblyCloudAdapter.Contracts;

namespace AblyCloudAdapter.Services.CloudStreamEmitter
{
    public interface ICloudEmitter
    {
        Task SendARSMessage(VehicleArriveEvent message);
        Task SendVPMessage(VehiclePositionEvent message);
    }
}
