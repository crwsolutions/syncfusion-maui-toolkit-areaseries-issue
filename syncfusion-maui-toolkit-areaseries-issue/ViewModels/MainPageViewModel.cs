using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace syncfusion_maui_toolkit_areaseries_issue.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    public partial List<LineModel>? IncomeData { get; set; }

    [ObservableProperty]
    public partial List<LineModel>? RemainingBalanceFlowData { get; set; }

    [ObservableProperty]
    public partial List<LineModel>? ExpenseData { get; set; }

    private readonly List<LineModel> _incomeDataYearly;
    private readonly List<LineModel> _incomeDataMonthly;
    private readonly List<LineModel> _expenseDataYearly;
    private readonly List<LineModel> _expenseDataMonthly;
    private readonly List<LineModel> _flowDataYearly;
    private readonly List<LineModel> _flowDataMonthly;
    // Constructor to initialize the data
    public MainPageViewModel()
    {
        _incomeDataYearly = ToLineModel(yearlyTotalIncomeRaw);
        _incomeDataMonthly = ToLineModel(monthlyTotalIncomeRaw);
        _expenseDataYearly = ToLineModel(yearlyTotalExpenseRaw);
        _expenseDataMonthly = ToLineModel(monthlyTotalExpenseRaw);
        _flowDataYearly = ToLineModel(yearlyRemainingBalanceFlowRaw);
        _flowDataMonthly = ToLineModel(monthlyRemainingBalanceFlowRaw);

        IncomeData = _incomeDataYearly;
        ExpenseData = _expenseDataYearly;
        RemainingBalanceFlowData = _flowDataYearly;
    }

    private List<LineModel> ToLineModel(int[] yearlyTotalIncomeRaw)
    {
        var list = new List<LineModel>();
        var startYear = 2025;
        for (int i = 0; i < yearlyTotalIncomeRaw.Length; i++)
        {
            startYear++;
            list.Add(new LineModel(startYear, yearlyTotalIncomeRaw[i]));
        }
        return list;
    }

    [RelayCommand]
    private void ToggleData()
    {
        if (IncomeData == _incomeDataYearly)
        {
            IncomeData = _incomeDataMonthly;
            ExpenseData = _expenseDataMonthly;
            RemainingBalanceFlowData = _flowDataMonthly;
        }
        else
        {
            IncomeData = _incomeDataYearly;
            ExpenseData = _expenseDataYearly;
            RemainingBalanceFlowData = _flowDataYearly;
        }
    }

    int[] monthlyTotalIncomeRaw = [5520,5520,6722,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,5520,3257,0,0,96,1138,1127,1838,2177,2155,2134,2113,2093,2072,2053,2034,2015,1996,1978,1960];

    int[] monthlyTotalExpenseRaw = [6273, 6272, 7286, 5228, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133, 5133];

    int[] monthlyRemainingBalanceFlowRaw = [-752, -752, -564, 293, 812, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 1119, 407, 0, -3342, -5037, -3995, -4007, -3295, -2956, -2978, -2999, -3020, -3041, -3061, -3081, -3100, -3119, -3137, -3155, -3173];

    // --- Yearly Values ---
    int[] yearlyTotalIncomeRaw = [66245, 66245, 80662, 66245, 66244, 66244, 66244, 66245, 66245, 66244, 66245, 66246, 66244, 66245, 66245, 66245, 66245, 66245, 66245, 66245, 66245, 66245, 66245, 66245, 66244, 66245, 66245, 66245, 66245, 66245, 66245, 66245, 39085, 0, 0, 1150, 13660, 13521, 22055, 26124, 25863, 25607, 25357, 25111, 24870, 24634, 24402, 24175, 23953, 23734, 23520];

    int[] yearlyTotalExpenseRaw = [75274, 75270, 87432, 62730, 61600, 61600, 61600, 61601, 61601, 61600, 61600, 61600, 61599, 61600, 61600, 61600, 61600, 61599, 61599, 61600, 61599, 61600, 61600, 61600, 61600, 61600, 61600, 61600, 61600, 61599, 61600, 61600, 61600, 61600, 61600, 61600, 61600, 61600, 61600, 61599, 61600, 61600, 61599, 61600, 61600, 61600, 61600, 61600, 61600, 61600, 61600];

    int[] yearlyRemainingBalanceFlowRaw = [-9030, -9025, -6769, 3514, 9741, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 13424, 4882, 0, -40100, -60450, -47940, -48079, -39545, -35476, -35737, -35992, -36243, -36489, -36730, -36966, -37198, -37425, -37648, -37866, -38080];
}

[DebuggerDisplay("{Year} {Amount}")]
public record LineModel(int Year, decimal Amount);
