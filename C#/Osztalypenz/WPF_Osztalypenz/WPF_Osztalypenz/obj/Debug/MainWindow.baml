   M S B A M L   `   `   `  ����J  FWPF_Osztalypenz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_OsztalypenzWPF_Osztalypenz  5   	        WPF_Osztalypenz.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_Osztalypenz     5   	     � Title$"  Osztálypénz nyilvántartó��5   	   $��568.5��6*   $��909.5��69   .��5	      � $��0,0,24,0q�6   $	��525��6   $	��Top=�6*   .+�5
   
   �� -   5         ��Name$ listbox��5
      $
��Left=�6#   $	��328��6>   $��	10,10,0,0q�6K   $	��Top=�6^   $	��443��6v   $��20(�6�   �� 5   
   -   5         ��Name$ 
lbegyenleg��5      $��	Egyenleg:��6$   $
��Left=�68   $��
512,19,0,0q�6S   $	��Top=�6g   $��20(�6   �� 5   
   -   5        $ lbtranzakcio��5      $��Új tranzakció típusa:��6&   $
��Left=�6F   $��512,105,0,0q�6a   $	��Top=�6v   $��20(�6�   	� 5   
   -   5         	�Name$ radiobtbefizetes��5      $��
befizetés��60   $
��Left=�6D   $��512,152,0,0q�6_   $	��Top=�6t    d� 	IsChecked$
 TrueY�6�   $��20(�6�   	� 5   
   -   5        $ radiobtkifizetes��5      $��
kifizetés��60   $
��Left=�6D   $��625,152,0,0q�6_   $	��Top=�6t   $��20(�6�   �� 5   
   -   5        $ lbnev��5      $��Név:��6   $
��Left=�6.   $��512,190,0,0q�6I   $	��Top=�6^   $��20(�6v   �� 5   
   -   5        $ lbdatum��5      $��Dátum:��6!   $
��Left=�62   $��512,238,0,0q�6M   $	��Top=�6b   $��20(�6z   �� 5   
   -   5        $ lbosszeg��5      $��Összeg:��6"   $
��Left=�64   $��512,288,0,0q�6O   $	��Top=�6d   $��20(�6|   �� 5   
   -	   5         ��Name$ tbnev��5      $
��Left=�6!   $��34��6<   $��607,190,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��175��6�   $��20(�6�   6�   �� 5   
   -
   5        $ tbosszeg��5      $
��Left=�6$   $��34��6?   $��607,291,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��175��6�   $��20(�6�   6�   �� 5   
   -   5         ��Name$ btadatrogzites��5      $��Adatrögzítés��6)   $
��Left=�6@   $��667,343,0,0q�6[   $	��Top=�6p   $	��135��6�   $��20(�6�   $��76��6�   ���	#FFE6DD226�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datum��5      $
��Left=�6$   $��607,238,0,0q�6?   $	��Top=�6T   $��20(�6l   $	��175��6z   �� 5   
   -   5        $ lbuzenet��5      $�� ��6"   $
��Left=�6-   $��
39,343,0,0q�6H   $	��Top=�6\   $	��601��6t   $��20(�6�   $
��Bold"�6�   $��65��6�   ���	#FFE2D28C6�   �� 5   
   -   5        $ 	lbfajlnev��5      $��
Fájlnév:��6#   $
��Left=�66   $��
39,439,0,0q�6Q   $	��Top=�6e   $��20(�6}   �� 5   
   -   5        $ 	tbfajlnev��5      $
��Left=�6%   $��37��6@   $��134,439,0,0q�6L   $
 Wrap=�6a   $��osztalypenz.txt��6u   $	��Top=�6�   $	��319��6�   $��20(�6�   6�   5      5      