namespace SpecflowPlaywrightPOC.Pages.Amazon;
using System.Threading.Tasks;
using NUnit.Framework;

public partial class Amazon
{
    public async Task ValidatePresenceOfLocation(string location)
    {
        var text = await this.page.TextContentAsync(DeliverLocation(location));
        StringAssert.Contains(location, text);
    }
}