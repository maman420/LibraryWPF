using Microsoft.Extensions.DependencyInjection;
using LibraryProj;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LibraryProj.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryProj
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create a new instance of the DbContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            // Set the database provider and connection string
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Library;Trusted_Connection=True;");

            // Create a new instance of the DataContext using the configured options
            var context = new DataContext(optionsBuilder.Options);

            // Create a new instance of the DI container
            var serviceProvider = new ServiceCollection()
                .AddTransient<ILibraryService, LibraryService>()
                .AddSingleton(context)
                .BuildServiceProvider();

            // Get the MainWindow instance and set its DataContext to the DI container
            var mainWindow = new MainWindow(serviceProvider.GetRequiredService<ILibraryService>());
            mainWindow.DataContext = mainWindow;

            // Show the MainWindow
            mainWindow.Show();
        }
    }
}
