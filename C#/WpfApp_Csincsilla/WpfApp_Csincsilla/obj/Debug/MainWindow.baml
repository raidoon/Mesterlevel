   M S B A M L   `   `   `  ����L  HWpfApp_Csincsilla, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp_CsincsillaWpfApp_Csincsilla  5   	   "    WpfApp_Csincsilla.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfApp_Csincsilla     5   	     � Title$  WPF Csincsilla��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� .@�5      �� $��Csincsilla adatok��6   .��5      � 
�������.+�5      �� $
��Left=�6   $	��178��5      $��	21,15,0,0q�6!   $	��Top=�5      $	��412��6,   $��/csilla.png��5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ datagrid��5      $
��Left=�5      $	��203��5      $��
21,193,0,0q�6$   $	��Top=�5      $	��396��6/   �� 5      -   5         ��Name$ 	tbkereses��5      $
��Left=�61   $��515,225,0,0q�5       �� TextWrapping$
 Wrap=�5      $�� ��6*   $	��Top=�5      $	��148��5      $��31��6"   6.   	� 5      -   5         	�Name$ rbsimogathato��5   "   $��Simogatható állatok��5      $
��Left=�5      $��515,280,0,0q�65   $	��Top=�5      62   	� 5      -   5        $ rbnemsimogathato��5   "   $��Nem simogatható állatok��5      $
��Left=�5       $��515,323,0,0q�65   $	��Top=�5!      62   �� 5"      -   5         ��Name$ 
lberedmeny��5"      $��	Eredmény��5#      $
��Left=�5$      $��
450,30,0,0q�5%      $	��Top=�6(   $	��148��5&      $	��334��6!   5'      5(      �� 5)      $��Új Csincsilla��6   .��5*      � 
������.+�5+      �� -   5        $ lbnev��5+      $��kisállat neve��5,      $
��Left=�5-      $��	59,54,0,0q�6/   $	��Top=�5.      �� 50      -   5        $ tbnev��50      $
��Left=�51      $��
160,62,0,0q�61   $
 Wrap=�52      $�� ��6*   $	��Top=�62   $	��185��53      �� 55      -   5        $ 
lbszuletes��55      $'��!kisállat születésének dátuma��56      $
��Left=�57      $��
59,116,0,0q�6/   $	��Top=�58      �� 5:      -	   5        $ lbsuly��5:      $��kisállat súlya grammban��5;      $
��Left=�5<      $��
59,177,0,0q�6/   $	��Top=�5=      �� 5?      -
   5         ��Name$ cbSimogathato��5?      $*��$szereti-e ha simogatják (I vagy N).��5@      $
��Left=�5A      $��
97,288,0,0q�62   $	��Top=�5B      �� 5D      -   5         ��Name$ btadatrogzites��5D      $��Adatok rögzítése��5E      $
��Left=�60   $��344,273,0,0q�6K   $	��Top=�6`   $��72��6x   $	��236��6�   6�   (  "System.Windows.Controls.DatePicker  5G      -   5          Name$ 
dpszuletes��5G   !   $
��Left=�5H      $��248,118,0,0q�64   $	��Top=�6I   �� 5J      -   5        $ tbsuly��5J      $
��Left=�6.   $��225,177,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   $��26��6�   5K      5L      5M      5N      5O      