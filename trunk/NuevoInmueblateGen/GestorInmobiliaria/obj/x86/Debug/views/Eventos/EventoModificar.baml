   M S B A M L   `   `   `  ����  GestorInmobiliaria6    0GestorInmobiliaria.views.Eventos.EventoModificar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        N� Title$  EventoModificar��6   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��30* �6   �� 5      $	��70* �6    � RowDefinitions 5   
   �� 5      $	��15* �6   �� 5      $	��15* �6   �� 5      $	��15* �6   �� 5      $	��15* �6   �� 5      $	��15* �6   �� 5      $	��25* �6   .+�5   
   �� -   5        $��label1��5   h   $��Nombre:��6   $��0��6"   $��0��62   $��28��6?   $��Center=�6K   $��Center=�6v   �� 5   
   -   5        $��label2��5   m   $��Descripción:��6   $��0��6'   $��1��67   $��28��6D   $��Center=�6P   $��Center=�6{   �� 5   
   -   5        $��label3��5   g   $��Fecha:��6   $��0��6!   $��2��61   $��28��6>   $��Center=�6J   $��Center=�6u   �� 5   
   -   5        $��label4��5   f   $��Tipo:��6   $��0��6    $��3��60   $��28��6=   $��Center=�6I   $��Center=�6t   �� 5   
   -   5        $��textBox1��5   L   $��23��6   $
��Left=�6   $��	0,25,0,19q�69   $��Center=�6�   $	��240��6�   $��1��6�   ��6\   �� *Nombre+ �� Mode$ TwoWay=�6�   �� 5   
   -   5        $��textBox2��5   V   $��1��6   $��1��6"   $��23��6/   $
��Left=�6;   $��Center=�6�   $	��120��6�   ��6f   �� *Descripcion+$ TwoWay=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePicker1��5   Y   $��1��6   $��2��6%   $��25��62   $
��Left=�6>   $��Center=�6�   $	��115��6�      SelectedDate 6l   �� *Fecha+$ TwoWay=�6�   �� 5   
   -   5        $��	comboBox1��5   �   $��1��6   $��3��6#   $��23��60   $
��Left=�6<   $��Center=�6�   $	��120��6�   ��6W   �� *TipoEventoEnum+ �� Path$&  ServiceReference1.TipoEventoEnum�6�   �� 5   
   -	   5        $��button2��5   }   $��	Modificar��6   $��1��6%   $��4��65   $��23��6B   $
��Left=�6N   $��
244,19,0,0q�6i   $	��Top=�6�   $��75��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5          	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5!      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6,   �� *EventoGuardarCommand+5"      5$      5%      5&      