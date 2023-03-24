using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace ForgeExplorer
{
    public class Application : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // add new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Forge Explorer");

            // Get dll assembly path
            string assembly = Assembly.GetExecutingAssembly().Location;

            //Create a push button in the ribbon panel
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("ForgeExplorer",
                "Forge Explorer", assembly, typeof(Commands.ExplorerCommand).FullName)) as PushButton;

            // create bitmap image and assign it to button
            pushButton.LargeImage = new BitmapImage(
                new Uri("/ForgeExplorer;component/Resources/open-folder_32x32.png", UriKind.RelativeOrAbsolute));

            // assign a small bitmap to button which is used if command
            // is moved to Quick Access Toolbar
            pushButton.Image = new BitmapImage(
                new Uri("/ForgeExplorer;component/Resources/open-folder_16x16.png", UriKind.RelativeOrAbsolute));

            pushButton.ToolTip = "Explore the data across BIM 360 Team, " +
                "Fusion Team (formerly known as A360 Team), " +
                "BIM 360 Docs and A360 Personal.";

            return Result.Succeeded;
        }
    }
}
