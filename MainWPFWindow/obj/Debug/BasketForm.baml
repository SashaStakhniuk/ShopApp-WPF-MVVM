   M S B A M L   `   `   `  ����H  DMainWPFWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MainWPFWindowMainWPFWindow  5   	       MainWPFWindow.BasketForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MainWPFWindow     5   	     � Title$  
BasketForm��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridReceipts��5         AutoGenerateColumns .     SelectionMode$ Extended=�6I   $
��Auto��6b   $��3,10,3,0q�6p   ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6%      Header$ 	ReceiptId��62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *	ReceiptId+6e     5      $
 auto 6%   $ PersonId��62    6D   �� *
PersonId+6c     5      $
 auto 6%   $ GoodId��62    6B   �� *GoodId+6_     5      $
 auto 6%   $ Price��62    6A   �� *Price+6]     5      $
 auto 6%   $ Amount��62    6B   �� *Amount+6`     5      $
 auto 6%   $ Discount��62    6D   �� *
Discount+6c     5      $
 auto 6%   $ GeneralPrice��62    6H   �� *GeneralPrice+6k     5      $
 auto 6%   $ BuyTime��62    6C   �� *	BuyTime+6a   5      5      5      