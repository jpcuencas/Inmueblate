   M S B A M L   `   `   `  ����  GestorInmobiliaria'    !GestorInmobiliaria.views.Anuncios   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        N� Title$  Anuncios��5	      .��5      � $	��718��6   .+�5   
   �� -   5        $��button1��5   c   $��Crear anuncio��6   $��23��6)   $
��Left=�65   $��	56,42,0,0q�6P   $	��Top=�6r   $	��100��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *NuevoAnuncioCommand+5      5      5      �� 5   
   -   5        $��label1��5   ^   $��Anuncios��6   $��28��6#   $
��Left=�6/   $��
56,101,0,0q�6J   $	��Top=�6l   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridAnuncios��5   �      AutoGenerateColumns .     
IsReadOnly . $	��218��6g   $
��Left=�6t   $��
56,161,0,0q�6�   $	��Top=�6�   $	��626��6�    �� SelectedItem 6   �� *SelectedItem+��6�   �� *
Anuncios+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 30 61   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6<   �� *Id+4
  .System.Windows.Controls.DataGridTemplateColumn
  5      $
	 Foto��6)   $	
 100 67      
IsReadOnly .  
  CellTemplate 5      �� 5      .R�5      �� ��6$   �� *Imagen+5      5        5      $	 Descripción��6%   $	
 275 6:    6F   �� *Descripcion+  5       $
	 Tipo��6%   $	
 100 63    6?   �� *Tipo+  5!      $		 URL��6%   $	
 100 62    6>   �� *URL+ 5#        5$      $ SelectionChanged��6!   . 5%         6,   �� *SelectionChangedCommand+   CommandParameter 5&   ,   �� *SelectedItem+ �� ElementName$ dataGridAnuncios��5'      5(      5*      5+      5,      