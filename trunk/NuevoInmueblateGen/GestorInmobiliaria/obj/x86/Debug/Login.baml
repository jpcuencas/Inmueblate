   M S B A M L   `   `   `  ����  GestorInmobiliaria    GestorInmobiliaria.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F     � Title$  Login��5   	   $	��250��6   $	��320��6$    � AllowsTransparency .  � WindowStyle$
 None=�5   	   
������  � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5         
Boton_Over  BotonAccederLogin �� 
TargetType �� Property �� Value	 �� 
TargetType'  !System.Windows.VisualStateManager
   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   To   
Storyboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value   States   System.Windows.VisualState   
Storyboard ��Name J� RenderTransformOrigin �� EndPoint �� 
StartPoint � Color � Offset J� SnapsToDevicePixels J� OpacityMask �� Triggers  P� Property! P� Value��%
  &	        &	      �� 5	      6   �� 5
      " ��6$   .�5      ��  � �� 5      �� 5      "	 ��6   .R�5      � 
 5   	     5   
   CommonStates�� 5        5      $ 0D�6   $ Pressed��63   . 5      �� .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ btnAccederLogin��6�   .\�5        $ 0��6$   $ 1Q�60     5      $ 0:0:0.3��6$   $
 0.85Q�66   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ btnAccederLogin��6�   .\�5        $ 0��6$   $ 1Q�60     5      $ 0:0:0.3��6$   $
 0.85Q�66   5      �� 5      $H B(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6+   $ btnAccederLogin��6�   .g�5        $ 0��6#   $ 	#FFA9ADA7��6/     5      $ 0:0:0.3��6#   $ 	#FFA9ADA7��65   5      �� 5       $H B(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6+   $ btnAccederLogin��6�   .g�5!        $ 0��6#   $ 	#FF878A85��6/     5"      $ 0:0:0.3��6#   $ 	#FF878A85��65   5#      5$      5%      . 5'        
Normal��6     5(      	MouseOver��. 5)      �� .��5*      �� $H B(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6*   $ btnAccederLogin��6�   .g�5+        $ 0��6"   $ 	#FF878A85��6.   5,      �� 5-      $H B(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6*   $ btnAccederLogin��6�   .g�5.        $ 0��6"   $ 	#FFA9ADA7��6.   5/      50      51        52      Pressed��6     53      Disabled��6   54      .+�56   	   �� $ btnAccederLogin��6   $ 0.494,0.467&�6,   
���   �z�57   
   V� 58      .~�59      �� �� 5:      �� 5;      T� 5<      5=      ��5?   
   �� 5@      $ 0.5,1&�6   $ 0.5,0&�60   .��5A      � $ 	#FFA9ADA7��6   $ 0.727Q�6+   � 5B      $ 	#FFD1D6CF��6   $	 0.4Q�6+   5C      5E   
   �� 5F   	   #��z��6   ��. # z 6x   #��z��6�    5G   
   �� 5H      $ 0.5,1&�6   $ 0.5,0&�60   .��5I      � $ Black��6   $ 0Q�6'   � 5J      $ White��6   $ 1Q�6'   5K      5M   
   5N   	    5O      P� 5P   	     �@J�	IsFocused! . 6&   P� 5Q   	     �@��IsDefaulted! . 6(   P� 5R   	     �@J�IsMouseOver! . 6(   P� 5S   	     � ��! . 6&   P� 5T   	     � {�! .  6&   5V      5X      5Y      5Z      " � Triggers" 5[      :� 5\      # :� RoutedEvent$# FrameworkElement.Loaded��6   .[�5]      �� #��[  6   5^      .��5`      �� $ �� CornerRadius$$ 	50,0,50,0��6   ��5c   
   �� 5d      $ 0.5,1&�6"   $ 0.5,0&�63   .��5e      � $ 	#FFD97D4A��6   $ 0.331Q�61   � 5f      $ 	#FFFF934D��6   $ 0.735Q�61   5g      ._�5j   
   � % � RowDefinitions% 5k      �� 5l      $
��auto �6    �� 5m      $
��auto �6    �� 5n      $
��auto �6    $��40��6.   �� 5o      .+�5q      �� -   5        & ��Name$& label3��5q   W   $��0��6   $��28��6!   $��Center=�6-   $��10q�6K   $��InmuÉblate��6g   $��16(�6|   ���	#FF1F6366$
��Bold"�6�   � 5r      $	��104��6   $��1��6    $	��Top=�6-   ' � ColumnDefinitions' 5s      �� 5t      $	��100 �6'   �� 5u      $	��200 �6'   % 5w      �� 5x      $	��50* �6$   �� 5y      $	��50* �6$   .+�5|      �� -   5        $& label1��5|   �   $��0��6   $��0��6.   $��28��6;   $��Right=�6G   $��Center=�6c   $��10q�6~   $��Usuario:��6�   ���	#FF1F6366$
��Bold"�6�   $��13.333(�6�   �� 5}      -   5        $& label2��5}   �   $��0��6   $��1��6.   $��28��6;   $��Right=�6G   $��Center=�6c   $��10q�6~   $��Contraseña:��6�   ���	#FF1F6366$
��Bold"�6�   $��13.333(�6�   �� 5~      -   5        ( ��Name$( 
txtUsuario��5~   C   $��1��6   $��10,15,10,14q�6.   6C   G� 5      -   5        ) G�Name$) pwdContrasena��5   P   $��1��6   $��1��6.   $��10,14,10,15q�6;   6P   5�      �� 5�      -   5        $& lblError��5�   -   $��3��6   $�� ��6!   $��Center=�6?   $	��Top=�6c   $��0,8,0,26q�6�   ���	#FF1F6366$��Italic$�6�   �� 5�      -   5        * ��Name$* 	btnCerrar��5�      $�� ��6(   $��Right=�63   $��0,0,0,16q�6O     BotonCerrar#���  6a   $��32��6�   6�   �� 5�      -   5        $* btnAccederLogin��5�      $��Acceder��6.   $��112.217,4,82.783,6q�6@   $��2��6\   #���  6i   $��13.333(�6�   $
��Bold"�6�   + �� 	IsDefault+ . 6�   5�      5�      5�      