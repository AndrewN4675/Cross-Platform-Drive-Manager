using Drive_Manager.DriveUtil;
using Microcharts.Maui;
using Microcharts;
using Microsoft.Maui.Controls;
using SkiaSharp;

namespace Drive_Manager;

public partial class DetailPage : ContentPage
{
    public DetailPage(Drive drive)
    {
        InitializeComponent();
        setTextFields(drive);
        GenerateStorageChart(drive);
    }

    private void setTextFields(Drive drive)
    {
        driveLetter.Text = drive.Letter.ToString();
        driveLabel.Text = drive.Label;
        driveType.Text = drive.Type;
        driveFormat.Text = drive.Format;
        usedStorage.Text = drive.SpaceUsed.ToString("#.##") + " GB";
        availStorage.Text = drive.SpaceAvailable.ToString("#.##") + " GB";
        totalStorage.Text = drive.TotalSize.ToString("#.##") + " GB";
    }

    private void GenerateStorageChart(Drive drive)
    {
        ChartEntry[] entries = {
            new ChartEntry(drive.SpaceUsed)
            {
                Color = SKColor.Parse("#1abc9c"),
                Label = "Used"
            },
            new ChartEntry(drive.SpaceAvailable)
            {
                Color = SKColor.Parse("#6F6F6F"),
                Label = "Free"
            }
        };

        chartView.Chart = new DonutChart{
           BackgroundColor = SKColor.Parse("#1c1c1c"),
           Entries = entries,
           HoleRadius = 0.85f,
           LabelTextSize = 15,
           AnimationDuration = TimeSpan.FromSeconds(0)
        
        };
    }

}