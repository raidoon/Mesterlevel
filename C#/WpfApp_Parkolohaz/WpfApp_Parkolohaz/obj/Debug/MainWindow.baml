   M S B A M L   `   `   `  ����L  HWpfApp_Parkolohaz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp_ParkolohazWpfApp_Parkolohaz  5   	   "    WpfApp_Parkolohaz.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfApp_Parkolohaz     5   	     � Title$  Parkolóház��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5
      $��Center=�6%   $	��273��6B   $��	0,134,0,0q�6O   $	��Top=�6b   $	��736��6z   �� 5   
   -   5         ��Name$ 
tbrendszam��5      $
��Left=�6&   $��
639,38,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��120��6�   6�   �� 5   
   $��Keresés rendszámmal:��6   $
��Left=�6/   $��
501,34,0,0q�6J   $	��Top=�6^   �� 5   
   $��Szűrés szint alapján:��6   $
��Left=�60   $��
501,87,0,0q�6K   $	��Top=�6_   �� 5   
   -   5         ��Name$ cbszint��5      $
��Left=�6$   $��
639,91,0,0q�6?   $	��Top=�6S   $	��120��6k   6w   �� 5   
   -   5         ��Name$ btujparkolas��5      $��Új autó parkoltatása��6'   $
��Left=�6F   $��
176,92,0,0q�6a   $	��Top=�6u   $��31��6�   $	��130��6�   6�   �� 5   
   $��Emelet:��6   $
��Left=�6"   $��	57,34,0,0q�6=   $	��Top=�6P   �� 5   
   $��Parkolóhely:��6   $
��Left=�6'   $��	32,60,0,0q�6B   $	��Top=�6U   �� 5   
   -   5        $ cbemelet��5      $
��Left=�6%   $��
116,36,0,0q�6@   $	��Top=�6T   $	��120��6l   �� 5   
   -   5        $ cbparkolohely��5      $
��Left=�6*   $��
116,64,0,0q�6E   $	��Top=�6Y   $	��120��6q   �� 5   
   -   5         ��Name$ lbszabad��5      $��label��6"   $
��Left=�62   $��
281,21,0,0q�6M   $	��Top=�6a   $��35��6y   $	��185��6�   �� 5   
   $��
Rendszám:��6   $
��Left=�6$   $��
274,62,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ tbujrendszam��5      $
��Left=�6(   $��
346,68,0,0q�6C   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��120��6�   5      5      