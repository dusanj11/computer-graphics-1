   M S B A M L   `   `   `  ����\  XGMap.NET.WindowsForms, Version=1.7.0.0, Culture=neutral, PublicKeyToken=b85b9027b614afef\Bclr-namespace:GMap.NET.WindowsForms;assembly=GMap.NET.WindowsFormsGMap.NET.WindowsForms  5   	   T PGMap.NET.Core, Version=1.7.0.0, Culture=neutral, PublicKeyToken=b85b9027b614afef:-clr-namespace:GMap.NET;assembly=GMap.NET.CoreGMap.NET 5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   > :PZ1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PZ1PZ1 5	   	      PZ1.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   RgmfBclr-namespace:GMap.NET.WindowsForms;assembly=GMap.NET.WindowsForms     5   	   <gm-clr-namespace:GMap.NET;assembly=GMap.NET.Core     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   #localclr-namespace:PZ1     5	   	   -   5          � Title$  
MainWindow��5   	   $	��700��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�6M   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      .+�5   
   �� -   5        $��1��5      $��0��6!   $��Prikazi substations��6.   $��
0,-10,0,10q�6g   5      �� 5   
   -   5        $��1��5      $��1��6!   $��Prikazi nodes��6.   $��
0,-10,0,10q�6[   5      �� 5   
   -   5        $��1��5      $��2��6!   $��Prikazi switches��6.   $��
0,-10,0,10q�6a   5      �� 5   
   -   5        $��1��5      $��3��6!   $��Prikazi lines��6.   $��
0,-10,0,10q�6[   5       �� 5!   
   -   5        $��txbXml��5!      $��1��6#   $��1��63   $��WrapWithOverflow=�6@   5#      7  1System.Windows.Forms.Integration.WindowsFormsHost  5$   
   $��0��6   $��6��6+   $	��850��6<      Child. 5%      '   !GMap.NET.WindowsForms.GMapControl  -   5        gmap��   
CanDragMap .    MarkersEnabled .    MaxZoom$ 18��5%   T      MinZoom$ 2��6a   	   PolygonsEnabled	 . 
   RoutesEnabled
 .    Zoom$ 13Q�6�   5&      5'      5(      5)      