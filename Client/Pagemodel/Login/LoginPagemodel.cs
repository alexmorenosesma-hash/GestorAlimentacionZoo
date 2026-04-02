using Aplication.Interfaces.Firebase.Authentication;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;

namespace Client.Pagemodel.Login;

public partial class LoginPagemodel : ObservableObject
{
	[ObservableProperty]
	string _username;
	[ObservableProperty]
	string _password;
	IAuthService _auth;
    public LoginPagemodel(IAuthService auth)
	{ 
		_auth = auth;
	}
    
    [RelayCommand]
    public async Task registrar()
    {
        try
        {
            await _auth.registerAsync(Username, Password);
            await Application.Current.MainPage.DisplayAlertAsync("OK", "Usuario creado", "Aceptar");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlertAsync("Error", ex.Message, "OK");
        }
    }
}