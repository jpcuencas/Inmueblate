   M S B A M L   `   `   `  ����M  IGestorInmobiliaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GestorInmobiliariaGestorInmobiliaria  5      4    .GestorInmobiliaria.views.Eventos.EventoDetalle   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:GestorInmobiliaria     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	        N� Title$  Detalle de un evento��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   .+�5   
   � $��0��6   $��5��6   $��0��63   $��Center=�6@    5      �� 5      $	��160 �6#   �� 5      $
��100* �6#    5!      �� 5"      $��20 �6    �� 5#      $��40 �6    �� 5$      $��40 �6    �� 5%      $��40 �6    �� 5&      $��40 �6    �� 5'      $��40 �6    �� 5(      $��40 �6    �� 5)      $��20 �6    �� 5*      $��40 �6    �� 5+      $��40 �6    �� 5,      $��40 �6    �� 5-      $��40 �6    �� 5.      $��20 �6    .+�51      �� $��0��6   $��0��6%   $��13��65   $��2��6G    �� RadiusX$ 20��6[    �� RadiusY$ 20��6h      BordeNaranjaTabla#��[  6u     FondoGrisTabla#��[ 6�     
BordeTabla#��[ 6�   6�   �� 53      $��20,0,0,0q�6   $��Center=�6&   $��0��6A   $��1��6Q   $��Información del evento��6^   $��2��6   $
��Bold"�6�   $
��Auto��6�   $
��Left=�6�     TamFuenteDetalle#��[ 6�   �� 55      -   5        $��label1��55   l   $��Center=�6   $��0��6/   $��2��6?   $��Nombre:��6L   $
��Auto��6^   $��Right=�6z   #��[ 6�   �� 56      $��2��6/   $��1��6<   $
��Auto��6L   $
��Left=�6Z   $��Center=�6u   #��[ 6�   ��6   �� *Nombre+6�   �� 58      -   5        $��label2��58   q   $��Center=�6   $��0��6/   $��3��6?   $��Descripción:��6L   $
��Auto��6c   $��Right=�6   #��[ 6�   �� 59      $��3��6   $��1��6!   $
��Auto��61   $
��Left=�6_   $��Center=�6z   #��[ 6�   ��6?   �� *Descripcion+6�   �� 5;      -   5        $��label3��5;   o   $��Center=�6   $��0��6/   $��4��6?   $��
Categoria:��6L   $
��Auto��6a   $��Right=�6}   #��[ 6�   �� 5<      $��4��62   $��1��6?   $
��Auto��6O   $
��Left=�6]   $��Center=�6x   #��[ 6�   ��6   �� *	Categoria+6�   �� 5>      -   5        $��label4��5>   k   $��Center=�6   $��0��6/   $��5��6?   $��Fecha:��6L   $
��Auto��6]   $��Right=�6y   #��[ 6�   �� 5?      -   5        $��lblFechaCaducidad��5?   �    �� ContentStringFormat$ 
dd/MM/yyyy��6   $��5��6O   $��1��6\   $
��Auto��6l   $
��Left=�6z   $��Center=�6�   #��[ 6�   ��65   �� *Fecha+6�   �� 5A      -   5        $��label7��5A   r   $��Center=�6   $��0��6/   $��6��6?   $��Inmobiliaria:��6L   $
��Auto��6d   $��Right=�6�   #��[ 6�   �� 5B      $��6��6<   $��1��6I   $
��Auto��6Y   $
��Left=�6g   $��Center=�6�   #��[ 6�   ��6   �� *Inmobiliaria.Nombre+6�   �� 5D      $��0��6   $��2��6(   $��7��6<   6K   �� 5F      $��20,0,0,0q�6   $��Center=�6&   $��0��6A   $��8��6Q   $!��Geolocalización del evento��6^   $��2��6�   $
��Bold"�6�   $
��Auto��6�   $
��Left=�6�   #��[ 6�   �� 5H      -   5        $��label9��5H   q   $��Center=�6   $��0��6/   $��9��6?   $��Coordenadas:��6L   $
��Auto��6c   $��Right=�6   #��[ 6�   �� 5I      $��9��6   $��1��6!   $
��Auto��61   $
��Left=�6?   $��Center=�6Z   #��[ 6u   .��5J      ��  �� Orientation$ 
Horizontal=�6   .+�5K      �� ��6    �� *Geolocalizacion.Longitud+�� 5L      $	�� , ��6    �� 5M      ��6    �� *Geolocalizacion.Latitud+5N      5O      �� 5Q      -   5        $��label10��5Q   p   $��Center=�6   $��0��6/   $��10��6?   $��Dirección:��6M   $
��Auto��6b   $��Right=�6   #��[ 6�   �� 5R      $��10��6   $��1��6"   $
��Auto��62   $
��Left=�6n   $��Center=�6�   #��[ 6�   ��6@   �� *Geolocalizacion.Direccion+6�   �� 5T      -	   5        $��label11��5T   p   $��Center=�6   $��0��6/   $��11��6?   $��Población:��6M   $
��Auto��6b   $��Right=�6   #��[ 6�   �� 5U      $��11��6B   $��1��6P   $
��Auto��6`   $
��Left=�6n   $��Center=�6�   #��[ 6�   ��6   �� *Geolocalizacion.Poblacion+6�   5V      (  "System.Windows.Controls.WebBrowser  5X   
   -
   5        $��webBrowser1��5X   �   $��6��6   $��4��6%   $��0��69   $��2��6F   $��0,100,0,100q�6X   $��Center=�6m   (  "GestorInmobiliaria.BrowserBehavior   BindableSource 6�   �� *Mapa+�� 5Y   
   -   5        $��button1��5Y   h   $��Borrar��6   $��9��6"   $��40��62   $��15(�6>   $��Right=�6L   $��Bottom=�6w   $	��130��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5Z      /  )System.Windows.Interactivity.EventTrigger  5[      	   	EventName$	 Click��6!   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5\      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *EventoBorrarCommand+5]      5^      5`      5a      5b      