   M S B A M L   `   `   `  ����U  QInteractiveDataDisplay.WPF, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:InteractiveDataDisplay.WPFInteractiveDataDisplay.WPF  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;    5InteractiveDataDisplay.WPF.CountToVisibilityConverter   CountToVisibilityConverter)   #InteractiveDataDisplay.WPF.PlotAxis  �� 
TargetType �� Property �� Value �� 
TargetType%   InteractiveDataDisplay.WPF.Axis  Name   AxisOrientation �� Mode �� RelativeSource   Ticks	   
Foreground&    InteractiveDataDisplay.WPF.Chart'   !InteractiveDataDisplay.WPF.Figure
  Name   BorderThickness   ExtraPadding)   #InteractiveDataDisplay.WPF.PlotBase   
PlotHeight   	PlotWidth   PlotOriginX   PlotOriginY   IsAutoFitEnabled   AspectRatio0   *InteractiveDataDisplay.WPF.MouseNavigation  Name"   IsVerticalNavigationEnabled"   IsVerticalNavigationEnabled$   IsHorizontalNavigationEnabled$   IsHorizontalNavigationEnabled3   -InteractiveDataDisplay.WPF.KeyboardNavigation  Name"   IsVerticalNavigationEnabled$   IsHorizontalNavigationEnabled7   1InteractiveDataDisplay.WPF.VerticalContentControl   	Placement   	LeftTitle  Name   AxisOrientation)	   #InteractiveDataDisplay.WPF.AxisGrid 	 Name  	  Stroke! J� Opacity" 	  VerticalTicks# �� ElementName$ 	  HorizontalTicks%   Title&   BottomTitle'   
RightTitle'
   !InteractiveDataDisplay.WPF.Legend( 
 Name)   LegendContent*   LegendVisibility+ ��Name, �� RadiusX- �� RadiusY. J� IsHitTestVisible/ �� 	Converter0 ��Name1 ��Name�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      /d3(clr-namespace:InteractiveDataDisplay.WPF  5      %  &	        '       '  �    '
  �	    7   '  -       5      6$   �� 5
      "   6   .�5   
   ��  � �� 5      �� 5      "  6"   .R�5      � .+�5        $ 	PART_Axis��6"    5   "   �� *AxisOrientation+$ TwoWay=� �� *TemplatedParent+ 5   "   �� *Ticks+$ TwoWay=� �� *TemplatedParent+	 5   "   �� *
Foreground+$ TwoWay=� �� *TemplatedParent+�� 5      5      5      5      �� 5   
    � �� .  6&   5      �� 5      "   6   .�5   
   ��  � �� 5      �� 5      "  6"   .R�5      � .+�5         $
 PART_figure��6$   $��1q�69   # z 5'   $   #��z��5(   $    5!   $   �� *
PlotHeight+$ TwoWay=� �� *TemplatedParent+ 5"   $   �� *	PlotWidth+$ TwoWay=� �� *TemplatedParent+ 5#   $   �� *PlotOriginX+$ TwoWay=� �� *TemplatedParent+ 5$   $   �� *PlotOriginY+$ TwoWay=� �� *TemplatedParent+ 5%   $   �� *IsAutoFitEnabled+$ TwoWay=� �� *TemplatedParent+ 5&   $   �� *AspectRatio+$ TwoWay=� �� *TemplatedParent+.+�5)        $ PART_mouseNavigation��5+   1   # z 5)   1   # z 5*   1   5+   1     5,      $ PART_keyboardNavigation��5.   4   # z 5,   4   # z 5-   4   5.   4     5/      $
 Left=�68   #��z 50   8   $��Center=�51   8   ��.  52   8     53      $ PART_verticalAxis��6*   $
 Left=�54   *   $
 Left=�55   *   #��z��56   *   .��57   "      .  65   58      	  59      $ PART_axisGrid��6*   #  z��5<   *   $
! 0.25Q�6P   " 5:   *   �� *Ticks+$# PART_verticalAxis��$ OneWay=�$ 5;   *   �� *Ticks+$# PART_horizontalAxis��$ OneWay=�5<   P   �� 5=      $	 Top=�6-   $��Center=�5>   -   $��16(�5?   -   #��z% 5@   -   #��z��5A   -   ��.  5B   -   �� 5C      $ Bottom=�6-   $��Center=�5D   -   #��z& 5E   -   #��z��5F   -   ��.  5G   -     5H      $ Right=�68   #��z' 5I   8   $��Center=�5J   8   ��.  5K   8     5L      $ PART_horizontalAxis��6*   $ Bottom=�5M   *   $ Bottom=�5N   *   #��z��5O   *   .��5P   "      .  65   5Q      �� 5R      �� 5S      #��z 6%   #��z��5T   %   $ Center=�6P   
  5U      $( PART_legend��6(   
���   �#��z) 5V   ;   #y�z* 5W   (   5X      �� 5Y      $+ FocusVisualElement��6$   $, 2��6@   $- 2��6L   ���	#FF6DBDD1$��1��6k   $! 0Q�6   . .  6�   5Z      5[      5]      �� 5^   
    � �� .  6&   5_      �� 5a      "  
 6   .�5b   
   ��  � �� 5c      �� 5d      " 
 6"   .R�5e      � 
������ $��10,10,10,10q�64   $	��Top=�6I   $��Right=�5f      .+�5g      �� $+ legendBorder��6$   
���   �$��Stretch=�6I   $��Stretch=�6e   $, 10��5h      $- 10��6*   
�������$
! 0.75Q�6D   y�5i      �� *
ItemsCount+ �� *TemplatedParent+8/   �� 5j      $0 scrollViewer��6'   $��10,10,10,10q�5k   '   $
��Auto=�6<   $
��Auto=�5l   '   ��.  $��0q�5m   '   .��5n      �� 5o      5p      5q      5s      5t      �� 5v      "   6   .�5w   
   ��  � �� 5x      �� 5y      "  6"   .R�5z      �� $1 	Presenter��5{      #��z��5|      #��z��5}      5~      5�      5�      5�      