﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IkemenToolbox.Helpers;
using IkemenToolbox.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace IkemenToolbox.ViewModels
{
    public partial class HomeViewModel : ViewModel
    {
        [ObservableProperty]
        private bool _isEditingDefinitionPath = true;

        [ObservableProperty]
        private string _definitionPath;

        [ObservableProperty]
        private FighterManager _fighterManager = new();

        public void Initialize()
        {
            Cache.Initialize();
            DefinitionPath = Cache.Settings.LastDefinitionPath;
        }

        [RelayCommand]
        private async Task SetDefinitionPathAsync()
        {
            if (string.IsNullOrWhiteSpace(DefinitionPath))
            {
                return;
            }

            DefinitionPath = DefinitionPath.Trim(' ', '"');

            try
            {
                await FighterManager.InitializeAsync(DefinitionPath);
                IsEditingDefinitionPath = false;

                Cache.Settings.LastDefinitionPath = DefinitionPath;
            }
            catch (Exception ex)
            {
                await Dialog.ShowAlertAsync(ex.Message, "Error");
            }
        }

        [RelayCommand]
        private void Edit()
        {
            DefinitionPath = FighterManager.Fighter.DefinitionPath;
            IsEditingDefinitionPath = true;
        }

        [RelayCommand]
        private void Cancel()
        {
            IsEditingDefinitionPath = false;
        }

        [RelayCommand]
        private async Task OpenFolderAsync()
        {
            await FileSystem.OpenFolderAsync(FighterManager.Fighter.FolderPath);
        }
    }
}