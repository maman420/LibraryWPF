   M S B A M L   `   `   `  ����F  BLibraryProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LibraryProjLibraryProj  5   	       LibraryProj.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LibraryProj     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 	searchBtn��5   .   $��0��6   $��0��6!   $	��150��6Y   $��50��6e   $��30(�6q   .��6   search6�   �� 5   
   -   5         ��Name$ searchTextBox��5   <   $��1��6   $��35��6"   $��20(�6.   6U   �� 5   
   -   5        $ addJournalBtn��5   I   $��2��6   $��1��6!   $��Bottom=�6.   $	��150��6`   $��50��6l   $��30(�6x   $��10q�6�   .��6�   add journal6�   �� 5   
   -   5        $ 
addBookBtn��5   F   $��2��6   $��2��6!   $	��Top=�6.   $	��150��6s   $��50��6   $��30(�6�   $��10q�6�   .��6�   
add book6�   �� 5   
   -   5        $��comboBox��5   >   $��1��6   $��Bottom=�6#   $��90��6N   $��30��6Y   .@�5      �� -   5        $	��cb1��5      $��A - Z��6&   �� 5      -   5        $	��cb2��5      $��price high to low��6&   �� 5      -   5        $	��cb3��5      $��
most stock��6&   5      �� 5    
   -	   5         ��Name$ listBox��5    /   $��1��6   $��1��6"   $
��auto��6@   $
��auto��6N   �� 5"   
   -
   5        $ 	selectBtn��5"   .   $��1��6   $��2��6!   $��50��6Y   $	��150��6e   $��30(�6q   .��6   select6�   5#      5$      