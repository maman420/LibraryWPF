   M S B A M L   `   `   `  ����F  BLibraryProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LibraryProjLibraryProj  5   	       LibraryProj.productPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LibraryProj     5   	     � Title$  productPage��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ titleTextBlock��5   L   $��0��6   $��0��6$   $��Center=�61   $��40(�6d   	book name6}   �� 5   
   -   5        $ authorTextBlock��5   I   $��0��6   $��1��6$   $	��Top=�61   $��26(�6b   author name6~   �� 5   
   -   5        $ priceTextBlock��5   L   $��0��6   $��1��6$   $��Center=�61   $��26(�6d   price:6{   �� 5   
   -   5        $ isbnTextBlock��5   L   $��0��6   $��1��6$   $��Bottom=�61   $��26(�6c   isbn:6y   �� 5   
   -   5        $ stockTextBlock��5   I   $��0��6   $��2��6$   $	��Top=�61   $��26(�6a   	in stock:6z   �� 5   
   -   5        $ descriptionTextBlock��5   C   $��0��6   $��2��6$   $��0,30,0,0q�61   $��20(�6a   description:6}   �� 5   
   -   5         ��Name$ backToMainBtn��5   .   $��2��6   $��0��6!   $��50��6a   $	��150��6m   $��20(�6y   .��6�   back to main6�   �� 5   
   -   5        $ 	removeBtn��5   I   $��2��6   $��2��6!   $��Bottom=�6.   $��50��6t   $	��150��6�   $��20(�6�   .��6�   remove item6�   �� 5   
   -	   5        $ addToStockBtn��5   .   $��2��6   $��2��6!   $��50��6a   $	��150��6m   $��20(�6y   .��6�   add to stock6�   �� 5    
   -
   5        $ removeStockBtn��5    F   $��2��6   $��2��6!   $	��Top=�6.   $��50��6{   $	��150��6�   $��20(�6�   .��6�   remove from stock6�   �� 5!   
   -   5        $ discountBtn��5!   I   $��2��6   $��1��6!   $��Bottom=�6.   $��50��6x   $	��150��6�   $��20(�6�   .��6�   apply discount6�   �� 5"   
   -   5         ��Name$ discountTextBox��5"   G   $��2��6   $��1��6"   $	��Top=�6/   $��40��6`   .��6�   enter discount here6�   5#      5$      