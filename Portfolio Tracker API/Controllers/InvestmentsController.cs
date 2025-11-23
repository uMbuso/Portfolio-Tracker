using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_Tracker_API.DTO;
using Portfolio_Tracker_API.Services;
using System.Security.Claims;

namespace Portfolio_Tracker_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InvestmentsController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentsController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInvestments()
        {
            var investments = await _investmentService.GetUserInvestmentsAsync(GetUserId());
            return Ok(investments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvestment([FromBody] CreateInvestmentDto dto)
        {
            try
            {
                var investment = await _investmentService.CreateInvestmentAsync(GetUserId(), dto);
                return CreatedAtAction(nameof(GetUserInvestments), investment);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvestment(int id, [FromBody] CreateInvestmentDto dto)
        {
            try
            {
                var investment = await _investmentService.UpdateInvestmentAsync(id, dto);
                return Ok(investment);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestment(int id)
        {
            await _investmentService.DeleteInvestmentAsync(id);
            return NoContent();
        }

        [HttpGet("portfolio-summary")]
        public async Task<IActionResult> GetPortfolioSummary()
        {
            var summary = await _investmentService.GetPortfolioSummaryAsync(GetUserId());
            return Ok(summary);
        }
    }
}
