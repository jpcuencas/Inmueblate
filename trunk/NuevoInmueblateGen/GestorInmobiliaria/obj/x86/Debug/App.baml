   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   &    GestorInmobiliaria   GestorInmobiliaria.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6K   5my&clr-namespace:System;assembly=mscorlib     5   &     �� 	Resources  5         BotonCerrar �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   To	   
Storyboard
 �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   States   System.Windows.VisualState   
Storyboard ��Name J� RenderTransformOrigin �� Angle J� SnapsToDevicePixels �� Triggers P� Property P� Value  TamFuenteDetalle  AnchoBotonNumero  NaranjaCabecera  
BordeTabla  BordeNaranjaTabla  FondoGrisTabla��%�	  &	        &	 �    &	 	    &	 .	    &	 O	    &	 h	    &	 �	    �� 5      " ��6!   .�5	      ��  � �� 5
   	   �� 5   
   " ��6   .R�5      �  5        5      CommonStates�� 5        5      $ 0D�6    $ Pressed��66   .	 5      �� .��5      �� $*
 $(Shape.Fill).(SolidColorBrush.Color)�6.   $ 	rectangle��6o   .g�5        $ 0��6&   $ 	#FF267B7F��62     5      $ 0:0:0.2��6&   $ 	#FF267B7F��68   5      U� 5      $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6/   $ 	rectangle��6�   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.2��6'   $
 0.85Q�69   5      U� 5      $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6/   $ 	rectangle��6�   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.2��6'   $
 0.85Q�69   5      5      5      . 5!        
Normal��6     5"      	MouseOver��. 5#      �� .��5$      �� $*
 $(Shape.Fill).(SolidColorBrush.Color)�6-   $ 	rectangle��6n   .g�5%        $ 0��6%   $ 	#FF267B7F��61   5&      5'      5(        5)      Pressed��6     5*      Disabled��6   5+      .+�5-      �� $ 	rectangle��6   ���	#FF3AB9BF$
��Left=�6:   
���   �$��32��6d   $��32��6o   $	��Top=�6{   $ 0.5,0.5&�6�   z�5.      V� 5/      .~�50      �� �� 51      �� 52      T� 53      54      56      �� 57      
���   �$
��Left=�6#   $��1,13,0,0q�6>   
���   �$��30��6_   $ 0.5,0.5&�6j   $��5��6�   $��5��6�   $	��Top=�6�   z�58      V� 59      .~�5:      �� �� 5;      �� 5<      $ 45Q�6   T� 5=      5>      5@      �� 5A      
���   �$
��Left=�6#   $��1,13,0,0q�6>   
���   �$��30��6_   $ 0.5,0.5&�6j   $��5��6�   $��5��6�   $	��Top=�6�   z�5B      V� 5C      .~�5D      �� �� 5E      �� 5F      $	 -45Q�6   T� 5G      5H      5J      �� 5M      #��z��6   ��. # z 6{   #��z��6�   5N       5O      P� 5P       �@J�	IsFocused . 6)   P� 5Q       �@��IsDefaulted . 6+   P� 5R       �@J�IsMouseOver . 6+   P� 5S       � �� . 6)   P� 5T       � {� .  6)   5V      5X   	   5Y      X�5Z      15Q�6-   X�5[      50Q�6-   ��5\      	#FFDD4814��69   X�5]      3Q�6&   ��5^      	#FFFF934D��6;   ��5_      	#FFF5F5F5��68   5`      5a      