using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.Shared.Shared
{   
    public partial class MainLayout
    {
        [Inject]
        public NavigationManager MyNavigationManager { get; set; }

        protected bool IsWasm { get; set; } = false;

        protected override void OnInitialized()
        {
            currentTheme = defaultTheme;

            IsWasm = MyNavigationManager.Uri.Contains("localhost:44360");

            if(IsWasm)
            {
                currentTheme = darkTheme;
            }
        }        

        MudTheme currentTheme = new();
        
        readonly MudTheme defaultTheme = new()
        {
            Palette = new Palette()
            {
                Black = "#272c34"
            }
        };
        
        readonly MudTheme darkTheme = new()
        {
            Palette = new Palette()
            {
                Black = "#27272f",
                Background = "#32333d",
                BackgroundGrey = "#27272f",
                Surface = "#373740",
                DrawerBackground = "#27272f",
                DrawerText = "rgba(255,255,255, 0.50)",
                DrawerIcon = "rgba(255,255,255, 0.50)",
                AppbarBackground = "#27272f",
                AppbarText = "rgba(255,255,255, 0.70)",
                TextPrimary = "rgba(255,255,255, 0.70)",
                TextSecondary = "rgba(255,255,255, 0.50)",
                ActionDefault = "#adadb1",
                ActionDisabled = "rgba(255,255,255, 0.26)",
                ActionDisabledBackground = "rgba(255,255,255, 0.12)",
                Divider = "rgba(255,255,255, 0.12)",
                DividerLight = "rgba(255,255,255, 0.06)",
                TableLines = "rgba(255,255,255, 0.12)",
                LinesDefault = "rgba(255,255,255, 0.12)",
                LinesInputs = "rgba(255,255,255, 0.3)",
                TextDisabled = "rgba(255,255,255, 0.2)"
            }
        };
    }
}
