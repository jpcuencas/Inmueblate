   M S B A M L   `   `   `  ����  GestorInmobiliariaJ    DGestorInmobiliaria.views.ElementoMultimedia.ListaElementosMultimedia   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Y UXceed.Wpf.DataGrid, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5        N� Title$  ListaElementosMultimedia��5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��100* �6   �� 5      $	��100 �6   .+�5   
   �� -   5         ��Name$ lbl_Usuarios��5   �   $
��Auto��6)   $
��Auto��66   $��0��6D   $��15(�6Q   $
��Left=�6_   $��50,0,0,0q�6z   $��Center=�6�   ��6   �� *Tipo+6�   (  "Xceed.Wpf.DataGrid.DataGridControl  5   
   -   5        $��dataGridElementos��5   e   $��1��6   $��	50,0,50,0q�6R      AutoCreateColumns .     ReadOnly .    SelectionMode$ Single=�6�      NavigationBehavior$ RowOnly=�6�      HideSelection .    SelectedItem 6,   �� *SelectedItem+��6~   �� *	Elementos+	   Columns	 5        Xceed.Wpf.DataGrid.Column  5      #  Xceed.Wpf.DataGrid.ColumnBase
   	FieldName$
 Id��6      Title$ Identificador��6-   6E     5      $
 Nombre��6   $ Nombre��61   6B     5      $
 Descripcion��6   $ Descripcion��66   6L     5      $	
 URL��6   $	 Url��6.   6<    � 	Resources 5      4  .Xceed.Wpf.DataGrid.Views.TableViewScrollViewer �� 
TargetType �� Property �� Value��%V   '        �� 5      "  6   .�5      ��  � ��$ Hidden=�6D   5      5         View 5!      (  "Xceed.Wpf.DataGrid.Views.TableView  5"         ShowRowSelectorPane .  #   IsAlternatingRowStyleEnabled . '  !Xceed.Wpf.DataGrid.Views.ViewBase   UseDefaultHeadersFooters .     ColumnStretchMode$	 All=�6�      Theme.  (Xceed.Wpf.DataGrid.Markup.ThemeConverter$ Windows7Theme 6�      FixedHeaders 5#      �� 5%      .R�5'      )  #Xceed.Wpf.DataGrid.ColumnManagerRow  5)      5-      .	  (System.Windows.Interactivity.Interaction 	  Triggers 50      /
  )System.Windows.Interactivity.EventTrigger
  51       
  	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 52      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *SelectionChangedCommand+   CommandParameter 53   ,   �� *SelectedItem+ �� ElementName$ dataGridElemntos��54      55      57      �� 58   
   -   5        $��button3��58   X   $��Volver��6   $��15(�6"   $��2��60   $
��Left=�6=   $	��130��6g   $��50,0,0,0q�6s   $��40��6�   $��Center=�6�    59      
  5:      $ Click��6!   . 5;         6,   �� *VolverCommand+5<      5=      5?      5@      5A      