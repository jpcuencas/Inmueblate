   M S B A M L   `   `   `  ����  GestorInmobiliaria-    'GestorInmobiliaria.views.AnuncioDetalle   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        N� Title$  AnuncioDetalle��5	      .��5      � $	��341��6   .+�5   
   �� -   5        $��lblId��5   a   $��28��6'   $
��Left=�63   $��	60,79,0,0q�6N   $	��Top=�6n   ��6   �� *Id+6n   �� 5   
   -   5        $��lblDescripcion��5   k   $��28��60   $
��Left=�6<   $��
60,122,0,0q�6W   $	��Top=�6�   ��6   �� *Descripcion+6�   �� 5   
   -   5        $��lblFechaCaducidad��5   n   $��28��63   $
��Left=�6?   $��
60,166,0,0q�6Z   $	��Top=�6�   ��6   �� *FechaCaducidad+6�   �� 5   
   -   5        $��lblTipo��5   d   $��28��6)   $
��Left=�65   $��
60,210,0,0q�6P   $	��Top=�6s   ��6   �� *Tipo+6s   �� 5   
   -   5        $��lblURL��5   c   $��28��6(   $
��Left=�64   $��
60,252,0,0q�6O   $	��Top=�6q   ��6   �� *URL+6q   �� 5   
   -   5        $��button1��5   ^   $��Borrar��6   $��23��6"   $
��Left=�6.   $��213,306,0,0q�6I   $	��Top=�6m   $��75��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *AnuncioBorrarCommand+5      5      5      �� 5   
   -   5        $��button2��5   a   $��	Modificar��6   $��23��6%   $
��Left=�61   $��132,306,0,0q�6L   $	��Top=�6p   $��75��6�   �� 5   
   -   5        $��button3��5   ]   $��Volver��6   $��23��6"   $
��Left=�6.   $��
12,306,0,0q�6I   $	��Top=�6l   $��75��6�    5        5      $ Click��6!   . 5         6,   �� *VolverCommand+5      5      5!      5"      5#      