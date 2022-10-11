using GymOffice.Common.Contracts.DataProviderContracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GymOffice.VisitorCabinet.Controllers;

[Route("[controller]")]
[EnableCors]
[ApiController]
public class RulesController : ControllerBase
{
    private readonly IGymRulesDataProvider _rulesDataProvider;

    public RulesController(IGymRulesDataProvider rulesDataProvider)
    {
        _rulesDataProvider = rulesDataProvider;
    }

    [HttpGet]
    [Route("Sections")]
    public async Task<IActionResult> GetActiveRulesSections()
    {
        var rulesSections = await _rulesDataProvider.GetActiveRuleSectionsAsync();
        if (rulesSections == null)
            return Ok("Rules not found");

        return Ok(rulesSections);
    }

    [HttpGet]
    [Route("RulesBySection/{sectionId:guid}")]
    public async Task<IActionResult> GetActiveRulesBySectionId(Guid sectionId)
    {
        var rules = await _rulesDataProvider.GetActiveRulesBySectionIdAsync(sectionId);
        if (rules == null)
            return Ok("Rules not found");

        return Ok(rules);
    }
}
