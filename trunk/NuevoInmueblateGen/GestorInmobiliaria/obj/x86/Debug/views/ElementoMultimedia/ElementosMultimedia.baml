   M S B A M L   `   `   `  ����  GestorInmobiliariaE    ?GestorInmobiliaria.views.ElementoMultimedia.ElementosMultimedia   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        N� Title$  ElementosMultimedia��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��199* �6   �� 5      $
��199* �6    � ColumnDefinitions 5   
   �� 5      $
��130* �6   �� 5      $
��130* �6   �� 5      $
��130* �6   �� 5      $
��131* �6   .+�5   
   �� -   5        $��btnFotos��5   B   $��Fotos��6   $	��110��6!   $��
0,145,57,0q�6.   $	��Top=�6R   $��2��6j   $��Right=�6{   $	��144��6�   $��2��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *FotosCommand+5      5      5      �� 5   
   -   5        $��	btnVideos��5   ^   $��Videos��6   $	��110��6"   $
��Left=�6/   $��
56,145,0,0q�6J   $	��Top=�6o   $	��144��6�   $��2��6�   $��2��6�   $��2��6�    5        5       $ Click��6!   . 5!         6,   �� *VideosCommand+5"      5#      5%      5&      5'      