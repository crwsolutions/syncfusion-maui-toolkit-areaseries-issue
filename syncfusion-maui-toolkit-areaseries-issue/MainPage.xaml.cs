using syncfusion_maui_toolkit_areaseries_issue.ViewModels;

namespace syncfusion_maui_toolkit_areaseries_issue
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel )
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
