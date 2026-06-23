using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete;

public class ErrorViewModel
{
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
