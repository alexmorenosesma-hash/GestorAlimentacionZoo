using Aplication.Interfaces.Repositories;
using Client.Pagemodel.Popups;
using Client.Popups;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Services;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using System.Collections.ObjectModel;

namespace Client.Pagemodel.Inventarios;

public partial class EspeciePagemodel : ObservableObject
{
	IEspecieRepository _repository;
    IPopupService _popup;

	[ObservableProperty]
	ObservableCollection<Especie> _especies=new();

    public EspeciePagemodel(IEspecieRepository repository,IPopupService popup)
	{
		_repository = repository;
        _popup= popup;
        cargarEspecies();

    }

    [RelayCommand]
    public async Task cargarEspecies()
    {
        var especies = await _repository.ObtenerEspecies();
        Especies = new ObservableCollection<Especie>(
            especies.Where(e =>
                e != null &&
                !string.IsNullOrWhiteSpace(e.idEspecie) &&
                !string.IsNullOrWhiteSpace(e.nombre)
            )
        );

    }
    [RelayCommand]
    public async Task abrirPopupAñadir()
    {
        var result = await _popup.ShowPopupAsync<EspeciePopupPagemodel, Especie>(
            Application.Current.MainPage,
            PopupOptions.Empty,
            CancellationToken.None
        );

        if (result.Result is Especie nueva)
        {
            await _repository.CrearEspecie(nueva);
            Especies.Add(nueva);
            await cargarEspecies();
        }
    }
    [RelayCommand]
    public async Task abrirPopupModificar(Especie especie)
    {
        var vm = new EspecieModificarPopupPagemodel(_popup);

        vm.Model = new Especie
        {
            idEspecie = especie.idEspecie,
            nombre = especie.nombre,
            nombreCientifico = especie.nombreCientifico,
            tipoAlimentacion = especie.tipoAlimentacion
        };

        var popup = new EspecieModificarPopup(vm);

        await Application.Current.MainPage.ShowPopupAsync(
            popup,
            PopupOptions.Empty,
            CancellationToken.None
        );

        var modificada = vm.Model;

        await _repository.EditarEspecie(modificada.idEspecie, modificada);
        await cargarEspecies();
    }

    [RelayCommand]
    public async Task abrirPopupEliminar(Especie especie)
    {
        var mensaje = $"¿Estás seguro de que deseas eliminar la especie {especie.nombre}?";

        var vm = new EliminarPopupPagemodel(_popup, mensaje);
        var popup = new EliminarPopup(vm);


        var result = await Application.Current.MainPage.ShowPopupAsync(popup);
        var resultType = result.GetType();
        var prop = resultType.GetProperty("Result");
        var data = prop?.GetValue(result) as Confirmar;

        var confirmado = data?.opcion ?? false;

        if (confirmado)
        {
            await _repository.EliminarEspecie(especie.idEspecie);
            await cargarEspecies();
        }
    }

    [RelayCommand]
    public async Task volver()
    {
        await Shell.Current.GoToAsync("//MenuPage");
    }

}