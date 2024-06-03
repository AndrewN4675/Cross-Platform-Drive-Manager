using System.Collections.ObjectModel;

public struct Drive
{
    char driveLetter;
    string driveName;
    string driveFormat;
    long totalSize;
    long sizeUsed;
}

namespace Drive_Manager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}

public class JobModel
{
        public ObservableCollection<string> Job { get; set; } = new ObservableCollection<string>()
    {
        "Item 1",
        "Item 2",
        "Item 3",
        "Item 4",
        "Item 5"
    };
}