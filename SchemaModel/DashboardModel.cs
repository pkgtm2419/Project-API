namespace ProjectAPI.SchemaModel
{
    public class CustomerDashboardData
    {
        public CustomerMetrics Customer { get; set; }
        public List<Segment> CustomerSegment { get; set; }
        public List<MonthlyData> CustomerYearWise { get; set; }
        public RevenueMetrics Revenue { get; set; }
        public List<Segment> RevenueSegment { get; set; }
        public List<RevenueYearWise> RevenueYearWise { get; set; }
        public LoadMetrics Load { get; set; }
        public List<Segment> LoadSegmentWise { get; set; }
        public List<MonthlyData> LoadYearWise { get; set; }
        public OutstandingMetrics Outstanding { get; set; }
        public List<OutstandingInDays> OutstandingInDays { get; set; }
        public List<MonthlyData> OutstandingMonthWise { get; set; }
    }

    public class CustomerMetrics
    {
        public int TotalCustomer { get; set; }
        public int TotalCustomerLastMonth { get; set; }
        public int CurrentMonthCustomerCount { get; set; }
    }

    public class MonthlyData
    {
        public string MonthName { get; set; }
        public List<YearlyData> Data { get; set; }
    }

    public class YearlyData
    {
        public int Year { get; set; }
        public double Count { get; set; }
    }

    public class RevenueYearWise
    {
        public string Name { get; set; }
        public List<MonthlySeries> Series { get; set; }
    }

    public class MonthlySeries
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }

    public class Segment
    {
        public string Id { get; set; }
        public double Count { get; set; }
        public double TotalRevenue { get; set; }
        public double TotalBillingUnit { get; set; }
    }

    public class RevenueMetrics
    {
        public double GetTotalRevenue { get; set; }
        public double GetTotalRevenueLastMonth { get; set; }
        public double GetCurrentMonthRevenue { get; set; }
    }

    public class LoadMetrics
    {
        public double GetTotalLoad { get; set; }
        public double GetTotalLoadLastMonth { get; set; }
        public double GetTotalLoadCurrentMonth { get; set; }
    }

    public class OutstandingMetrics
    {
        public double GetTotalOutstanding { get; set; }
        public double GetTotalOutstandingLastMonth { get; set; }
        public double GetTotalOutstandingCurrentMonth { get; set; }
    }

    public class OutstandingInDays
    {
        public string AgingBucket { get; set; }
        public double TotalOutstanding { get; set; }
    }

    public class ResDashboardCustomer
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<CustomerDashboardData>? data { get; set; }
    }
}
