   M S B A M L   `   `   `  ����  GestorInmobiliaria6    0GestorInmobiliaria.views.Entradas.EntradaDetalle   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   !     N� Title$  Detalle de una entrada��6   .��5
      �  � RowDefinitions 5   
   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   .+�5   
   � $��0��6   $��5��6   $��0��63   $��Center=�6@    5      �� 5      $	��160 �6#   �� 5      $
��100* �6#    5       �� 5!      $��20 �6    �� 5"      $��40 �6    �� 5#      $��40 �6    �� 5$      $��40 �6    �� 5%      $��40 �6    �� 5&      $��40 �6    �� 5'      $��40 �6    �� 5(      $��40 �6    �� 5)      $��40 �6    �� 5*      $��20 �6    .+�5-      �� $��0��6   $��0��6%   $��10��65   $��2��6G      BordeNaranjaTabla#��[  6[     FondoGrisTabla#��[ 6�     
BordeTabla#��[ 6�    �� RadiusX$ 20��6�    �� RadiusY$ 20��6�   6�   �� 5/      $��20,0,0,0q�6   $��Center=�6&   $��0��6A   $��1��6Q   $ ��Información de la entrada��6^   $��2��6�   $
��Bold"�6�   $
��Auto��6�   $
��Left=�6�     TamFuenteDetalle#��[ 6�   �� 51      -   5        $��label1��51   l   $��Center=�6   $��0��6/   $��2��6?   $��Título:��6L   $
��Auto��6^   $��Right=�6z   #��[ 6�   �� 52      $��2��6/   $��1��6<   $
��Auto��6L   $
��Left=�6Z   $��Center=�6u   #��[ 6�   ��6   �� *Titulo+6�   �� 54      -   5        $��label2��54   i   $	��Top=�6   $��0��6,   $��3��6<   $��Cuerpo:��6I   $
��Auto��6[   $��Right=�6w   #��[ 6�   �� 55      $��3��6   $��1��6!   $
��Auto��61   $��3��6?   $
��Left=�6P   $	��Top=�6k   #��[ 6�   .��56      �� $
��Wrap=�64   ��6   �� *Cuerpo+64   57      �� 59      -   5        $��label3��59   z   $��Center=�6   $��0��6/   $��6��6?   $��Pendiente de moderar:��6L   $
��Auto��6l   $��Right=�6�   #��[ 6�   �� 5:      $��6��6<   $��1��6I   $
��Auto��6Y   $
��Left=�6g   $��Center=�6�   #��[ 6�   ��6   �� *PendienteModeracion+6�   �� 5<      -   5        $��label4��5<   z   $��Center=�6   $��0��6/   $��7��6?   $��Fecha de publicación:��6L   $
��Auto��6l   $��Right=�6�   #��[ 6�   �� 5=      -   5        $��lblFechaCaducidad��5=   �    �� ContentStringFormat$ 
dd/MM/yyyy��6   $��7��6Z   $��1��6g   $
��Auto��6w   $
��Left=�6�   $��Center=�6�   #��[ 6�   ��65   �� *FechaPublicacion+6�   �� 5?      -   5        $��label5��5?   v   $��Center=�6   $��0��6/   $��8��6?   $��Usuarios MeGusta:��6L   $
��Auto��6h   $��Right=�6�   #��[ 6�   �� 5@      -   5        $��lblUsuariosMeGusta��5@   ~   $��8��68   $��1��6E   $
��Auto��6U   $
��Left=�6c   $��Center=�6�   #��[ 6�   ��6   �� *UsuariosMeGusta+6�   5A      � 5C   
   $��6��6   $��4��6   $��0��63   $��Center=�6@    5D      �� 5E      $	��160 �6#   �� 5F      $
��100* �6#    5H      �� 5I      $��20 �6    �� 5J      $��40 �6    �� 5K      $��40 �6    �� 5L      $��20 �6    .+�5O      �� $��0��6   $��0��6%   $��5��65   $��2��6F   #��[  6Z   #��[ 6�   #��[ 6�   $ 20��6�   $ 20��6�   6�   �� 5Q      $��20,0,0,0q�6   $��Center=�6&   $��0��6A   $��1��6Q   $��Navegación��6^   $��2��6s   $
��Bold"�6�   $
��Auto��6�   $
��Left=�6�   #��[ 6�   �� 5S      -   5        $��label9��5S   m   $��Center=�6   $��0��6/   $��2��6?   $��Creador:��6L   $
��Auto��6_   $��Right=�6{   #��[ 6�   �� 5T      $��2��61   $��1��6>   $
��Auto��6N   $
��Left=�6\   $��Center=�6w   #��[ 6�   ��6   �� *	Creador+.  (System.Windows.Interactivity.Interaction   Triggers 5U      /  )System.Windows.Interactivity.EventTrigger  5V         	EventName$ Click��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5W      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 60   �� *NavegarCreadorCommand+5X      5Y      5[      5\      �� 5]   
   -	   5        $��button1��5]   |   $��Borrar��6   $��8��6"   $��2��62   $��40��6F   $��15(�6R   $��Right=�6`   $��Bottom=�6�   $	��130��6�    5^        5_      $ Click��6!   . 5`        	 6,   �� *EntradaBorrarCommand+5a      5b      5d      5e      5f      