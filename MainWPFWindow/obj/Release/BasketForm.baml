   M S B A M L   `   `   `  ���� H  DMainWPFWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MainWPFWindowMainWPFWindow      MainWPFWindow.BasketForm   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:MainWPFWindow       � Title$  
BasketForm��$	��450��$	��800��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridReceipts��   AutoGenerateColumns .     SelectionMode$ Extended=�$
��Auto��$��3,10,3,0q�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto    Header$ 	ReceiptId��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	ReceiptId+  $
 auto $ PersonId�� �� *
PersonId+  $
 auto $ GoodId�� �� *GoodId+  $
 auto $ Price�� �� *Price+  $
 auto $ Amount�� �� *Amount+  $
 auto $ Discount�� �� *
Discount+  $
 auto $ GeneralPrice�� �� *GeneralPrice+  $
 auto $ BuyTime�� �� *	BuyTime+