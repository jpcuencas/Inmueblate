   M S B A M L   `   `   `  ����  GestorInmobiliaria+    %GestorInmobiliaria.views.AnuncioNuevo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  AnuncioNuevo��5      .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��70* �6    � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��20* �6   �� 5      $	��20* �6   �� 5      $	��20* �6   �� 5      $	��20* �6   .+�5   
   �� -   5        $��label1��5   f   $��Imagen:��6   $��28��6"   $��Center=�6.   $��Center=�6K   $��0��6t   $��0��6�   �� 5   
   -   5        $��label2��5   k   $��Descripción:��6   $��28��6'   $��Center=�63   $��Center=�6P   $��1��6y   $��0��6�   �� 5   
   -   5        $��label3��5   r   $��Fecha de caducidad:��6   $��28��6.   $��Center=�6:   $��Center=�6W   $��2��6�   $��0��6�   �� 5   
   -   5        $��label4��5   d   $��Tipo:��6   $��28��6    $��Center=�6,   $��Center=�6I   $��3��6r   $��0��6   �� 5   
   -   5        $��label5��5   c   $
��URL:��6   $��28��6   $��Center=�6+   $��Center=�6H   $��4��6q   $��0��6~   �� 5   
   -   5        $��textBox1��5   �   $��1��6?   $��0��6O   $��23��6\   $
��Left=�6h   $��Center=�6�   $	��240��6�   ��6   �� *Imagen+ �� Mode$ OneWayToSource=�6�   �� 5   
   -   5        $��button1��5   l   $��Examinar...��6   $��1��6'   $��0��67   $��23��6D   $��Right=�6P   $��Center=�6{   $��75��6�   �� 5   
   -   5        $��textBox2��5   �   $��1��6D   $��1��6T   $��23��6a   $
��Left=�6m   $��Center=�6�   $	��120��6�   ��6   �� *Descripcion+$ OneWayToSource=�6�   (  "System.Windows.Controls.DatePicker  5!   
   -	   5        $��datePicker1��5!   �   $��1��6R   $��2��6b   $��25��6o   $
��Left=�6{   $��Center=�6�   $	��115��6�      SelectedDate 6   �� *FechaCaducidad+$ OneWayToSource=�6�   �� 5#   
   -
   5        $��	comboBox1��5#   �   $��1��6b   $��3��6r   $��23��6   $
��Left=�6�   $��Center=�6�   $	��120��6�   ��6   ��  �� Path$7 1NuevoInmueblateGenNHibernate.Enumerated.RedSocial�6�   �� 5%   
   -   5        $��textBox3��5%   V   $��1��6   $��4��6"   $��23��6/   $
��Left=�6;   $��Center=�6f   $	��240��6�   5&      5'      