   M S B A M L   `   `   `  ����H  DMainWPFWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MainWPFWindowMainWPFWindow  5   	   !    MainWPFWindow.MakeOrderForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MainWPFWindow     5   	     � Title$  MakeOrderForm��5   	   $	��450��6   $	��800��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��2* �6   6,   .+�5   
   �� $��0��6   $��0��6   $��Name:��6-   $��20(�6=   $��Center=�6K   $��Center=�6f   6�   �� 5   
   $��1��6   $��0��6   $��	LastName:��6-   $��20(�6A   $��Center=�6O   $��Center=�6j   6�   �� 5   
   $��2��6   $��0��6   $��	GoodName:��6-   $��20(�6A   $��Center=�6O   $��Center=�6j   6�   �� 5   
   $��3��6   $��0��6   $��Price:��6-   $��20(�6>   $��Center=�6L   $��Center=�6g   6�   �� 5   
   $��4��6   $��0��6   $��Amount:��6-   $��20(�6?   $��Center=�6M   $��Center=�6h   6�   �� 5   
   $��5��6   $��0��6   $��	Discount:��6-   $��20(�6A   $��Center=�6O   $��Center=�6j   6�   �� 5   
   $��6��6   $��0��6   $��GeneralPrice:��6-   $��20(�6E   $��Center=�6S   $��Center=�6n   6�   �� 5   
   -   5         ��Name$ FirstNameTB��5      $��0��6'   $��1��64   $��20(�6D   6T   �� 5    
   -   5        $ 
LastNameTB��5       $��1��6&   $��1��63   $��20(�6C   6S   �� 5!   
   -   5        $ 
GoodNameTB��5!      $��2��6&   $��1��63   $��20(�6C   6S   �� 5"   
   -   5        $ PriceTB��5"      $��3��6#   $��1��60   $��20(�6@   6P   �� 5#   
   -   5        $ AmountTB��5#      $��4��6$   $��1��61   $��20(�6A   6~   �� 5%   
   -   5        $ 
DiscountTB��5%      $��5��6&   $��1��63   $��20(�6C   $
��Left=�6Q   $	��200��6l   6z   �� 5&   
   $��%��6   $��5��6   $��1��6)   $��20(�69   $��Center=�6G   $��50��6d   6q   �� 5'   
   -   5        $ GeneralPriceTB��5'      $��6��6*   $��1��67   $��20(�6G   6W   �� 5(   
   -   5         ��Name$ 	BuyButton��5(      $	��Buy��6$   $��24(�62   $��7��6A   $��0��6N   $��2��6^   6�   5)      5*      