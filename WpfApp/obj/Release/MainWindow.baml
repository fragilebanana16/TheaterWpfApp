   M S B A M L   `   `   `  ???? A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  =#clr-namespace:WpfApp.MVVM.ViewModelWpfApp.MVVM.ViewModel      WpfApp.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:WpfApp     9	viewModel#clr-namespace:WpfApp.MVVM.ViewModel     S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  -     ? Title$  
MainWindow??$	??600??$	??920?? ? WindowStyle$
 None=? ? 
ResizeMode$ NoResize=?
??????  ? AllowsTransparency .  ? 	Resources  ?? 
TargetType   ButtonStyle1 ?? Property ?? Value??%E   &	        ?? " ??.???  ? ??
 ??  ???  ? ??$ 24(? ? DataContext )  #WpfApp.MVVM.ViewModel.MainViewModel  .???? ???#666678	 ?? CornerRadius$	 10??._?? 
 ? ColumnDefinitions
 ?? $	??200 ???  ? RowDefinitions ?? $??75 ??? .+??? $
??YOLO??
???????$
??Left=?$??Center=?$??30(?$??Segoe UI Black)?$??10,0,0,0q??? $??1??.+?	? $
??Home??$??50??
???????$??22(?  MenuButtonTheme#??[  d? 	IsChecked$
 TrueY????? *HomeViewCommand+	? $??Movie??$??50??
???????$??22(?#??[ ???? *MovieViewCommand+	? $??Other??$??50??
???????$??22(?#??[ ???? *OtherViewCommand+??   ModernTextBox#??[ 
???????$??1??$??0??$	??250??$??50??$??Center=?$
??Left=??? $??1??$??1??$??10q????? *CurrentView+