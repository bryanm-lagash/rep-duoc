   M S B A M L   `   `   `  ����G  COnTourWPF2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:OnTourWPF2._0OnTourWPF2._0  5   	       OnTourWPF2._0.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   V RMaterialDesignThemes.Wpf, Version=2.6.0.1366, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   'localclr-namespace:OnTourWPF2._0  5   	   -   5          � Title$  
MainWindow��5
   	   $	��700��6    � AllowsTransparency . $
��1300��6D    � WindowStyle$
 None=�6Q    � WindowStartupLocation$ CenterScreen=�6d    � 
ResizeMode$ NoResize=�6�    � WindowState$ 	Maximized=�6�   ��6�   Z�  � 	Resources 5         gridMain �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame	 �� KeyTime
 �� Value��%#  &	        �� 5   
   .��5      �� $0 *(Panel.Background).(SolidColorBrush.Color)�6+   $
 grid��6r   .g�5        $	 0��6&   $
 	#02000000��62     5      $	 0:0:0.2��6&   $
 	#0C000000��68     5      $	 0:0:0.4��6&   $
 	#19000000��68     5      $	 0:0:0.6��6&   $
 	#26000000��68     5      $	 0:0:0.8��6&   $
 	#33000000��68     5      $	 0:0:1��6&   $
 	#3F000000��66     5      $	 0:0:1.2��6&   $
 	#4C000000��68     5      $	 0:0:1.4��6&   $
 	#59000000��68     5      $	 0:0:1.6��6&   $
 	#66000000��68     5      $	 0:0:1.8��6&   $
 	#72000000��68     5      $	 0:0:2��6&   $
 	#7F000000��66   5      �� 5      $0 *(Panel.Background).(SolidColorBrush.Color)�6+   $ btnIngresar��6r   .g�5        $	 0��6&   $
 	#00000000��62     5      $	 0:0:0.2��6&   $
 	#19000000��68     5      $	 0:0:0.4��6&   $
 	#33000000��68     5      $	 0:0:0.6��6&   $
 	#4C000000��68     5      $	 0:0:0.8��6&   $
 	#66000000��68     5       $	 0:0:1��6&   $
 	#7F000000��66     5!      $	 0:0:1.2��6&   $
 	#99000000��68     5"      $	 0:0:1.4��6&   $
 	#B2000000��68     5#      $	 0:0:1.6��6&   $
 	#CC000000��68     5$      $	 0:0:1.8��6&   $
 	#E5000000��68     5%      $	 0:0:2��6&   $
 Black��66   5&      �� 5'      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ btnIngresar��6x   .g�5(        $	 0��6&   $
 	#00CBCBCB��62     5)      $	 0:0:0.2��6&   $
 	#19CBCBCB��68     5*      $	 0:0:0.4��6&   $
 	#33CBCBCB��68     5+      $	 0:0:0.6��6&   $
 	#4CCBCBCB��68     5,      $	 0:0:0.8��6&   $
 	#66CBCBCB��68     5-      $	 0:0:1��6&   $
 	#7FCBCBCB��66     5.      $	 0:0:1.2��6&   $
 	#99CBCBCB��68     5/      $	 0:0:1.4��6&   $
 	#B2CBCBCB��68     50      $	 0:0:1.6��6&   $
 	#CCCBCBCB��68     51      $	 0:0:1.8��6&   $
 	#E5CBCBCB��68     52      $	 0:0:2��6&   $
 	#FFCBCBCB��66   53      �� 54      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ packIcon��6x   .g�55        $	 0��6&   $
 	#00313E46��62     56      $	 0:0:0.2��6&   $
 	#19313E46��68     57      $	 0:0:0.4��6&   $
 	#33313E46��68     58      $	 0:0:0.6��6&   $
 	#4C313E46��68     59      $	 0:0:0.8��6&   $
 	#66313E46��68     5:      $	 0:0:1��6&   $
 	#7F313E46��66     5;      $	 0:0:1.2��6&   $
 	#99313E46��68     5<      $	 0:0:1.4��6&   $
 	#B2313E46��68     5=      $	 0:0:1.6��6&   $
 	#CC313E46��68     5>      $	 0:0:1.8��6&   $
 	#E5313E46��68     5?      $	 0:0:2��6&   $
 	#FF313E46��66   5@      �� 5A      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ 	packIcon1��6x   .g�5B        $	 0��6&   $
 	#007296A2��62     5C      $	 0:0:0.2��6&   $
 	#197296A2��68     5D      $	 0:0:0.4��6&   $
 	#337296A2��68     5E      $	 0:0:0.6��6&   $
 	#4C7296A2��68     5F      $	 0:0:0.8��6&   $
 	#667296A2��68     5G      $	 0:0:1��6&   $
 	#7F7296A2��66     5H      $	 0:0:1.2��6&   $
 	#997296A2��68     5I      $	 0:0:1.4��6&   $
 	#B27296A2��68     5J      $	 0:0:1.6��6&   $
 	#CC7296A2��68     5K      $	 0:0:1.8��6&   $
 	#E57296A2��68     5L      $	 0:0:2��6&   $
 	#FF7296A2��66   5M      �� 5N      $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ txtContraseña��6t   .g�5O        $	 0��6&   $
 Transparent��62     5P      $	 0:0:0.2��6&   $
 	#19FFFFFF��68     5Q      $	 0:0:0.4��6&   $
 	#33FFFFFF��68     5R      $	 0:0:0.6��6&   $
 	#4CFFFFFF��68     5S      $	 0:0:0.8��6&   $
 	#66FFFFFF��68     5T      $	 0:0:1��6&   $
 	#7FFFFFFF��66     5U      $	 0:0:1.2��6&   $
 	#99FFFFFF��68     5V      $	 0:0:1.4��6&   $
 	#B2FFFFFF��68     5W      $	 0:0:1.6��6&   $
 	#CCFFFFFF��68     5X      $	 0:0:1.8��6&   $
 	#E5FFFFFF��68     5Y      $	 0:0:2��6&   $
 White��66   5Z      �� 5[      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ txtContraseña��6x   .g�5\        $	 0��6&   $
 	#007296A2��62     5]      $	 0:0:0.2��6&   $
 	#197296A2��68     5^      $	 0:0:0.4��6&   $
 	#337296A2��68     5_      $	 0:0:0.6��6&   $
 	#4C7296A2��68     5`      $	 0:0:0.8��6&   $
 	#667296A2��68     5a      $	 0:0:1��6&   $
 	#7F7296A2��66     5b      $	 0:0:1.2��6&   $
 	#997296A2��68     5c      $	 0:0:1.4��6&   $
 	#B27296A2��68     5d      $	 0:0:1.6��6&   $
 	#CC7296A2��68     5e      $	 0:0:1.8��6&   $
 	#E57296A2��68     5f      $	 0:0:2��6&   $
 	#FF7296A2��66   5g      �� 5h      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ label2��6x   .g�5i        $	 0��6&   $
 	#00CBCBCB��62     5j      $	 0:0:0.2��6&   $
 	#19CBCBCB��68     5k      $	 0:0:0.4��6&   $
 	#33CBCBCB��68     5l      $	 0:0:0.6��6&   $
 	#4CCBCBCB��68     5m      $	 0:0:0.8��6&   $
 	#66CBCBCB��68     5n      $	 0:0:1��6&   $
 	#7FCBCBCB��66     5o      $	 0:0:1.2��6&   $
 	#99CBCBCB��68     5p      $	 0:0:1.4��6&   $
 	#B2CBCBCB��68     5q      $	 0:0:1.6��6&   $
 	#CCCBCBCB��68     5r      $	 0:0:1.8��6&   $
 	#E5CBCBCB��68     5s      $	 0:0:2��6&   $
 	#FFCBCBCB��66   5t      �� 5u      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ 
txtUsuario��6x   .g�5v        $	 0��6&   $
 	#007296A2��62     5w      $	 0:0:0.2��6&   $
 	#197296A2��68     5x      $	 0:0:0.4��6&   $
 	#337296A2��68     5y      $	 0:0:0.6��6&   $
 	#4C7296A2��68     5z      $	 0:0:0.8��6&   $
 	#667296A2��68     5{      $	 0:0:1��6&   $
 	#7F7296A2��66     5|      $	 0:0:1.2��6&   $
 	#997296A2��68     5}      $	 0:0:1.4��6&   $
 	#B27296A2��68     5~      $	 0:0:1.6��6&   $
 	#CC7296A2��68     5      $	 0:0:1.8��6&   $
 	#E57296A2��68     5�      $	 0:0:2��6&   $
 	#FF7296A2��66   5�      �� 5�      $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ 
txtUsuario��6t   .g�5�        $	 0��6&   $
 Transparent��62     5�      $	 0:0:0.2��6&   $
 	#19FFFFFF��68     5�      $	 0:0:0.4��6&   $
 	#33FFFFFF��68     5�      $	 0:0:0.6��6&   $
 	#4CFFFFFF��68     5�      $	 0:0:0.8��6&   $
 	#66FFFFFF��68     5�      $	 0:0:1��6&   $
 	#7FFFFFFF��66     5�      $	 0:0:1.2��6&   $
 	#99FFFFFF��68     5�      $	 0:0:1.4��6&   $
 	#B2FFFFFF��68     5�      $	 0:0:1.6��6&   $
 	#CCFFFFFF��68     5�      $	 0:0:1.8��6&   $
 	#E5FFFFFF��68     5�      $	 0:0:2��6&   $
 White��66   5�      �� 5�      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ 	packIcon2��6x   .g�5�        $	 0��6&   $
 	#007296A2��62     5�      $	 0:0:0.2��6&   $
 	#197296A2��68     5�      $	 0:0:0.4��6&   $
 	#337296A2��68     5�      $	 0:0:0.6��6&   $
 	#4C7296A2��68     5�      $	 0:0:0.8��6&   $
 	#667296A2��68     5�      $	 0:0:1��6&   $
 	#7F7296A2��66     5�      $	 0:0:1.2��6&   $
 	#997296A2��68     5�      $	 0:0:1.4��6&   $
 	#B27296A2��68     5�      $	 0:0:1.6��6&   $
 	#CC7296A2��68     5�      $	 0:0:1.8��6&   $
 	#E57296A2��68     5�      $	 0:0:2��6&   $
 	#FF7296A2��66   5�      �� 5�      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ label1��6x   .g�5�        $	 0��6&   $
 	#00CBCBCB��62     5�      $	 0:0:0.2��6&   $
 	#19CBCBCB��68     5�      $	 0:0:0.4��6&   $
 	#33CBCBCB��68     5�      $	 0:0:0.6��6&   $
 	#4CCBCBCB��68     5�      $	 0:0:0.8��6&   $
 	#66CBCBCB��68     5�      $	 0:0:1��6&   $
 	#7FCBCBCB��66     5�      $	 0:0:1.2��6&   $
 	#99CBCBCB��68     5�      $	 0:0:1.4��6&   $
 	#B2CBCBCB��68     5�      $	 0:0:1.6��6&   $
 	#CCCBCBCB��68     5�      $	 0:0:1.8��6&   $
 	#E5CBCBCB��68     5�      $	 0:0:2��6&   $
 	#FFCBCBCB��66   5�      �� 5�      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ label��6x   .g�5�        $	 0��6&   $
 	#00CBCBCB��62     5�      $	 0:0:0.2��6&   $
 	#19CBCBCB��68     5�      $	 0:0:0.4��6&   $
 	#33CBCBCB��68     5�      $	 0:0:0.6��6&   $
 	#4CCBCBCB��68     5�      $	 0:0:0.8��6&   $
 	#66CBCBCB��68     5�      $	 0:0:1��6&   $
 	#7FCBCBCB��66     5�      $	 0:0:1.2��6&   $
 	#99CBCBCB��68     5�      $	 0:0:1.4��6&   $
 	#B2CBCBCB��68     5�      $	 0:0:1.6��6&   $
 	#CCCBCBCB��68     5�      $	 0:0:1.8��6&   $
 	#E5CBCBCB��68     5�      $	 0:0:2��6&   $
 	#FFCBCBCB��66   5�      5�      5�       � Triggers 5�      :� 5�   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5�      �� #��[  6   5�      .��5�      � $��0,0,0,0q�6   .+�5�   
   �� $2��,Logos/michal-parzuchowski-37537-unsplash.jpg��6   $��UniformToFill=�6F   �� 5�   
   -   5        $��30��5�      $��30��6   $	��Top=�6(   $��Right=�6@   
������ 
������ .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.1366, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6&   $��	-7,0,-9,0q�63   ���	#FF5E778D6_   5�      �� 5�   
   -   5        $��30��5�      $��30��6   $	��Top=�6(   $��Right=�6@   
������ 
������ $��0,0,30,0q�6�   .��5�        $ WindowMaximize=�6&   $��	-7,0,-9,0q�6<   ���	#FF5E778D6O   5�      �� 5�   
   -   5        $��30��5�      $��30��6   $	��Top=�6(   $��Right=�6@   
������ 
������ $��0,0,60,0q�6�   .��5�        $ WindowMinimize=�6&   $��	-7,5,-9,0q�6<   ���	#FF5E778D6O   5�      � 5�   
   -   5         �Name$
 grid��5�      $��483,148,479,150q�6   ���	#83000000$	��338��6M   $	��400��6\   .+�5�      �� -   5         ��Name$ label��5�      $��Iniciar Sesión��6#   $y�Visible=�6<   $
��Bold"�6Q   $��18(�6c   $��38��6q   $��102,0,0,341q�6}   $��Bottom=�6�   ���	#FFCBCBCB$
��Left=�6�   $	��162��6�   ��6�   Z� 6�   �� 5�      -   5        $ label1��5�      $��Usuario��6$   $y�Visible=�66   $��102,0,0,270q�6K   ���	#FFCBCBCB$��16(�6w   $��28��6�   $��Bottom=�6�   $
��Left=�6�   $	��111��6�   �� 5�      -   5        $ label2��5�      $��Contraseña��6$   $y�Visible=�69   $��102,0,0,135q�6N   ���	#FFCBCBCB$��16(�6z   $��28��6�   $��Bottom=�6�   $
��Left=�6�   $	��155��6�   ��6�   Z� �� 5�      -	   5         ��Name$ 
txtUsuario��5�      $��102,0,0,224q�6*    % !MaterialDesignFloatingHintTextBox#��[ 6?   $y�Visible=�6z    �� TextWrapping$
 Wrap=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre de usuario��6�   ���	#FF7296A2$��14(�6�   ���	#89FFFFFF$��45��6  $��Bottom=�6  $
��Left=�6:  $	��186��6U  6a  G� 5�      -
   5         G�Name$ txtContraseña��5�      $��
102,0,0,91q�61   $y�Visible=�6F   $ Ingrese su contraseña��6\   ���	#FF7296A2���	#89FFFFFF$��14(�6�   $��46��6�   $��Bottom=�6�   $
��Left=�6  $	��186��6(  ��6�   Z� 64  �� 5�      -   5         ��Name$ btnIngresar��5�      $��Ingresar��6*   $y�Visible=�6=   $��53��6R   
���   ����	#FFCBCBCB$��16(�6�   $��Bottom=�6�   $��0,0,0,1q�6  ��6q   Z� 6  �� 5�      $��40��6   $��40��6    $��42,273,256,89q�6,   ._�5�        -   5          Name$ 	packIcon1��5�   *   $ Circle=�6=   $��40��6K   $��40��6V   ���	#FF7296A26{   5�      �� 5�      $��40��6   $��40��6    $��42,273,256,89q�6,   ._�5�        -   5        $ packIcon��5�   *   $	 Key=�6<   $��30��6G   $��30��6R   ���	#FF313E46$��4,4,0,0q�6u   6�   5�      �� 5�      $��40��6   $��40��6    $��42,138,256,224q�6,   ._�5�        -   5        $ 	packIcon2��5�   *   $ 
UserCircle=�6=   $��40��6O   $��40��6Z   ���	#FF7296A26   5�      5�      �� 5�   
   -   5        $��
Apoderados��5�      $��	0,148,0,0q�6&   $	��Top=�69   ���	#7F000000���	#FF7296A2$��Right=�6   $	��137��6�   
���   �6�   �� 5�   
   -   5        $��Admin Sistemas��5�      $��	0,185,0,0q�6*   $	��Top=�6=   ���	#7F000000���	#FF7296A2$��Right=�6�   $	��137��6�   
���   �6�   �� 5�   
   -   5        $��Dueño��5�      $��	0,222,0,0q�6!   $	��Top=�64   ���	#7F000000���	#FF7296A2$��Right=�6z   $	��137��6�   
���   �6�   �� 5�   
   -   5        $��Ejec. Ventas��5�      $��	0,259,0,0q�6(   $	��Top=�6;   ���	#7F000000���	#FF7296A2$��Right=�6�   $	��137��6�   
���   �6�   5�      5�      