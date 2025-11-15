using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesControl.Application.DTOs
{
    internal class ExpenseDashboardDto
    {
        public Dictionary<string, decimal> TotalByType { get; set; } = new();
        public Dictionary<string, decimal> MonthlyTotals { get; set; } = new();
    }
}
