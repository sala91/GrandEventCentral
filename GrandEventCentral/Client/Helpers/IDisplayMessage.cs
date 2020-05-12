using System.Threading.Tasks;

namespace GrandEventCentral.Client.Helpers
{
    internal interface IDisplayMessage
    {
        ValueTask DisplayErrorMessage(string message);
        ValueTask DisplaySuccessMessage(string message);
    }
}
