using System.Threading.Tasks;

namespace congestion.tax.calculator.api.Interfaces
{
    public interface ITollTaxCalculatorService
    {
        public Task<TollTaxResponse> CalculateTollTax(TollTaxRequest tollTaxRequest);
    }
}
