   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	   =#clr-namespace:WpfApp.MVVM.ViewModelWpfApp.MVVM.ViewModel  5   	       WpfApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   9	viewModel#clr-namespace:WpfApp.MVVM.ViewModel     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   -   5          ? Title$  
MainWindow??5
   	   $	??600??6   $	??920??6)    ? WindowStyle$
 None=?65    ? 
ResizeMode$ NoResize=?6H   
??????  ? AllowsTransparency .  ? 	Resources 5       ?? 
TargetType   ButtonStyle1 ?? Property ?? Value??%x   &	        ?? 5   
   " ??6   .?5      ??  ? ??
 ??  ?6+   ?? 5       ? ??$ 24(?6)   5      5       ? DataContext 5      )  #WpfApp.MVVM.ViewModel.MainViewModel  5   
   5      .??5      ?? ???#666678	 ?? CornerRadius$	 10??6"   ._?5   
   ? 
 ? ColumnDefinitions
 5      ?? 5      $	??200 ?6#   61   ?? 5      6%    ? RowDefinitions 5      ?? 5      $??75 ?6    6.   ?? 5       6"   .+?5#      ?? 
???????$
??Left=?5%      $??Center=?5&      $??30(?5'      $??Segoe UI Black)?5(      $??10,0,0,0q?5)      ??5#      ?? *CurrentUserAccount.Username+5*      ?? 5,      $??1??6   .+?5-      	? $
??Home??6   $??50??6-   
???????$??22(?6L     MenuButtonTheme#??[ 6Z    d? 	IsChecked$
 TrueY?6?   ??6?   ?? *HomeViewCommand+6?   	? 5.      $??Movie??6   $??50??6.   
???????$??22(?6M   #??[ 6[   ??6?   ?? *MovieViewCommand+6?   	? 5/      $??Other??6   $??50??6.   
???????$??22(?6M   #??[ 6[   ??6?   ?? *OtherViewCommand+6?   50      ?? 52        ModernTextBox#??[ 6   
???????$??1??6P   $??0??6`   $	??250??6m   $??50??6y   $??Center=?6?   $
??Left=?6?   6?   ?? 54      $??1??55      $??1??56      $??10q?57      ??58      ?? *CurrentView+5:      5<      5=      5>      