   M S B A M L   `   `   `  ����  GestorInmobiliaria4    .GestorInmobiliaria.views.Mensaje.TodosUsuarios   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   Y UXceed.Wpf.DataGrid, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5   	     � AllowsTransparency  .  � WindowStyle$
 None=�5   #   
������  � 
ResizeMode$ NoResize=�6O    � WindowStartupLocation$ CenterScreen=�6e    � Title$ TodosUsuarios��5   	   $	��427��6   $	��450��6,   .��5      ��  �� CornerRadius$ 	0,0,50,50��6   ��5	   
   �� 5
       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFD1D6CF��6   	 � Offset$	 0.473Q�61   � 5      $ 	#FFA9ADA7��6   $	 0.796Q�61   5      ._�5      � 
 � RowDefinitions
 5      �� 5      $
��190* �6    �� 5      $
��190* �6    �� 5      $	��47* �6     � ColumnDefinitions 5      �� 5      $��0* �6   �� 5      $	��12* �6   �� 5      $
��416* �6   .+�5   
   (  "Xceed.Wpf.DataGrid.DataGridControl  -   5        $��dGListaUsuarios��5   s   $��
0,46,12,10q�6_      AutoCreateColumns .     ReadOnly .     SelectionMode$ Single=�6�      NavigationBehavior$ RowOnly=�6�      HideSelection . $��2��6$     SelectedItem 6   �� *SelectedItemListaUsuarios+ �� Mode$ TwoWay=���6�   �� *ListaUsuarios+   Columns 5        Xceed.Wpf.DataGrid.Column  5      #  Xceed.Wpf.DataGrid.ColumnBase   	FieldName$ Nombre��6      Title$ Nombre��61   6B     5      $ 	Apellidos��6   $ 	Apellidos��64   6H    � 	Resources 5       4  .Xceed.Wpf.DataGrid.Views.TableViewScrollViewer �� 
TargetType �� Property �� Value��%V   '        �� 5!      "  6   .�5"      ��  � ��$ Hidden=�6D   5#      5$         View 5&      (  "Xceed.Wpf.DataGrid.Views.TableView  5'         ShowRowSelectorPane .  #   IsAlternatingRowStyleEnabled . '  !Xceed.Wpf.DataGrid.Views.ViewBase   UseDefaultHeadersFooters .     ColumnStretchMode$	 All=�6�      Theme.  (Xceed.Wpf.DataGrid.Markup.ThemeConverter$ Windows7Theme 6�       FixedHeaders  5(      �� 5)      .R�5*      )  #Xceed.Wpf.DataGrid.ColumnManagerRow  5+      5-      .	  (System.Windows.Interactivity.Interaction! 	  Triggers! 50      /
  )System.Windows.Interactivity.EventTrigger
  51      " 
  	EventName$" MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase#   Actions.# 52      6  0System.Windows.Interactivity.InvokeCommandAction  $   Command$ 6,   �� *&$SelectionChangedListaUsuariosCommand+%   CommandParameter% 53   ,   �� *SelectedItemListaUsuarios+& �� ElementName$& dGListaUsuarios��54      55      57      �� 5?      -   5        $��btnCerrarInf��5?   G   $��Cerrar��6   $��36��6&   $��139,0,162,0q�62   $	��Top=�6[   $��2��6s   $��2��6�   �� 5@   
   -   5        $��label1��5@   A   $��Usuarios��6   $��28��6#   $��0,12,0,0q�6/   $	��Top=�6O   $��2��6g   $
��Left=�6w   $	��106��6�   $
��Bold"�6�   �� 5A   
   -   5        $��label2��5A   E   $��Inmobiliarias��6   $��28��6(   $��0,3,0,0q�64   $	��Top=�6S   $��2��6k   $��1��6{   $
��Left=�6�   $	��106��6�   $
��Bold"�6�   �� 5B   
   -   5        $��chkTodosUsuarios��5B   t   $��MarcarTodos��6   $��2��6)   $��16��69   $
��Left=�6E   $��
125,17,0,0q�6`   $	��Top=�6�   $
��Bold"�6�   $��Italic$�6�   ! 5C      
  5D      $" Checked��6!   .# 5E        $ 6,   �� *CheckedListaUsuariosCommand+5F      5G      
  5H      $" 	Unchecked��6!   .# 5I        $ 6,   �� *UnCheckedListaUsuariosCommand+5J      5K      5M      �� 5N   
   -   5        $��chkTodasInmobiliarias��5N   ^   $��MarcarTodas��6   $��2��6)   $��16��69   $��125,8,213.717,0q�6E   $	��Top=�6{   $��1��6�   $��Italic$�6�   $
��Bold"�6�   �� 5O   
   -   5        ' ��Name$' 	btnCerrar��5O      $��2��6$   $�� ��64   $��Right=�6?      BotonCerrar#���   6[   $��32��6�   $��33��6�   $	��Top=�6�   6�   5P      5Q      5R      