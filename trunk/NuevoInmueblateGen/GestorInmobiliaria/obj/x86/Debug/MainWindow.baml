   M S B A M L   `   `   `  ����M  IGestorInmobiliaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:GestorInmobiliaria.ServiceReference1$GestorInmobiliaria.ServiceReference1  5   �   #    GestorInmobiliaria.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   F   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   Amy2clr-namespace:GestorInmobiliaria.ServiceReference1     6�   -   5          � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5         anuncioDTOViewSource��%   &	        �� 5   
   6   5      .��5      �  � DataContext# [  6   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5        $��anuncioDTODataGrid��5	   �      AutoGenerateColumns .     EnableRowVirtualization . $	��200��6N   $
��Left=�6[   $��	51,61,0,0q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $	��Top=�6�   $	��400��6  ��6v   ��    Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        descripcionColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Descripcion��5   e      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6z   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6@   �� 
 �� Path$
 Descripcion�6z   4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        fechaCaducidadColumn��$ Fecha Caducidad��5   G   $ SizeToHeader 6`      CellTemplate 5      �� 5      .R�5      (  "System.Windows.Controls.DatePicker     SelectedDate 6)   �� $
 FechaCaducidad� �� Mode$ TwoWay=� �� ValidatesOnExceptions .  �� NotifyOnValidationError . 5      5        5      -   5        idColumn��$ Id��5   S   $ SizeToHeader 6_   	 67   �� $
 Id�6_     5      -   5        imagenColumn��$ Imagen��5   [   $ SizeToHeader 6k   	 6;   �� $
 Imagen�6k     5      -   5        
tipoColumn��$
 Tipo��5   W   $ SizeToHeader 6e   	 69   �� $

 Tipo�6e     5      -   5        	uRLColumn��$	 URL��5   U   $ SizeToHeader 6b   	 68   �� $	
 URL�6b   5      5      5      