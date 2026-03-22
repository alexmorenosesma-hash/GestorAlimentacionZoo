using CommunityToolkit.Mvvm.ComponentModel;
using System.Globalization;

namespace Client.Pagemodel.Login;

public partial class LoginPagemodel : ObservableObject
{
	[ObservableProperty]
	string username;
	[ObservableProperty]
	string password;
	public LoginPagemodel()
	{ 
	}
}