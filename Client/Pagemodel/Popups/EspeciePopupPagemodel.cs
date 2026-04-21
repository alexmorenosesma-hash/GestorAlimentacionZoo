using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace Client.Pagemodel.Popups;

public partial class EspeciePopupPagemodel : ObservableObject
{
	[ObservableProperty]
	ObservableCollection<string> _tiposAlimentacion = new ObservableCollection<string> { "Carnívoro", "Herbívoro", "Omnívoro" };

    [ObservableProperty]
	public Especie _model = new()
	{
		idEspecie = null
	};

	IPopupService _popup;
	public EspeciePopupPagemodel(IPopupService popup)
	{
		_popup = popup;
    }

	[RelayCommand]
	async Task Cancel()
	{
		await _popup.ClosePopupAsync(Shell.Current);
	}
	[RelayCommand]
    async Task Save()
	{
		await _popup.ClosePopupAsync(Shell.Current, Model);
    }
}