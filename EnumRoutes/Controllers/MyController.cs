using Microsoft.AspNetCore.Mvc;

namespace EnumRoutes.Controllers;

public enum TcgPlayerCategory { MagicTheGathering, FleshAndBlood, DragonBallSuper }
public record CategoryRouteValues(int CategoryId, string SinglesProductName);

[ApiController]
[Route("[controller]")]
public class TcgPlayerController : ControllerBase
{
    /*
     * Here's an example of why you may want to use an enum in a route - identical or almost identical logic for different resources
     * In my case, I was hitting the TcgPlayer API to read card data, but if you only want to get card singles (and not sealed products, etc.)
     * then you need to specify the singles category. However, this category is not consistently named across the different card games
     */

    private static Dictionary<TcgPlayerCategory, CategoryRouteValues> _categoryRouteVaules = new()
    {
        { TcgPlayerCategory.MagicTheGathering, new CategoryRouteValues(1, "Cards") },
        { TcgPlayerCategory.FleshAndBlood, new CategoryRouteValues(2, "Cards") },
        { TcgPlayerCategory.DragonBallSuper, new CategoryRouteValues(3, "Dragon+Ball+Super+Singles") }
    };

    [HttpGet("{category:tcgPlayerCategoryEnum}")]
    public ActionResult GetProducts([FromRoute] TcgPlayerCategory category)
    {
        var routeValues = _categoryRouteVaules[category];

        // A call using these route values would look something like this:
        // _client.GetProducts(routeValues.CategoryId, routeValues.SinglesProductType)
        // and then return the data

        return Ok();
    }
}
