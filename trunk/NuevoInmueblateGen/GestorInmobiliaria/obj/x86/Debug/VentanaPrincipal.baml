   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	    GestorInmobiliaria)   #GestorInmobiliaria.VentanaPrincipal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  InmuÉblate��5   	   $	��561��6   $	��842��6)    � 
ResizeMode$ NoResize=�65    � WindowState$ 	Maximized=�6K   ���	#FFD1D6CF � WindowStyle$
 None=�6z   .��5	      � ��6   Z�  � RowDefinitions 5
   
   �� 5      $	��190 �6   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      $	��230 �6   �� 5      $
��100* �6   .+�5   
   � $��0��6   $��0��6   $��2��6,    5      �� 5      $	��140 �6    �� 5      $��50 �6     5      �� 5      $	��200 �6#   �� 5      $
��100* �6#   �� 5      $	��200 �6#   .+�5      �� $��0��6   $��3��6(   $��0��6<      NaranjaCabecera#��[  6I   6s   �� 5      $��Inmuéblate��6   $��0��6)   $��0��66   $
��Auto��6F   $��Center=�6T   $��Center=�6q   
�������$��28(�6�   �� 5       $��0��6:   $��1��6G   $
��Auto��6W   $��Center=�6e   $��Center=�6�   
���   �$
��Bold"�6�   $��28(�6�   ��6   �� *CurrentPage.Title+6�   �� 5!      $��	Moderador��6   $��0��6(   $��2��65   $
��Auto��6E   $��Right=�6S   $��Bottom=�6o   $��	0,0,20,20q�6�   
���   �$��18(�6�   �� 5"      -   5        $��label4��5"   �   $��1��64   $��0��6A   $��3��6Q   $��30��6e   $
��Left=�6q   $��50,0,0,0q�6�   $��Center=�6�   $��Center=�6�   ��6   �� *Breadcrumbs+6�   5$       � 5&   
   -   5          �Name$ frameContenido��5&        � NavigationUIVisibility$ Hidden=�6(   $��	0,0,50,50q�6H   $��1��6�   $��1��6�   ��6[   �� *CurrentPage+ �� Mode$ OneWay=���6�   Z�  � 5'   
   -   5        $ 	frameMenu��5'   8   $	��Top=�6   $��0��6(   $��1��6{   $��5q�6�   ��6K   �� *CurrentPageNav+$ OneWay=���6�   Z� ��6�   Z� �� 5)   
   -   5        	 ��Name$	 	btnCerrar��5)      $�� ��6$   $��Right=�6/   $��0,0,0,16q�6K     BotonCerrar#���  6]   $��32��6�   $��1��6�   $��2��6�   �� 5+   
   -   5        $��button3��5+   j   $��Volver��6   $��15(�6"   $��40��60   $
��Left=�6<   $��	50,0,0,50q�6W   $��Bottom=�6y   $	��130��6�   $��2��6�   .   (System.Windows.Interactivity.Interaction
   Triggers
 5,      /   )System.Windows.Interactivity.EventTrigger  5-         	EventName$ Click��6!   .   (System.Windows.Interactivity.TriggerBase   Actions. 5.      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *VolverCommand+5/      51      52      53      